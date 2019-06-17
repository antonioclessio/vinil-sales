using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.CoreContext.CommandHandlers;
using VinilSales.Application.TabelaCashbackContext.Queries;
using VinilSales.Application.TabelaCashbackContext.Result;
using VinilSales.Domain.CoreContext.Interfaces;
using VinilSales.Repository.Domain.TabelaCashbackContext.Entities;
using VinilSales.Repository.Domain.TabelaCashbackContext.Interfaces;

namespace VinilSales.Application.TabelaCashbackContext.QueryHandlers
{
    public class ObterVigenteQueryHandler : BaseHandler<ITabelaCashbackRepository>, IRequestHandler<ObterVigenteQuery, ObterVigenteResult>
    {
        public ObterVigenteQueryHandler(IValidationMessage validation, IMediator mediator, ITabelaCashbackRepository repository) 
            : base(validation, mediator, repository) { }

        public override void ConfigureMapper()
        {
            _mapper = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<TabelaCashbackEntity, ObterVigenteResult>();
                cfg.CreateMap<TabelaCashback_ItemEntity, ObterVigente_ItensResult>();
            }).CreateMapper();
        }

        public async Task<ObterVigenteResult> Handle(ObterVigenteQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.ObterTabelaVigente();
            if (result == null) return null;

            return _mapper.Map<ObterVigenteResult>(result);
        }
    }
}
