// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by SqlPlus.net
//     For more information on SqlPlus.net visit http://www.SqlPlus.net
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
namespace SqlPlus.Data.SampleNamespace.Models
{
    /// <summary>
    /// Result object for FeedbackById routine.
    /// </summary>
    public partial class FeedbackByIdResult
	{
        public int FeedbackId { set; get; }
        public string LastName { set; get; }
        public string FirstName { set; get; }
        public string Email { set; get; }
        public string Subject { set; get; }
        public string Message { set; get; }
        public DateTime Created { set; get; }
    }
}