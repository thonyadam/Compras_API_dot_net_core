using Compras_API_dot_net_core.Objeto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Compras_API_dot_net_core.Controllers
{
    [Route("api/compras")]
    [ApiController]
    public class CompraController : ControllerBase
    {

        [HttpPost(Name = "CompraProduto")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)] //Os valores informados não são válidos
        public IActionResult InsereProduto([FromBody] Compra data)
        {
            
            try
            {
                return Ok("Venda realizada com sucesso");
            }
            catch (Exception ex)
            {
                return NotFound("Ocorreu um erro desconhecido");
            }

        }
    }
}
