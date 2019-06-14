using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinilSales.Domain.PedidoContext.Model;
using VinilSales.Repository.CoreContext.Base;
using VinilSales.Repository.Domain.PedidoContext.Entities;
using VinilSales.Repository.Domain.PedidoContext.Interfaces;
using VinilSales.Repository.PedidoContext.DbContexts;

namespace VinilSales.Repository.PedidoContext.Repository
{
    public class PedidoRepository : BaseRepository<PedidoDbContext>, IPedidoRepository
    {
        public PedidoRepository(PedidoDbContext context)
            : base(context)
        {
        }

        public Task<bool> AdicionarItem(Pedido_ItemEntity model)
        {
            _dbContext.Pedido_Item.Add(model);
            return Task.FromResult(_dbContext.SaveChanges() > 0);
        }

        public async Task<bool> FinalizarPedido(int idPedido)
        {
            var entity = await ObterPorId(idPedido);
            _dbContext.Entry(entity).State = EntityState.Modified;

            entity.Finalizar();

            return _dbContext.SaveChanges() > 0;
        }

        public Task<int> CriarPedido(PedidoEntity model)
        {
            _dbContext.Add(model);

            model.Itens.ForEach(item => _dbContext.Add(item));
            _dbContext.SaveChanges();

            return Task.FromResult(model.IdPedido);
        }

        public Task<PedidoEntity> ObterPorId(int idPedido)
        {
            var entity = _dbContext.Pedido.Include(a => a.Itens).FirstOrDefault(a => a.IdPedido == idPedido);
            return Task.FromResult(entity);
        }

        public Task<List<PedidoEntity>> ObterPorFiltro(PedidoFiltroModel filtro)
        {
            var listEntity = _dbContext.Pedido
                                       .Where(a =>
                                           filtro.IdCliente.HasValue == false || a.IdCliente == filtro.IdCliente
                                       )
                                       .Skip(filtro.Paginacao.Pagina * filtro.Paginacao.TotalRegistrosPorPagina)
                                       .Take(filtro.Paginacao.TotalRegistrosPorPagina)
                                       .ToList();
            return Task.FromResult(listEntity);
        }

        public async Task<bool> CancelarPedido(int idPedido)
        {
            var entity = await ObterPorId(idPedido);
            _dbContext.Entry(entity).State = EntityState.Modified;

            entity.Finalizar();

            return _dbContext.SaveChanges() > 0;
        }
    }
}
