using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataException = Harbin.Common.Database.DataException;

namespace AdventureWorks.Business.Entities
{
    partial class AdventureWorksDB
    {
        #region CreateConnection

        /// <summary>
        /// Creates a raw SqlConnection to the database. This is NOT for using Entity Framework, but Dapper or raw ADO.NET.
        /// Don't forget to wrap your connection inside a "using" statement, to automatically close/dispose connection at end:
        /// using (var cn = new AdventureWorksDB().CreateConnection())
        /// {
        ///    ...
        /// }
        /// </summary>
        /// <returns></returns>
        public System.Data.SqlClient.SqlConnection CreateConnection()
        {
            string cnStr = this.Database.Connection.ConnectionString;
            var cn = new System.Data.SqlClient.SqlConnection(cnStr);
            cn.Open();
            return cn;
        }
        #endregion

        #region Dapper Wrappers
        /// <summary>
        /// Execute parameterized SQL
        /// </summary>
        /// <returns>Number of rows affected</returns>
        public int Execute(string sql, object parms = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            using (var cn = this.CreateConnection())
            {
                //DB.SetConnectionUser(cn, sql);
                try
                {
                    return cn.Execute(sql, parms, transaction, commandTimeout, commandType);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw DataException.WrapSqlException(ex, sql, parms);
                }
            }
        }
        /// <summary>
        ///  Executes a query, returning the data typed as per T
        /// </summary>
        /// <returns>
        /// A sequence of data of the supplied type; if a basic type (int, string, etc) is
        ///  queried then the data from the first column in assumed, otherwise an instance
        ///  is created per row, and a direct column-name===member-name mapping is assumed
        ///  (case insensitive).
        /// </returns>
        public IEnumerable<T> Query<T>(string sql, object parms = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            using (var cn = this.CreateConnection())
            {
                //DB.SetConnectionUser(cn, sql);
                try
                {
                    return cn.Query<T>(sql, parms, transaction, buffered, commandTimeout, commandType);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw DataException.WrapSqlException(ex, sql, parms);
                }
            }
        }

        /// <summary>
        ///  Return a sequence of dynamic objects      <para /> 
        ///  Example:
        ///  var students = DB.Query("SELECT * FROM Students");
        ///  foreach(var student in students) Response.WriteLine(student.FirstName);  <para /> 
        ///  var enrollments = DB.Query("SELECT * FROM Enrollments WHERE StudentIndex=@sid", new { sid = 1 } );  etc..
        /// </summary>
        public IEnumerable<dynamic> Query(string sql, object parms = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            using (var cn = this.CreateConnection())
            {
                //DB.SetConnectionUser(cn, sql);
                try
                {
                    return cn.Query(sql, parms, transaction, buffered, commandTimeout, commandType);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw DataException.WrapSqlException(ex, sql, parms);
                }
            }
        }



        /// <summary>
        /// Inserts a record into the table and returns a single identity key generated for the insert. <para /> 
        /// Usage: 
        /// int userIndex = DB.Insert("INSERT INTO Users (UserName, FirstName, LastName) VALUES (@UserName, @FirstName, @LastName)", new { UserName="etc", FirstName="etc", LastName="etc"  });          <para /> 
        /// The @@IDENTITY (actually SCOPE_IDENTITY()) will be automatically added.
        /// </summary>
        /// <returns></returns>
        public int Insert(string sql, object parms, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            using (var conn = this.CreateConnection())
            {
                //DB.SetConnectionUser(cn, sql);
                try
                {
                    return conn.Query<int>(sql + "; SELECT SCOPE_IDENTITY();", parms, transaction, buffered, commandTimeout, commandType).Single();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw DataException.WrapSqlException(ex, sql, parms);
                }
            }
        }

        /// <summary>
        /// Updates one or more records, and returns the number of affected records.          <para />
        /// Usage: 
        /// int updatedRecords = DB.Update("UPDATE Users SET UserName=@UserName WHERE UserIndex=@UserIndex", new { UserName="etc", UserIndex=1  });
        /// </summary>
        public int Update(string sql, object parms, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            return this.Execute(sql, parms, transaction, commandTimeout, commandType);
        }


        #endregion

    }


}
