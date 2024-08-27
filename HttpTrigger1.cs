using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using NLog;

namespace Company.Function
{
    public class HttpTrigger1
    {
        private readonly ILogger<HttpTrigger1> _logger;
        private readonly Logger _nlogger;

        public HttpTrigger1(ILogger<HttpTrigger1> logger)
        {
            _logger = logger;
            _nlogger = LogManager.GetCurrentClassLogger();
            _nlogger.Info("Httptrigger constructor nlog");
        }

        [Function("HttpTrigger1")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            _nlogger.Info($"{req.Method} logged via nlog");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
