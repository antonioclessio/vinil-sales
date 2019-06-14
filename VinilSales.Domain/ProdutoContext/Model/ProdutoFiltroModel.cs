using VinilSales.Domain.ClienteContext.Models;
using VinilSales.Domain.ProdutoContext.Enum;

namespace VinilSales.Domain.ProdutoContext.Model
{
    public class ProdutoFiltroModel
    {
        public bool IsEmpty()
        {
            return Genero.HasValue == false;
        }

        public GeneroEnum? Genero { get; set; }

        public PaginacaoModel Paginacao { get; set; } = new PaginacaoModel();
    }
}
