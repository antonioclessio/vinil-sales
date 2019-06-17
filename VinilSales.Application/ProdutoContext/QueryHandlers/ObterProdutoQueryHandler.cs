using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.CoreContext.CommandHandlers;
using VinilSales.Application.ProdutoContext.Queries;
using VinilSales.Application.ProdutoContext.Results;
using VinilSales.Repository.Domain.ProdutoContext.Entities;
using VinilSales.Repository.Domain.ProdutoContext.Interfaces;
using VinilSales.Application.CoreContext.Interfaces;

namespace VinilSales.Application.ProdutoContext.QueryHandlers
{
    public class ObterProdutoQueryHandler : BaseHandler<IProdutoRepository>, IRequestHandler<ObterProdutoQuery, ObterProdutoResult>
    {
        public ObterProdutoQueryHandler(IValidationHandler validation, IMediator mediator, IProdutoRepository repository) 
            : base(validation, mediator, repository) { }

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
