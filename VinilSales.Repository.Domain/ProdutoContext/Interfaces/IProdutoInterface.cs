using System.Collections.Generic;
using System.Threading.Tasks;
using VinilSales.Domain.ProdutoContext.Model;
using VinilSales.Repository.Domain.CoreContext.Interfaces;
using VinilSales.Repository.Domain.ProdutoContext.Entities;

namespace VinilSales.Repository.Domain.ProdutoContext.Interfaces
{
    public interface IProdutoRepository : IRepository<ProdutoEntity>
    {
        Task<List<ProdutoEntity>> ObterPorFiltro(ProdutoFiltroModel filtro);
        Task<bool> AdicionarLista(List<ProdutoEntity> list);
    }
}
