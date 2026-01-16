using Microsoft.AspNetCore.Mvc;

namespace FCG.API.Controllers;

[ApiController]
[Route("api/usuarios")]
public class UsuarioController : ControllerBase
{
    private readonly ILogger<UsuarioController> _logger;
    
    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<string>>> Listar()
    {
        await Task.Delay(100);
        
        //Sempre usar paginação em listas
        //Ver melhor forma de padronizar sem restringir

        List<string> lista = ["1", "2", "3"];
        return Ok(lista);
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<string>> Obter(Guid id)
    {
        await Task.Delay(100);
        
        return Ok($"Usuário com id '{id}'");
    }

    [HttpPatch("{id:guid}/perfil-usuario")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> AlterarPerfilUsuario()
    {
        await Task.Delay(100);
        
        return NoContent();
    }
    
    
    
    // [HttpPost]
    // public async Task<ActionResult<Guid>> Criar()
    // {
    //     await Task.Delay(100);
    //     
    //     Guid id = Guid.NewGuid();
    //     string uri = Url.Action(nameof(Obter), new { id })!;
    //     
    //     return Created(uri, id);
    // }
    //
    // //Não teremos DELETE, mas sempre que não tiver resposta na requisição, deve retorno NoContent
    // [HttpDelete]
    // public async Task<ActionResult> Apagar()
    // {
    //     await Task.Delay(100);
    //     
    //     return NoContent();
    // }
    //
    // [HttpGet("Teste")]
    // public ActionResult<string> Teste()
    // {
    //     return Ok(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
    // }
    //
    // [HttpGet("Erro")]
    // public ActionResult<string> Erro()
    // {
    //     _logger.LogInformation("Iniciando no método");
    //     _logger.LogInformation("Pagamento confirmado");
    //     _logger.LogInformation("Enviando e-mail de validação");
    //     
    //     throw new ConflictException("E-mail já cadastrado");
    // }
}