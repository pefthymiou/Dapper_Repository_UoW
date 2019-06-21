using DAL.UoW;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL.Context
{
  public interface IDbContext
  {
    IDbContextState State { get; }
    IDbConnection Connection { get; }
    IDbTransaction Transaction { get; }
    IUnitOfWork UnitOfWork { get; }
    void Commit();
    void Rollback();
  }

  public enum IDbContextState
  {
    Closed,
    Open,
    Commited,
    RolledBack
  }
}
