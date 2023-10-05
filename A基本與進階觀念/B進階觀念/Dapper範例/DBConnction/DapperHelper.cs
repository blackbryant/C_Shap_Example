using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace B進階觀念.Dapper範例.DBConnction
{
    public class DapperHelper
    {
        static IDbConnection _dbConnction = new SqlConnection();
        public string ConnectString => ConnectionOptions.GetConnectionString();

        public DapperHelper() 
        {
            _dbConnction.ConnectionString= ConnectString;
        }

        /// <summary>
        /// /
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">sql語句</param>
        /// <param name="param">參數</param>
        /// <param name="transaction">事務</param>
        /// <param name="timeout"超時時間></param>
        /// <param name="commandType">command類型</param>
        /// <returns></returns>
        public T QueryFirst<T>(string sql, object param = null, IDbTransaction transaction=null ,  int? timeout = null, CommandType? commandType=null) 
        {
    
            return _dbConnction.QueryFirst<T>(sql, param,transaction,  timeout,  commandType  );
        }

        /// <summary>
        /// 多個查詢
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">sql語句</param>
        /// <param name="param">參數</param>
        /// <param name="transaction">事務</param>
        /// <param name="buffered">緩沖</param>
        /// <param name="timeout"超時時間></param>
        /// <param name="commandType">command類型</param>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction? transaction = null, bool buffered = true, int? timeout =300, CommandType? commandType = null)
        {

            return _dbConnction.Query<T>(sql, param, transaction, buffered, timeout, commandType);
        }

        /// <summary>
        /// 執行sql
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">sql語句</param>
        /// <param name="param">參數</param>
        /// <param name="transaction">事務</param>
        /// <param name="timeout"超時時間></param>
        /// <param name="commandType">command類型</param>
        /// <returns></returns>
        public int Execute<T>(string sql, object param = null, IDbTransaction transaction = null, int? timeout = null,  CommandType? commandType = null)
        {

            return _dbConnction.Execute(sql, param, transaction, timeout, commandType);
        }



    }
}
