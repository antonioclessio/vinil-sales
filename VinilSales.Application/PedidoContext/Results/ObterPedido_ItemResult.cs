namespace VinilSales.Application.PedidoContext.Results
{
    public class ObterPedido_ItemResult
    {
        public int PedidoItem { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
        public decimal PercentualCashback { get; set; }
        public decimal ValorCashback { get; set; }
    }
}
