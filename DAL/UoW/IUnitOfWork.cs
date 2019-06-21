using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL.UoW
{
  public interface IUnitOfWork
  {
    IUnitOfWorkState State { get; }
    IDbTransaction Transaction { get; }
    void Commit();
    void Rollback();
  }

  public enum IUnitOfWorkState
  {
    Open,
    Commited,
    RolledBack
  }
}
