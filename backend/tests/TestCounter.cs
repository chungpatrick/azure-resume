using Company.Function;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace tests
{
    public class TestCounter
    {
        [Fact]
        public void Http_trigger_should_increment_counter()
        {
            var logger = TestFactory.CreateLogger<GetResumeCounter>();
            var function = new GetResumeCounter(logger);
            var counter = new Counter { Id = "1", Count = 2 };

            var response = function.Run(TestFactory.CreateHttpRequest(), counter);

            Assert.Equal(3, response.UpdatedCounter.Count);
            var ok = Assert.IsType<OkObjectResult>(response.HttpResponse);
            Assert.Equal(3, Assert.IsType<Counter>(ok.Value).Count);
            Assert.Contains("C# HTTP trigger function processed a request.", logger.Logs);
        }
    }
}
