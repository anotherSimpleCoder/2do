using Microsoft.AspNetCore.Mvc;

namespace Backend;

[ApiController]
[Route("api/health")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public async Task<string> Health()
    {
        return "OK";
    }
}