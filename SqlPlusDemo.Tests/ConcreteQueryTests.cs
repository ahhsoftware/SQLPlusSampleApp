using NUnit.Framework;
using SqlPlus.Data.SampleNamespace.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace SqlPlusDemo.Tests
{
    public class ConcreteQueryTests
    {
        [Test]
        public void HelloWorldTest()
        {
            var input = new HelloWorldInput { Name = "Alan" };
            
            if(input.IsValid())
            {
                var output = ServiceFactory.Sample().HelloWorld(input);
                Assert.IsTrue(output.ReturnValue == HelloWorldOutput.Returns.Ok);

                Console.WriteLine(output.ResultData.WelcomeMessage);

            }
            else
            {
                //Writing out the validation errors
                foreach(ValidationResult vr in input.ValidationResults)
                {
                    Console.WriteLine(vr.ErrorMessage);
                }
                Assert.Fail();
            }
        }

        [Test]
        public void FeedbackById()
        {
            var input = new FeedbackByIdInput
            {
                FeedbackId = 1
            };

            if (input.IsValid())
            {
                //Call the service to get the output object
                var output = ServiceFactory.Sample().FeedbackById(input);

                //The result data contains our single result.
                var record = output.ResultData;

                Console.WriteLine(record.Created);
                Console.WriteLine(record.Email);
                Console.WriteLine(record.FeedbackId);
                Console.WriteLine(record.FirstName);
                Console.WriteLine(record.LastName);
                Console.WriteLine(record.Message);
                Console.WriteLine(record.Subject);

                Assert.Pass();

            }
            else
            {
                //Writing out the validation errors
                Utilities.WriteValidationErrors(input);
                Assert.Fail();
            }
        }
    }
}
