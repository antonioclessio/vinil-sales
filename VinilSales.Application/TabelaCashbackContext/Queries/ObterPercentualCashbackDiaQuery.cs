using MediatR;
using VinilSales.Domain.ProdutoContext.Enum;

namespace VinilSales.Application.TabelaCashbackContext.Queries
{
    public class ObterPercentualCashbackDiaQuery : IRequest<decimal>
    {
        public ObterPercentualCashbackDiaQuery(GeneroEnum genero)
        {
            this.Genero = genero;
        }

        public GeneroEnum Genero { get; set; }
    }
}
