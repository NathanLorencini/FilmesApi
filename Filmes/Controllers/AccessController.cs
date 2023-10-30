using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.Controllers;


[ApiController]
[Route("[controller]")]
public class AccessController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "MinAge")]
    public IActionResult Get()
    {
        return Ok("Authorized access!");
    }
}