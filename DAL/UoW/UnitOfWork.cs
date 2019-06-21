using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL.UoW
{
  public class UnitOfWork : IUnitOfWork
  {
    public IUnitOfWorkState State { get; private set; }

    public IDbTransaction Transaction { get; private set; }

    public UnitOfWork(IDbTransaction transaction)
    {
      State = IUnitOfWorkState.Open;
      Transaction = transaction;
    }

    public void Commit()
    {
      try
      {
        Transaction.Commit();
        State = IUnitOfWorkState.Commited;
      }
      catch (Exception)
      {
        Transaction.Rollback();
        throw;
      }
    }

    public void Rollback()
    {
      Transaction.Rollback();
      State = IUnitOfWorkState.RolledBack;
    }
  }
}
