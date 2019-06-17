using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.ClienteContext.Commands;
using VinilSales.Application.CoreContext.CommandHandlers;
using VinilSales.Application.CoreContext.Interfaces;
using VinilSales.Repository.Domain.ClienteContext.Entities;
using VinilSales.Repository.Domain.ClienteContext.Interfaces;

namespace VinilSales.Application.ClienteContext.CommandHandlers
{
    public class RegistrarTransacaoCashbackCommandHandler : BaseHandler<IClienteRepository>, IRequestHandler<RegistrarTransacaoCreditoCashbackCommand, bool>
    {
        public RegistrarTransacaoCashbackCommandHandler(IValidationHandler validation, IMediator mediator, IClienteRepository repository)
            : base(validation, mediator, repository)
        {

        }

        public override void ConfigureMapper()
        {
            _mapper = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<RegistrarTransacaoCreditoCashbackCommand, Cliente_TransacaoEntity>();
            }).CreateMapper();
        }

        public async Task<bool> Handle(RegistrarTransacaoCreditoCashbackCommand request, CancellationToken cancellationToken)
        {
            var novaTransacao = new Cliente_TransacaoEntity(request.IdCliente, request.IdPedido, request.ValorPedido, request.ValorTransacao);
            if (!novaTransacao.IsValid()) { return false; }

            var result = await _repository.RegistrarTransacaoCashback(novaTransacao);
            return result;
        }
    }
}
