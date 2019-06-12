using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.ClienteContext.Commands;
using VinilSales.Application.CoreContext.Base;
using VinilSales.Repository.Domain.ClienteContext.Entities;
using VinilSales.Repository.Domain.ClienteContext.Interfaces;

namespace VinilSales.Application.ClienteContext.CommandHandlers
{
    public class SalvarClienteCommandHandler : BaseHandler<IClienteRepository>, IRequestHandler<SalvarClienteCommand, bool>
    {
        public SalvarClienteCommandHandler(IMediator mediator, IClienteRepository repository)
            : base(mediator, repository)
        {

        }

        public override void ConfigureMapper()
        {
            _mapper = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<SalvarClienteCommand, ClienteEntity>();
            }).CreateMapper();
        }

        public async Task<bool> Handle(SalvarClienteCommand request, CancellationToken cancellationToken)
        {
            var novoCliente = _mapper.Map<ClienteEntity>(request);
            if (!novoCliente.IsValid()) return false;

            await _repository.Salvar(novoCliente);
            return true;
        }
    }
}
