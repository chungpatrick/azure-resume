using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public class GetResumeCounter
    {
        private readonly ILogger<GetResumeCounter> _logger;

        public GetResumeCounter(ILogger<GetResumeCounter> logger)
        {
            _logger = logger;
        }

        [Function("GetResumeCounter")]
        public CounterResponse Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDBInput(databaseName: "AzureResume", containerName: "Counter", Connection = "AZureResumeConnectionString", Id = "1", PartitionKey = "1")] Counter counter)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            //Here is where the counter is incremented. The updated counter is then returned to the client and written back to Cosmos DB.

            counter.Count += 1;

            return new CounterResponse
            {
                UpdatedCounter = counter,
                HttpResponse = new OkObjectResult(counter)
            };
        }
    }

    // In the isolated worker model, multiple outputs (HTTP response + Cosmos DB write)
    // are returned together from a single object.
    public class CounterResponse
    {
        [CosmosDBOutput(databaseName: "AzureResume", containerName: "Counter", Connection = "AZureResumeConnectionString")]
        public Counter UpdatedCounter { get; set; }

        [HttpResult]
        public IActionResult HttpResponse { get; set; }
    }
}
