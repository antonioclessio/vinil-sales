using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinilSales.Domain.CoreContext.ValueObjects;
using VinilSales.Repository.ClienteContext.DbContexts;
using VinilSales.Repository.CoreContext.Base;
using VinilSales.Repository.Domain.ClienteContext.Entities;
using VinilSales.Repository.Domain.ClienteContext.Interfaces;

namespace VinilSales.Repository.ClienteContext.Repository
{
    public class ClienteRepository : BaseRepository<ClienteDbContext>, IClienteRepository
    {
        public ClienteRepository(ClienteDbContext context)
            : base(context)
        {
            adicionarDadosMock();
        }

        private void adicionarDadosMock()
        {
            if (_dbContext.Cliente.ToList().Count() > 0) { return; }

            _dbContext.Cliente.Add(new ClienteEntity
            {
                IdCliente = 1,
                CPF = "38093208038",
                Nome = "Antônio Cléssio"
            });

            _dbContext.SaveChanges();
        }

        public Task<ClienteEntity> ObterPorId(int id)
        {
            return Task.FromResult(_dbContext.Cliente.FirstOrDefault(a => a.IdCliente == id));
        }

        public Task<ClienteEntity> ObterPorCPF(CPF cpf)
        {
            return Task.FromResult(_dbContext.Cliente.FirstOrDefault(a => a.CPF == cpf));
        }

        public Task<List<ClienteEntity>> ObterTodos()
        {
            var result = _dbContext.Cliente.ToList();
            return Task.FromResult(result);
        }

        public Task<bool> Remover(int key)
        {
            var entity = _dbContext.Cliente.FirstOrDefault(a => a.IdCliente == key);
            if (entity == null) return Task.FromResult(false);

            _dbContext.Cliente.Remove(entity);

            return Task.FromResult(_dbContext.SaveChanges() > 0);
        }

        public Task<bool> Salvar(ClienteEntity model)
        {
            if (model.IdCliente == 0)
            {
                return Task.FromResult(Inserir(model));
            }
            else
            {
                return Task.FromResult(Atualizar(model));
            }
        }

        private bool Inserir(ClienteEntity model)
        {
            _dbContext.Cliente.Add(model);
            return _dbContext.SaveChanges() > 0;
        }

        private bool Atualizar(ClienteEntity model)
        {
            model.RegistrarAlteracao();

            _dbContext.Entry(model).State = EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }

        public Task<bool> RegistrarTransacaoCashback(Cliente_TransacaoEntity model)
        {
            _dbContext.Cliente_Transacao.Add(model);
            return Task.FromResult(_dbContext.SaveChanges() > 0);
        }

        public Task<List<Cliente_TransacaoEntity>> ObterExtratoPorCliente(int idCliente)
        {
            var result = _dbContext.Cliente_Transacao.Where(a => a.IdCliente == idCliente).ToList();
            return Task.FromResult(result);
        }
    }
}
