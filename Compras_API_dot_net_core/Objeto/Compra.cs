namespace Compras_API_dot_net_core.Objeto
{
    public class Compra
    {
        public int produto_id { get; set; }
        public int qtde_comprada { get; set; }
        public Cartao cartao { get; set; }
    }
}
