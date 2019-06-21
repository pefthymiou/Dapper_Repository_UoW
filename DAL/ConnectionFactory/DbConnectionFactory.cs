using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL.ConnectionFactory
{
  public class DbConnectionFactory : IDbConnectionFactory
  {
    private readonly Func<IDbConnection> _connectionFactory;

    public DbConnectionFactory(Func<IDbConnection> connectionFactory)
    {
      _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
    }
    public IDbConnection GetOpenConnection()
    {
      return _connectionFactory();
    }
  }
}
