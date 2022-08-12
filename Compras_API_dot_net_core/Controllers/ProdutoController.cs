using Compras_API_dot_net_core.Data;
using Compras_API_dot_net_core.Model;
using Compras_API_dot_net_core.Objeto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Compras_API_dot_net_core.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ProdutoController(ApiDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insere o produto com os parametros passados.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        public IActionResult InsereProduto([FromBody] Produto data)
        {          

            try
            {
                if (data.valor_unitario < 1 || data.qtde_estoque < 1 || data.nome.Equals(""))
                {
                    return StatusCode(412, "Os valores informados não são válidos");
                }

                var ultimoProduto = _context.Produtos.OrderByDescending(p => p.id).FirstOrDefault();
                var index = 1;

                if (ultimoProduto != null)
                {
                    index = ultimoProduto.id + 1;
                }

                ProdutoModel produto = new ProdutoModel(
                    index,
                    data.nome,
                    data.valor_unitario,
                    data.qtde_estoque
                    );

                _context.Produtos.Add(produto);
                _context.SaveChanges();

                return Ok("Produto Cadastrado");
            }
            catch (Exception ex)
            {
                return NotFound("Ocorreu um erro desconhecido");
            }
        }

        /// <summary>
        /// Lista todos os produtos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Produto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarProdutos()
        { 

            try
            {
                var produtos = _context.Produtos.OrderBy(p => p.id).ToList();

                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return NotFound("Ocorreu um erro desconhecido");
            }

        }

        /// <summary>
        /// Busca um produto pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Produto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DetalharProduto(int id)
        {
            try
            {
                var produto = _context.Produtos.Where(p => p.id == id).Single();

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return NotFound("Ocorreu um erro desconhecido");
            }
        }

        /// <summary>
        /// Deleta um produto pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Produto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ExcluirProduto(int id)
        {
            try
            {
                _context.Produtos.Remove(_context.Produtos.Where(p => p.id == id).Single());
                _context.SaveChanges();

                return Ok("Produto excluído com sucesso");
            }
            catch(Exception ex)
            {
                return NotFound("Ocorreu um erro desconhecido");
            }   
        }
    }
}
