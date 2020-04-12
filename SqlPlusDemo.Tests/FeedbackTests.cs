using NUnit.Framework;
using SqlPlus.Data.Models;
using System;

namespace SqlPlusDemo.Tests
{
    /// <summary>
    /// This class illustrates testing validation of inputs as well as execution of procedures.
    /// </summary>
    public class FeedbackTests
    {

        /// <summary>
        /// Illustrating dbo.FeedbackInsert
        /// </summary>
        [Test]
        [Order(1)]
        public void ValidInsert()
        {
            var input = new FeedbackInsertInput
            {
                Email = "Alan@SQLPLUS.net",
                FirstName = "Alan",
                LastName = "Hyneman",
                Message = "This is a message",
                Subject = "Thank is a subject"
            };
            if(input.IsValid())
            {
                //Call the service to get the output object
                var output = ServiceFactory.Data().FeedbackInsert(input);

                //We can test the return value against the enumeration for Inserted
                Assert.IsTrue(output.ReturnValue == FeedbackInsertOutput.Returns.Ok);

            }
            else
            {
                Utilities.WriteValidationErrors(input);
            }
        }

        /// <summary>
        /// Illustrating dbo.FeedbackTable (Single Row)
        /// </summary>
        [Test]
        [Order(2)]
        public void FeedbackTable()
        {
            var input = new FeedbackTableInput
            {
               FeedbackId = 1
            };

            if (input.IsValid())
            {
                //Call the service to get the output object
                var output = ServiceFactory.Data().FeedbackTable(input);

                //The result data contains our single result.
                var record = output.ResultData;

                //Writing out the individual properties (columns) of the result
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

        /// <summary>
        /// Illustrating dbo.FeedbackTableMulti (Multi Row)
        /// </summary>
        [Test]
        [Order(3)]
        public void FeedbackTableMulti()
        {
            var input = new FeedbackTableMultiInput
            {
                FeedbackId = 1
            };
            if(input.IsValid())
            {
                //Call the service to get the output object
                var output = ServiceFactory.Data().FeedbackTableMulti(input);

                //The result data contains our list of results (multi row)
                var records = output.ResultData;
                foreach(var record in records)
                {
                    //Writing out the individual properties (columns) of the result
                    Console.WriteLine(record.FeedbackId);
                    Console.WriteLine(record.LastName);
                }

                Assert.Pass();
            }
            else
            {
                //Writing out the validation errors
                Utilities.WriteValidationErrors(input);
                Assert.Fail();
            }
        }

        /// <summary>
        /// Illustrating dbo.FeedbackUpdateInput
        /// </summary>
        [Test]
        [Order(4)]
        public void ValidUpdate()
        {
            var input = new FeedbackUpdateInput
            {
                FeedbackId = 1,
                Email = "SomeoneElse@SQLPLUS.net",
                FirstName = "Someone",
                LastName = "Else",
                Message = "This is a different message",
                Subject = "A different subject"
            };
            if (input.IsValid())
            {
                //Call the service to get the output object
                var output = ServiceFactory.Data().FeedbackUpdate(input);

                //We can test the return value against the enumeration for Inserted
                Assert.IsTrue(output.ReturnValue == FeedbackUpdateOutput.Returns.Ok);

            }
            else
            {
                //Writing out the validation errors
                Utilities.WriteValidationErrors(input);
                Assert.Fail();
            }
        }

        /// <summary>
        /// Illustrating dbo.FeedbackInsertInput with null parameters
        /// </summary>
        [Test]
        [Order(5)]
        public void NullParameters()
        {
            var input = new FeedbackInsertInput
            {
                //Email = "Alan@SQLPLUS.net",
                //FirstName = "Alan",
                //LastName = "Hyneman",
                //Message = "So grateful for everyone providing feedback",
                //Subject = "Thank You"
            };

            //Expecting a failure
            Assert.IsTrue(input.IsValid() == false);

            Utilities.WriteValidationErrors(input);
        }

        /// <summary>
        /// Illustrating the Email tag, email is not valid but all required fields pass
        /// </summary>
        [Test]
        [Order(6)]
        public void InvalidEmail()
        {
            var input = new FeedbackInsertInput
            {
                Email = "ThisIsNotAnEmail",
                FirstName = "Alan",
                LastName = "Hyneman",
                Message = "So grateful for everyone providing feedback",
                Subject = "Thank You"
            };
            //Expecting a failure
            Assert.IsTrue(input.IsValid() == false);
            Utilities.WriteValidationErrors(input);
        }


        /// <summary>
        /// Illustrating dbo.FeedbackById
        /// </summary>
        [Test]
        [Order(7)]
        public void ById()
        {
            var input = new FeedbackByIdInput
            {
                FeedbackId = 1
            };
            if(input.IsValid())
            {
                //Call the service to get the output object
                var output = ServiceFactory.Data().FeedbackById(input);

                //We can test the return value against the enumeration for Ok
                Assert.IsTrue(output.ReturnValue == FeedbackByIdOutput.Returns.Ok);

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

        /// <summary>
        /// Illustrating a valid call for delete - we use the value from 
        /// the previously created record (1)
        /// </summary>
        [Test]
        [Order(8)]
        public void ValidDelete()
        {
            var input = new FeedbackDeleteInput
            {
                FeedbackId = 1
            };
            if(input.IsValid())
            {
                //Call the service to get the output object
                var output = ServiceFactory.Data().FeedbackDelete(input);

                //We can test the return value against the enumeration for Ok
                Assert.IsTrue(output.ReturnValue == FeedbackDeleteOutput.Returns.Ok);

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
