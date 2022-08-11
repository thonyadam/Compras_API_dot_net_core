using Compras_API_dot_net_core.Objeto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Compras_API_dot_net_core.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        [HttpPost(Name = "InserirProduto")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)] //Os valores informados não são válidos
        public IActionResult InsereProduto([FromBody] Produto data)
        {
            string nome = data.nome;

            try
            {
                return Ok("Produto Cadastrado");
            }
            catch (Exception ex)
            {
                return NotFound("Ocorreu um erro desconhecido");
            }
        }

        [HttpGet(Name = "ListarProdutos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Produto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult /*IEnumerable<Produto>*/ ListarProdutos()
        {

            List<Produto> produtos = new List<Produto>();

            try
            {
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return NotFound("Ocorreu um erro desconhecido");
            }

        }

        /*
        [HttpGet(Name = "DetalharProdutos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Produto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Produto DetalharProduto(int id)
        {
            Produto produto = new Produto();

            return produto;
        }*/

        [HttpDelete(Name ="DeletarProduto")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Produto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DetalharProduto(int id)
        {
            try
            {
                return Ok("Produto excluído com sucesso");
            }
            catch(Exception ex)
            {
                return NotFound("Ocorreu um erro desconhecido");
            }   
        }
    }
}
