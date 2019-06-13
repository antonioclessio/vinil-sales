using System.Collections.Generic;
using System.Threading.Tasks;
using VinilSales.Domain.CoreContext.ValueObjects;
using VinilSales.Repository.Domain.ClienteContext.Entities;
using VinilSales.Repository.Domain.CoreContext.Interfaces;

namespace VinilSales.Repository.Domain.ClienteContext.Interfaces
{
    public interface IClienteRepository : IRepository<ClienteEntity>
    {
        Task<ClienteEntity> ObterPorCPF(CPF cpf);
        Task<bool> RegistrarTransacaoCashback(Cliente_TransacaoEntity model);
        Task<List<Cliente_TransacaoEntity>> ObterExtratoPorCliente(int idCliente);
    }
}
