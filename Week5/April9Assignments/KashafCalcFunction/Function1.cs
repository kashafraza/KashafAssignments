using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace KashafCalcFunction;

public class Sum
{
    private readonly ILogger<Sum> _logger;

    public Sum(ILogger<Sum> logger)
    {
        _logger = logger;
    }

    [Function("Sum")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        int x = int.Parse(req.Query["x"]);
        int y = int.Parse(req.Query["y"]);
        int result = x + y;

        return new OkObjectResult(result);
    }
}