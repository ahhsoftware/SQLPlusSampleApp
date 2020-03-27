// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by SqlPlus.net
//     For more information on SqlPlus.net visit http://www.SqlPlus.net
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SqlPlus.Data.Models;

namespace SqlPlus.Data
{
    public partial class Service
    {

        /// <summary>
        /// Builds the command object for FeedbackTableMulti method.
        /// </summary>
        /// <param name="cnn">The connection that will execute the procedure.</param>
        /// <param name="input">FeedbackTableMultiInput instance for loading parameter values.</param>
        /// <returns>SqlCommand ready for execution.</returns>
        private SqlCommand GetFeedbackTableMultiCommand(SqlConnection cnn, IFeedbackTableMultiInput input)
        {
            SqlCommand result = new SqlCommand()
            {
                CommandType = CommandType.Text,
                CommandText = "SELECT * FROM [dbo].[FeedbackTableMulti](@FeedbackId)",
                Connection = cnn
            };

            result.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@FeedbackId",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Int,
                Scale = 0,
                Precision = 10,
				Value = (object)input.FeedbackId ?? DBNull.Value
            });

            return result;
        }

        private FeedbackTableMultiResult GetFeedbackTableMultiResultFromReader(SqlDataReader rdr)
        {
            FeedbackTableMultiResult result = new FeedbackTableMultiResult();

            if(!rdr.IsDBNull(0))
            {
                result.FeedbackId = rdr.GetInt32(0);
            }

            if(!rdr.IsDBNull(1))
            {
                result.LastName = rdr.GetString(1);
            }

            return result;
        }


        private void FeedbackTableMultiCommand(SqlCommand cmd, FeedbackTableMultiOutput output)
        {
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                output.ResultData = new List<FeedbackTableMultiResult>();
                while(rdr.Read())
                {
                    output.ResultData.Add(GetFeedbackTableMultiResultFromReader(rdr));
                }
                rdr.Close();
            }
        }

        /// <summary>
        /// Gets the record by id and the following record by id
        /// SQL+ Routine: dbo.FeedbackTableMulti - Authored by Alan Hyneman
        /// </summary>
        public FeedbackTableMultiOutput FeedbackTableMulti(IFeedbackTableMultiInput input, bool bypassValidation = false)
        {
            if(!bypassValidation)
            {
                if (!input.IsValid())
                {
		            throw new ArgumentException("FeedbackTableMultiInput fails validation - use the FeedbackTableMultiInput.IsValid() method prior to passing the input argument to the FeedbackTableMulti method.", "input");
                }
            }
            FeedbackTableMultiOutput output = new FeedbackTableMultiOutput();
			if(sqlConnection != null)
            {
                using (SqlCommand cmd = GetFeedbackTableMultiCommand(sqlConnection, input))
                {
                    cmd.Transaction = sqlTransaction;
                    FeedbackTableMultiCommand(cmd, output);
                }
                return output;
            }
            for(int idx=0; idx <= retryOptions.RetryIntervals.Count; idx++)
            {
                if(idx > 0)
                {
                    System.Threading.Thread.Sleep(retryOptions.RetryIntervals[idx-1]);
                }
                try
                {
                    using (SqlConnection cnn = new SqlConnection(connectionString))
                    using (SqlCommand cmd = GetFeedbackTableMultiCommand(cnn, input))
                    {
                        cnn.Open();
						FeedbackTableMultiCommand(cmd, output);
                        cnn.Close();
                    }
					break;
                }
                catch(SqlException sqlException)
                {
                    bool throwException = true;

                    if(retryOptions.TransientErrorNumbers.Contains(sqlException.Number))
                    {
                        throwException = (idx == retryOptions.RetryIntervals.Count);

                        if (retryOptions.Logger != null)
                        {
                            retryOptions.Logger.Log(sqlException);
                        }
                    }
                    if(throwException)
                    {
                        throw;
                    }
                }
            }
            return output;
        }
    }
}