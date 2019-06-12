using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using VinilSales.Application.CoreContext.Base;
using VinilSales.Application.TabelaCashbackContext.Queries;
using VinilSales.Application.TabelaCashbackContext.Result;
using VinilSales.Repository.Domain.TabelaCashbackContext.Entities;
using VinilSales.Repository.Domain.TabelaCashbackContext.Interfaces;

namespace VinilSales.Application.TabelaCashbackContext.QueryHandlers
{
    public class ObterVigentePorGeneroQueryHandler : BaseHandler<ITabelaCashbackRepository>, IRequestHandler<ObterVigentePorGeneroQuery, ObterVigentePorGeneroResult>
    {
        public ObterVigentePorGeneroQueryHandler(IMediator mediator, ITabelaCashbackRepository repository) : base(mediator, repository) { }

        public override void ConfigureMapper()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TabelaCashback_ItemEntity, ObterVigentePorGeneroResult>();
            }).CreateMapper();
        }
        public async Task<ObterVigentePorGeneroResult> Handle(ObterVigentePorGeneroQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.ObterTabelaVigentePorGenero(request.Genero);
            return _mapper.Map<ObterVigentePorGeneroResult>(result);
        }
    }
}
