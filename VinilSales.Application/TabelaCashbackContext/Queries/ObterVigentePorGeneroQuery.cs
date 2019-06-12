using MediatR;
using VinilSales.Application.TabelaCashbackContext.Result;
using VinilSales.Domain.ProdutoContext.Enum;

namespace VinilSales.Application.TabelaCashbackContext.Queries
{
    public class ObterVigentePorGeneroQuery : IRequest<ObterVigentePorGeneroResult>
    {
        public ObterVigentePorGeneroQuery(GeneroEnum genero)
        {
            this.Genero = genero;
        }

        public GeneroEnum Genero { get; set; }
    }
}
