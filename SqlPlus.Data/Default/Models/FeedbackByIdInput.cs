// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by SqlPlus.net
//     For more information on SqlPlus.net visit http://www.SqlPlus.net
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SqlPlus.Data.Default.Models
{
    /// <summary>
    /// Interface for FeedbackByIdInput object.
    /// </summary>
    public interface IFeedbackByIdInput : IValidInput
    {
        int? FeedbackId { set; get; }
    }

    /// <summary>
    /// Input object for FeedbackById method.
    /// </summary>
    public class FeedbackByIdInput : ValidInput, IFeedbackByIdInput
    {
        /// <summary>
        /// FeedbackId
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public int? FeedbackId { set; get; }

    }
} 