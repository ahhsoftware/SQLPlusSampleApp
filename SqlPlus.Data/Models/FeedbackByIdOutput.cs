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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SqlPlus.Data.Models
{
    /// <summary>
    /// Output object for FeedbackById method.
    /// </summary>
    public partial class FeedbackByIdOutput
    {
        public enum Returns
        {
             NotFound = 0,
             Ok = 1
        }
		public Returns ReturnValue { set; get; }
        /// <summary>
        /// FeedbackByIdResult result.
        /// </summary>
        public FeedbackByIdResult ResultData { set; get; }
    }
}