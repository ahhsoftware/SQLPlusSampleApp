// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by SqlPlus.net
//     For more information on SqlPlus.net visit http://www.SqlPlus.net
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using System;
using System.Data.SqlClient;
using SqlPlus.Data.Default.Models;

namespace SqlPlus.Data.Default
{
    /// <summary>
    /// This partial class for routines provides utility methods utilized by all the routine specific partials.
    /// </summary>
    public partial class Service
    {
        private readonly string connectionString;
        private readonly IRetryOptions retryOptions;
        private readonly SqlConnection sqlConnection;
        private readonly SqlTransaction sqlTransaction;

        /// <summary>
        /// Creates a new SQL+ .NET service object that will connect to the database using the connection string provided.
        /// Optionally a RetryOptions object may be passed. Note that the retry options may also take an option transient error logger.
        /// </summary>
        /// <param name="connectionString">Connection String to the relevant database with appropriate credentials and settings.</param>
        /// <param name="retryOptions">Object implementing the IRetryOptions interface. If left null no retries will execute.</param>
        public Service(string connectionString, IRetryOptions retryOptions = null)
        {
            this.connectionString = connectionString;
            this.retryOptions = retryOptions == null ? new NoRetryOptions(): retryOptions;
        }

        /// <summary>
        /// Creates a new SQL+ .NET service object that allows the developer control of the connection and transactions.
        /// User is responsible for connection and transaction management.
        /// </summary>
        /// <param name="sqlConnection">Ready to execute SqlConnection</param>
        /// <param name="sqlTransaction">Ready to execute SqlTransaction</param>
        public Service(SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            if (sqlConnection == null)
            {
                throw new ArgumentNullException(nameof(sqlConnection));
            }
            if (sqlTransaction == null)
            {
                throw new ArgumentNullException(nameof(sqlTransaction));
            }
            this.sqlConnection = sqlConnection;
            this.sqlTransaction = sqlTransaction;
        }
    }
}