namespace Compras_API_dot_net_core.Model
{
    public class ProdutoModel
    {
        public ProdutoModel()
        {
        }

        public ProdutoModel(int id, string nome, decimal valor, int estoque)
        {
            this.id = id;
            this.nome = nome;
            this.valor = valor;
            this.estoque = estoque;
        }

        public int id { get; set; }
        public string? nome { get; set; }
        public decimal valor { get; set; }
        public int estoque { get; set; }
        public DateTime? dataUltimaVenda { get; set; }
        public decimal valorUltimaVenda { get; set; }
    }
}
