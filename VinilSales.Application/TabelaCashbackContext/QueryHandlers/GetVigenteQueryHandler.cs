using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.CoreContext.Base;
using VinilSales.Application.TabelaCashbackContext.Queries;
using VinilSales.Application.TabelaCashbackContext.Result;
using VinilSales.Repository.Domain.TabelaCashbackContext.Entities;
using VinilSales.Repository.Domain.TabelaCashbackContext.Interfaces;

namespace VinilSales.Application.TabelaCashbackContext.QueryHandlers
{
    public class GetVigenteQueryHandler : BaseHandler<ITabelaCashbackRepository>, IRequestHandler<GetVigenteQuery, GetVigenteResult>
    {
        public GetVigenteQueryHandler(IMediator mediator, ITabelaCashbackRepository repository) : base(mediator, repository) { }

        public override void ConfigureMapper()
        {
            _mapper = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<TabelaCashbackEntity, GetVigenteResult>();
                cfg.CreateMap<TabelaCashback_ItemEntity, GetVigente_ItensResult>();
            }).CreateMapper();
        }

        public async Task<GetVigenteResult> Handle(GetVigenteQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.ObterTabelaVigente();
            if (result == null) return null;

            return _mapper.Map<GetVigenteResult>(result);
        }
    }
}
