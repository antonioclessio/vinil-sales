using MediatR;
using Moq;
using System;
using Xunit;

namespace VinilSales.Application.Test
{
    public class ProdutoTest
    {
        private readonly Mock<IMediator> _mediator;

        //public ProdutoTest()
        //{
        //    var mock = new AutoMoqer<GetProdutosQuery>().Build();
        //    _mediator = mock.Param<IMediator>();
        //}

        [Fact]
        public void Produto_GetProdutos_ListaVazia()
        {

        }
    }
}
