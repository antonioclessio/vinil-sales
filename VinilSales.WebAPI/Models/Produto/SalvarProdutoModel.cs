namespace VinilSales.WebAPI.Models.Produto
{
    public class SalvarProdutoModel
    {
        public decimal Preco { get; set; }

        public string Nome { get; set; }

        public byte Genero { get; set; }

        public string Artista { get; set; }
    }
}
