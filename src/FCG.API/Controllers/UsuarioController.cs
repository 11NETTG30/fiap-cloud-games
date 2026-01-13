using Microsoft.AspNetCore.Mvc;

namespace FCG.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> Testar()
    {
        return Ok(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
    }
}