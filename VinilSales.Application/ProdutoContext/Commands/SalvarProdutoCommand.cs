using MediatR;

namespace VinilSales.Application.ProdutoContext.Commands
{
    public class SalvarProdutoCommand : IRequest<bool>
    {
        public SalvarProdutoCommand(decimal preco, string nome, byte genero, string artista)
        {
            this.Preco = preco;
            this.Nome = nome;
            this.Genero = genero;
            this.Artista = artista;
        }

        public SalvarProdutoCommand(int idProduto, decimal preco, string nome, byte genero, string artista)
        {
            this.IdProduto = idProduto;
            this.Preco = preco;
            this.Nome = nome;
            this.Genero = genero;
            this.Artista = artista;
        }

        public int IdProduto { get; set; }
        public decimal Preco { get; set; }
        public string Nome { get; set; }
        public byte Genero { get; set; }
        public string Artista { get; set; }
    }
}
