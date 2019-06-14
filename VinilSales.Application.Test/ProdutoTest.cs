using MediatR;
using Moq;
using VinilSales.Application.ProdutoContext.Queries;
using Xunit;

namespace VinilSales.Application.Test
{
    public class ProdutoTest
    {
        // AAA Pattern
        // Arrange => Act => Assert

        private readonly IMediator _mediator;

        public ProdutoTest()
        {
            var mock = new Mock<IMediator>();
            _mediator = mock.Object;
        }

        [Fact]
        public void Produto_GetProdutos_ListaVazia()
        {
            // Arrange
            

            // Act

            // Assert
        }
    }
}
