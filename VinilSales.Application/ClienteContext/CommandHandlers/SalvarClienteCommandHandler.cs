using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.ClienteContext.Commands;
using VinilSales.Application.CoreContext.CommandHandlers;
using VinilSales.Domain.CoreContext.Interfaces;
using VinilSales.Repository.Domain.ClienteContext.Entities;
using VinilSales.Repository.Domain.ClienteContext.Interfaces;

namespace VinilSales.Application.ClienteContext.CommandHandlers
{
    public class SalvarClienteCommandHandler : BaseHandler<IClienteRepository>, IRequestHandler<SalvarClienteCommand, bool>
    {
        public SalvarClienteCommandHandler(IValidationMessage validation, IMediator mediator, IClienteRepository repository)
            : base(validation, mediator, repository)
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
            if (novoCliente.Invalido)
            {
                _validation.AddRange(novoCliente.Mensagens);
                return false;
            }

            var clienteExistente = _repository.ObterPorCPF(request.CPF);
            if (clienteExistente != null) { return false; }
            
            await _repository.Salvar(novoCliente);
            return true;
        }
    }
}
