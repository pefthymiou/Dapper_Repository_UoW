﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL.ConnectionFactory
{
  public interface IDbConnectionFactory
  {
    IDbConnection GetOpenConnection();
  }
}
