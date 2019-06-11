using VinilSales.Repository.Domain.TabelaCashbackContext.Entities;

namespace VinilSales.Repository.Domain.TabelaCashbackContext.Interfaces
{
    public interface ITabelaCashbackRepository
    {
        TabelaCashbackEntity ObterTabelaVigente();
    }
}
