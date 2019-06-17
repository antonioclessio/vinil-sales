using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.CoreContext.CommandHandlers;
using VinilSales.Application.CoreContext.Interfaces;
using VinilSales.Application.ProdutoContext.Commands;
using VinilSales.Repository.Domain.ProdutoContext.Entities;
using VinilSales.Repository.Domain.ProdutoContext.Interfaces;

namespace VinilSales.Application.ProdutoContext.CommandHandlers
{
    public class SalvarProdutoCommandHandler : BaseHandler<IProdutoRepository>, IRequestHandler<SalvarProdutoCommand, bool>
    {
        public SalvarProdutoCommandHandler(IValidationHandler validation, IMediator mediator, IProdutoRepository repository)
            : base(validation, mediator, repository) { }

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
            if (novoProduto.Invalido)
            {
                _validation.AddRange(novoProduto.Mensagens);
                return false;
            }

            await _repository.Salvar(novoProduto);
            return true;
        }
    }
}
