using Microsoft.AspNetCore.Mvc;

namespace BufAppServer.Controllers;

[ApiController]
public class AppController : ControllerBase
{
    private readonly ILogger<AppController> _logger;
    public AppController(ILogger<AppController> logger)
    {
        _logger = logger;
    }
    
}