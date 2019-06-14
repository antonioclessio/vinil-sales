using VinilSales.Domain.ClienteContext.Models;
using VinilSales.Domain.ProdutoContext.Enum;

namespace VinilSales.Domain.ProdutoContext.Model
{
    public class ProdutoFiltroModel
    {
        public bool IsEmpty()
        {
            return Genero.HasValue == false
                && string.IsNullOrEmpty(Nome);
        }

        public GeneroEnum? Genero { get; set; }

        public string Nome { get; set; }

        public PaginacaoModel Paginacao { get; set; } = new PaginacaoModel();
    }
}
