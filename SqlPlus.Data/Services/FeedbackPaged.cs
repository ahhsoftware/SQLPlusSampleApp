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
        /// Builds the command object for FeedbackPaged method.
        /// </summary>
        /// <param name="cnn">The connection that will execute the procedure.</param>
        /// <param name="input">FeedbackPagedInput instance for loading parameter values.</param>
        /// <returns>SqlCommand ready for execution.</returns>
        private SqlCommand GetFeedbackPagedCommand(SqlConnection cnn, IFeedbackPagedInput input)
        {
            SqlCommand result = new SqlCommand()
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "[dbo].[FeedbackPaged]",
                Connection = cnn
            };

            result.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@PageSize",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Int,
                Scale = 0,
                Precision = 10,
				Value = input.PageSize
            });

            result.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@PageNumber",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Int,
                Scale = 0,
                Precision = 10,
				Value = input.PageNumber
            });

            result.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@PageCount",
                Direction = ParameterDirection.Output,
                SqlDbType = SqlDbType.Int,
                Scale = 0,
                Precision = 10,
                Value = DBNull.Value
            });

            result.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@ReturnValue",
                Direction = ParameterDirection.ReturnValue,
                SqlDbType = SqlDbType.Int,
                Scale = 0,
                Precision = 10,
                Value = DBNull.Value
            });

            return result;
        }
        private void SetFeedbackPagedCommandOutputs(SqlCommand cmd, FeedbackPagedOutput output)
        {
            if(cmd.Parameters[2].Value != DBNull.Value)
            {
                output.PageCount = (int?)cmd.Parameters[2].Value;
            }
            if(cmd.Parameters[3].Value != DBNull.Value)
            {
                output.ReturnValue = (FeedbackPagedOutput.Returns)cmd.Parameters[3].Value;
            }
        }

        private FeedbackPagedResult GetFeedbackPagedResultFromReader(SqlDataReader rdr)
        {
            FeedbackPagedResult result = new FeedbackPagedResult();

            result.FeedbackId = rdr.GetInt32(0);

            result.LastName = rdr.GetString(1);

            result.FirstName = rdr.GetString(2);

            result.Email = rdr.GetString(3);

            result.Subject = rdr.GetString(4);

            result.Message = rdr.GetString(5);

            result.Created = rdr.GetDateTime(6);

            return result;
        }


        private void FeedbackPagedCommand(SqlCommand cmd, FeedbackPagedOutput output)
        {
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                output.ResultData = new List<FeedbackPagedResult>();
                while(rdr.Read())
                {
                    output.ResultData.Add(GetFeedbackPagedResultFromReader(rdr));
                }
                rdr.Close();
            }
            SetFeedbackPagedCommandOutputs(cmd, output);
        }

        /// <summary>
        /// Selects page results from dbo.Feedback table.
        /// SQL+ Routine: dbo.FeedbackPaged - Authored by Alan Hyneman
        /// </summary>
        public FeedbackPagedOutput FeedbackPaged(IFeedbackPagedInput input, bool bypassValidation = false)
        {
            if(!bypassValidation)
            {
                if (!input.IsValid())
                {
		            throw new ArgumentException("FeedbackPagedInput fails validation - use the FeedbackPagedInput.IsValid() method prior to passing the input argument to the FeedbackPaged method.", "input");
                }
            }
            FeedbackPagedOutput output = new FeedbackPagedOutput();
			if(sqlConnection != null)
            {
                using (SqlCommand cmd = GetFeedbackPagedCommand(sqlConnection, input))
                {
                    cmd.Transaction = sqlTransaction;
                    FeedbackPagedCommand(cmd, output);
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
                    using (SqlCommand cmd = GetFeedbackPagedCommand(cnn, input))
                    {
                        cnn.Open();
						FeedbackPagedCommand(cmd, output);
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