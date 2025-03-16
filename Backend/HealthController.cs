using Microsoft.AspNetCore.Mvc;

namespace Backend;

[ApiController]
[Route("api/heath")]
public class HealthController
{
    [HttpGet]
    public async Task<string> Health()
    {
        return "OK";
    }
}