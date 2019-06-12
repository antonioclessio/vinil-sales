using System.Threading.Tasks;
using VinilSales.Domain.ProdutoContext.Enum;
using VinilSales.Repository.Domain.TabelaCashbackContext.Entities;

namespace VinilSales.Repository.Domain.TabelaCashbackContext.Interfaces
{
    public interface ITabelaCashbackRepository
    {
        Task<TabelaCashbackEntity> ObterTabelaVigente();
        Task<TabelaCashback_ItemEntity> ObterTabelaVigentePorGenero(GeneroEnum genero);
    }
}
