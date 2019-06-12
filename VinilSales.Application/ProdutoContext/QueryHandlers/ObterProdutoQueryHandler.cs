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
    public class ObterProdutoQueryHandler : BaseHandler<IProdutoRepository>, IRequestHandler<ObterProdutoQuery, ObterProdutoResult>
    {
        public ObterProdutoQueryHandler(IMediator mediator, IProdutoRepository repository) : base(mediator, repository) { }

        public override void ConfigureMapper()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProdutoEntity, ObterProdutoResult>();
            }).CreateMapper();
        }

        public async Task<ObterProdutoResult> Handle(ObterProdutoQuery request, CancellationToken cancellationToken)
        {
            var listEntity = await _repository.ObterPorId(request.IdProduto);
            return _mapper.Map<ObterProdutoResult>(listEntity);
        }
    }
}
