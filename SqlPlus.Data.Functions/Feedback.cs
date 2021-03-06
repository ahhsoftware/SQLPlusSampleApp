using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SqlPlus.Data.Models;
using System.IO;

/// <summary>
/// Using the class library in azure functions.
/// </summary>
namespace SqlPlus.Data.Functions
{
    public static class Feedback
    {
        [FunctionName(nameof(FeedbackById))]
        public static IActionResult FeedbackById(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Feedback/{feedbackId}")]
            HttpRequest req,
            int feedbackId,
            ILogger log)
        {
            //Create the input from the request parameter
            var input = new FeedbackByIdInput { FeedbackId = feedbackId };
            
            //validate
            if (!input.IsValid()) return new BadRequestObjectResult(input);
            
            //call service
            var output = ServiceFactory.DefaultService(log).FeedbackById(input);
            
            //record wasn't found - see dbo.FeedbackById
            if (output.ReturnValue == FeedbackByIdOutput.Returns.NotFound)
            {
                return new NotFoundResult();
            }

            //return the output
            return new OkObjectResult(output);
        }

        [FunctionName(nameof(FeedbackInsert))]
        public static IActionResult FeedbackInsert(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Feedback")]
            HttpRequest req,
            ILogger log)
        {
            //create the input from the request body
            var input = DeserializeBody<FeedbackInsertInput>(req);

            //no input returns bad request
            if (input == null)
            {
                return new BadRequestObjectResult($"Expecting Type {nameof(FeedbackInsertInput)} - no data received");
            }
            
            //invalid input returns a bad request and we are passing back the input with validation results
            if (!input.IsValid())
            {
                return new BadRequestObjectResult(input);
            }

            //call service passing input
            var output = ServiceFactory.DefaultService(log).FeedbackInsert(input);

            //return output
            return new OkObjectResult(output);
        }

        [FunctionName(nameof(FeedbackUpdate))]
        public static IActionResult FeedbackUpdate(
           [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "Feedback")]
            HttpRequest req,
           ILogger log)
        {
            //create the input from the request body
            var input = DeserializeBody<FeedbackUpdateInput>(req);

            //no input returns bad request
            if (input == null)
            {
                return new BadRequestObjectResult($"Expecting Type {nameof(FeedbackUpdateInput)} - no data received");
            }

            //invalid input returns a bad request and we are passing back the input with validation results
            if (!input.IsValid())
            {
                return new BadRequestObjectResult(input);
            }

            //call service passing input
            var output = ServiceFactory.DefaultService(log).FeedbackUpdate(input);

            if(output.ReturnValue == FeedbackUpdateOutput.Returns.NotFound)
            {
                return new NotFoundResult();
            }

            //return output
            return new OkObjectResult(output);
        }



        [FunctionName(nameof(FeedbackDelete))]
        public static IActionResult FeedbackDelete(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "Feedback/{feedbackId}")]
            HttpRequest req,
            int feedbackId,
            ILogger log)
        {
            //create the input from the request parameter
            var input = new FeedbackDeleteInput { FeedbackId = feedbackId };
            
            //validate
            if (!input.IsValid()) return new BadRequestObjectResult(input);

            //call service passing input
            var output = ServiceFactory.DefaultService(log).FeedbackDelete(input);

            //check the return value - notice the enumeration
            if(output.ReturnValue == FeedbackDeleteOutput.Returns.NotFound)
            {
                return new NotFoundResult();
            }

            //all good
            return new OkObjectResult(output);
        }

        [FunctionName(nameof(FeedbackPaged))]
        public static IActionResult FeedbackPaged(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Feedback/{page}/{size}")]
            HttpRequest req,
            int page,
            int size,
            ILogger log)
        {
            //create the input from the request parameter
            var input = new FeedbackPagedInput
            {
                PageNumber = page,
                PageSize = size
            };

            //validate
            if (!input.IsValid())
            {
                return new BadRequestObjectResult(input);
            };

            //call service passing input
            var result = ServiceFactory.DefaultService(log).FeedbackPaged(input);

            if(result.ReturnValue == FeedbackPagedOutput.Returns.NoRecords)
            {
                return new NotFoundObjectResult($"No records for page: {page} - size : {size}");
            }
            return new OkObjectResult(result);
        }

        private static T DeserializeBody<T>(HttpRequest req)
        {
            string body = null;
            using (StreamReader streamReader = new StreamReader(req.Body))
            {
                body = streamReader.ReadToEnd();
            }
            if(string.IsNullOrEmpty(body))
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(body);
        }
    }
}
