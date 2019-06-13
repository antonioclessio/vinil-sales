using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.ClienteContext.Commands;
using VinilSales.Application.CoreContext.Base;
using VinilSales.Repository.Domain.ClienteContext.Entities;
using VinilSales.Repository.Domain.ClienteContext.Interfaces;

namespace VinilSales.Application.ClienteContext.CommandHandlers
{
    public class RegistrarTransacaoCashbackCommandHandler : BaseHandler<IClienteRepository>, IRequestHandler<RegistrarTransacaoCashbackCommand, bool>
    {
        public RegistrarTransacaoCashbackCommandHandler(IMediator mediator, IClienteRepository repository)
            : base(mediator, repository)
        {

        }

        public override void ConfigureMapper()
        {
            _mapper = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<RegistrarTransacaoCashbackCommand, Cliente_TransacaoEntity>();
            }).CreateMapper();
        }

        public async Task<bool> Handle(RegistrarTransacaoCashbackCommand request, CancellationToken cancellationToken)
        {
            var novaTransacao = _mapper.Map<Cliente_TransacaoEntity>(request);
            if (!novaTransacao.IsValid()) { return false; }

            var result = await _repository.RegistrarTransacaoCashback(novaTransacao);
            return result;
        }
    }
}
