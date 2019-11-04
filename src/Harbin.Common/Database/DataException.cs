using System;
using System.Collections.Generic;
using System.Text;

namespace Harbin.Common.Database
{

    #region DataException
    public class DataException : System.Exception
    {
        #region Members
        public string SqlQuery { get; set; }
        public object Parms { get; set; }
        #endregion
        protected DataException(string message, Exception innerException, string sqlQuery = null, object parms = null) : base(message, innerException)
        {
        }

        /// <summary>
        /// Wraps the SqlException, add contextual information (SqlQuery, parameter values), and then you should rethrow (do not swallow/ignore exceptions)
        /// According to the SQL error code, we can create a more meaningful message (parsing information from the DB error), which can later be translated by i18n
        /// </summary>
        /// <param name="ex"></param>
        public static DataException WrapSqlException(System.Data.SqlClient.SqlException ex, string sqlQuery = null, object parms = null)
        {
            // By default we keep the original SQL message
            string message = ex.Message;

            // According to the SQL error code, we can create a more meaningful message - see fields in https://stackoverflow.com/a/22126876/3606250 and codes in ...
            switch (ex.Errors[0].Number)
            {
                case 8134:
                    {
                        var match = System.Text.RegularExpressions.Regex.Match(ex.Message, "Msg 17001, Violation of Unique Key (<Constraint>)");
                        string constraint = match.Groups["Constraint"].Value;
                        //message = string.Format("[[[VIOLATION_UNIQUE_INDEX|||(((constraint)))]]"); // throw error with i18n-translatable message
                        //this.ViolatedConstraint = constraint //TODO: save this in logs - DataException.SaveToLog?
                        break;
                    }
                default:
                    break;
            }

            DataException wrappedException = new DataException(null, ex, sqlQuery, parms);
            return wrappedException;
        }
    }

    #endregion
}
