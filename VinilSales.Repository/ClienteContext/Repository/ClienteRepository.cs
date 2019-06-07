using VinilSales.Repository.ClienteContext.DbContexts;
using VinilSales.Repository.CoreContext.Base;
using VinilSales.Repository.Domain.ClienteContext.Entities;
using VinilSales.Repository.Domain.ClienteContext.Interfaces;

namespace VinilSales.Repository.ClienteContext.Repository
{
    public class ClienteRepository : BaseRepository<ClienteDbContext>, IClienteRepository
    {
        public ClienteRepository(ClienteDbContext context) : base(context) {}

        public ClienteEntity GetByKeyAsync(int key)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(int key)
        {
            throw new System.NotImplementedException();
        }

        public bool Save(ClienteEntity model)
        {
            if (model.IdCliente == 0)
            {
                return Inserir(model);
            }
            else
            {
                return Atualizar(model);
            }
        }

        private bool Inserir(ClienteEntity model)
        {
            return false;
        }

        private bool Atualizar(ClienteEntity model)
        {
            return false;
        }
    }
}
