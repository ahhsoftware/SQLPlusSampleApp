using System;
using System.ComponentModel.DataAnnotations;
using SqlPlus.Data;

namespace SqlPlusDemo.Tests
{
    public class Utilities
    {
        /// <summary>
        /// SQL+.NET - simply writing out the errors to the console
        /// </summary>
        public static void WriteValidationErrors(SqlPlus.Data.Models.IValidInput input)
        {
            foreach (ValidationResult vr in input.ValidationResults)
            {
                Console.WriteLine(vr.ErrorMessage);
            }
        }

        /// <summary>
        /// SQL+.NET - simply writing out the errors to the console
        /// </summary>
        public static void WriteValidationErrors(SqlPlus.Data.SampleNamespace.Models.IValidInput input)
        {
            foreach (ValidationResult vr in input.ValidationResults)
            {
                Console.WriteLine(vr.ErrorMessage);
            }
        }

    }
}
