using Automoqer;
using Moq;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.ClienteContext.CommandHandlers;
using VinilSales.Application.ClienteContext.Commands;
using VinilSales.Repository.Domain.ClienteContext.Entities;
using VinilSales.Repository.Domain.ClienteContext.Interfaces;
using Xunit;

namespace VinilSales.Application.Test.Cliente
{
    public class SalvarClienteTest
    {
        private readonly SalvarClienteCommandHandler _commandHandler;
        private readonly Mock<IClienteRepository> _repository;

        public SalvarClienteTest()
        {
            var mocker = new AutoMoqer<SalvarClienteCommandHandler>().Build();
            _commandHandler = mocker.Service;

            _repository = mocker.Param<IClienteRepository>();
        }

        [Trait("Manipulação de clientes", "Salvar com sucesso")]
        [Category("Clientes")]
        [Fact]
        public async Task CriarCliente_Sucesso()
        {
            // Arrange
            _repository.Setup(m => m.Salvar(NovoCliente())).Returns(Task.FromResult(true));

            var command = new SalvarClienteCommand("Antônio Cléssio", "22622492880");

            // Act
            var result = await _commandHandler.Handle(command, new CancellationToken(false));

            // Assert
            Assert.True(result);
        }

        public async Task CriarCliente_VerificarDuplicidade_Falha()
        {
            
        }

        private ClienteEntity NovoCliente()
        {
            return new ClienteEntity
            {
                CPF = "22622492880",
                Nome = "Antônio Cléssio"
            };
        }
    }
}
