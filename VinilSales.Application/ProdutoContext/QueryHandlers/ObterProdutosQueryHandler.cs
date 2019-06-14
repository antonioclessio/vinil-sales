using MediatR;
using AutoMapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.CoreContext.Base;
using VinilSales.Application.ProdutoContext.Notifications;
using VinilSales.Application.ProdutoContext.Queries;
using VinilSales.Application.ProdutoContext.Results;
using VinilSales.Repository.Domain.ProdutoContext.Entities;
using VinilSales.Repository.Domain.ProdutoContext.Interfaces;

namespace VinilSales.Application.ProdutoContext.QueryHandlers
{
    public class ObterProdutosQueryHandler : BaseHandler<IProdutoRepository>, IRequestHandler<ObterProdutosQuery, IEnumerable<ObterProdutosResult>>
    {
        public ObterProdutosQueryHandler(IMediator mediator, IProdutoRepository repository) : base(mediator, repository) { }

        public override void ConfigureMapper()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProdutoEntity, ObterProdutosResult>();
            }).CreateMapper();
        }

        public async Task<IEnumerable<ObterProdutosResult>> Handle(ObterProdutosQuery request, CancellationToken cancellationToken)
        {
            var listEntity = request.Filtro.IsEmpty() ?
                             await _repository.ObterTodos() :
                             await _repository.ObterPorFiltro(request.Filtro);

            if (listEntity == null || listEntity.Count == 0)
            {
                await _mediator.Publish(new ProdutosVaziosNotification());
            }

            return _mapper.Map<List<ObterProdutosResult>>(listEntity);
        }
    }
}
