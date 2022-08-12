using Compras_API_dot_net_core.Model;
using Microsoft.EntityFrameworkCore;

namespace Compras_API_dot_net_core.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
            AdicionarDadosTeste(this);
        }

        public DbSet<ProdutoModel> Produtos { get; set; }

        //informacao apenas para testes
        private void AdicionarDadosTeste(ApiDbContext context)
        {

            var ultimoProduto = this.Produtos.OrderByDescending(p => p.id).FirstOrDefault();

            if (ultimoProduto == null)
            {

                var testeProduto1 = new ProdutoModel
                {
                    id = 1,
                    nome = "Produto 1",
                    valor = 10,
                    estoque = 100
                };
                context.Produtos.Add(testeProduto1);

                var testeProduto2 = new ProdutoModel
                {
                    id = 2,
                    nome = "Produto 2",
                    valor = 5,
                    estoque = 150
                };
                context.Produtos.Add(testeProduto2);

                context.SaveChanges();
            }
        }


    }
}
