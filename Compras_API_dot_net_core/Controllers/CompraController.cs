using Compras_API_dot_net_core.Data;
using Compras_API_dot_net_core.Objeto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Compras_API_dot_net_core.Controllers
{
    [Route("api/compras")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public CompraController(ApiDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Realiza a compra do produto
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpPost(Name = "CompraProduto")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(string))]
        public IActionResult CompraProduto([FromBody] Compra data)
        {
            
            try
            {
                if (data.cartao.numero.Length != 16)
                {
                    return StatusCode(412,"Numero do cartao não tem 16 digitos");
                }

                var produto = _context.Produtos.Where(p => p.id == data.produto_id).Single();

                if (data.qtde_comprada > produto.estoque)
                {
                    return StatusCode(412, "Quantidade da compra maior que o estoque");
                }

                produto.estoque = produto.estoque - data.qtde_comprada;
                produto.valorUltimaVenda = produto.valor;
                produto.dataUltimaVenda = DateTime.Now;

                _context.Produtos.Update(produto);
                _context.SaveChanges();
                
                return Ok("Venda realizada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro desconhecido");
            }

        }
    }
}
