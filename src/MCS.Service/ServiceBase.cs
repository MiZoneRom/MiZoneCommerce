using System;
using System.Collections.Generic;
using System.Text;
using MCS.Core;
using Kogel.Dapper.Extension.MsSql;
using System.Data.SqlClient;

namespace MCS.Service
{
    public class ServiceBase
    {
        #region 字段
        private bool _useNoLazyNoProxyContext;
        private SqlConnection _connection;
        #endregion

        #region 属性
        protected SqlConnection Context
        {
            get
            {
                _connection = new SqlConnection(ConnectionString);
                return _connection;
            }
        }

        protected string ConnectionString
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings.GetSection("SqlServer").Value;
                return connectionString;
            }
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
            }
        }
        #endregion

    }
}
