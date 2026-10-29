using Microsoft.AspNetCore.Http;

namespace tests
{
    public static class TestFactory
    {
        public static HttpRequest CreateHttpRequest()
        {
            var context = new DefaultHttpContext();
            context.Request.Method = "GET";
            return context.Request;
        }

        public static ListLogger<T> CreateLogger<T>() => new ListLogger<T>();
    }
}
