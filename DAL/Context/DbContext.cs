using DAL.ConnectionFactory;
using DAL.UoW;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL.Context
{
  public class DbContext : IDbContext
  {
    private readonly IDbConnectionFactory _connectionFactory;
    private IDbConnection _connection;
    private IDbTransaction _transaction;
    private IUnitOfWork _unitOfWork;


    public DbContext(IDbConnectionFactory connectionFactory)
    {
      _connectionFactory = connectionFactory;
    }
    public IDbContextState State { get; private set; } = IDbContextState.Closed;

    public IDbConnection Connection => _connection ?? (_connection = OpenConnection());

    public IDbTransaction Transaction => _transaction ?? (_transaction = Connection.BeginTransaction());

    public IUnitOfWork UnitOfWork => _unitOfWork ?? (_unitOfWork = new UnitOfWork(Transaction));

    public void Commit()
    {
      try
      {
        UnitOfWork.Commit();
        State = IDbContextState.Commited;
      }
      catch
      {
        Rollback();
        throw;
      }
      finally
      {
        Reset();
      }
    }

    public void Rollback()
    {
      try
      {
        UnitOfWork.Rollback();
        State = IDbContextState.RolledBack;
      }
      finally
      {
        Reset();
      }
    }

    private IDbConnection OpenConnection()
    {
      State = IDbContextState.Open;
      return _connectionFactory.GetOpenConnection();
    }

    private void Reset()
    {
      Connection?.Close();
      Connection?.Dispose();
      Transaction?.Dispose();

      _connection = null;
      _transaction = null;
      _unitOfWork = null;
    }
  }
}
