using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.CoreContext.Base;
using VinilSales.Application.ProdutoContext.Commands;
using VinilSales.Repository.Domain.ProdutoContext.Entities;
using VinilSales.Repository.Domain.ProdutoContext.Interfaces;

namespace VinilSales.Application.ProdutoContext.CommandHandlers
{
    public class SalvarProdutoCommandHandler : BaseHandler<IProdutoRepository>, IRequestHandler<SalvarProdutoCommand, bool>
    {
        public SalvarProdutoCommandHandler(IMediator mediator, IProdutoRepository repository) : base(mediator, repository) { }

        public override void ConfigureMapper()
        {
            _mapper = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<SalvarProdutoCommand, ProdutoEntity>();
            }).CreateMapper();
        }

        public async Task<bool> Handle(SalvarProdutoCommand request, CancellationToken cancellationToken)
        {
            var novoProduto = _mapper.Map<ProdutoEntity>(request);
            if (!novoProduto.IsValid()) return false;

            await _repository.Salvar(novoProduto);
            return true;
        }
    }
}
