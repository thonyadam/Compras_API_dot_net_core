using Compras_API_dot_net_core.Objeto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Compras_API_dot_net_core.Controllers
{
    [Route("api/pagamento/compras")]
    [ApiController]
    public class PagementoController : ControllerBase
    {
        [HttpPost(Name = "CompraProduto")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult InsereProduto([FromBody] Pagamento data)
        {
            
            try
            {
                if (data.valor > 100) {
                    return Ok("APROVADO");
                }
                else
                {
                    return Ok("REJEITADO");
                }
                
            }
            catch (Exception ex)
            {
                return NotFound("Ocorreu um erro desconhecido");
            }

        }

    }
}
