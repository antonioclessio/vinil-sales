using Automoqer;
using Moq;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.ClienteContext.CommandHandlers;
using VinilSales.Application.ClienteContext.Commands;
using VinilSales.Domain.CoreContext.Interfaces;
using VinilSales.Repository.Domain.ClienteContext.Entities;
using VinilSales.Repository.Domain.ClienteContext.Interfaces;
using Xunit;

namespace VinilSales.Application.Test.Cliente
{
    public class SalvarClienteTest
    {
        private readonly SalvarClienteCommandHandler _commandHandler;
        private readonly Mock<IValidationMessage> _validations;
        private readonly Mock<IClienteRepository> _repository;

        public SalvarClienteTest()
        {
            var mocker = new AutoMoqer<SalvarClienteCommandHandler>().Build();
            _commandHandler = mocker.Service;

            _repository = mocker.Param<IClienteRepository>();
            _validations = mocker.Param<IValidationMessage>();
        }

        private ClienteEntity NovoCliente()
        {
            return new ClienteEntity
            {
                CPF = "38093208038",
                Nome = "Antônio Cléssio"
            };
        }

        [Trait("Manipulação de clientes", "Salvar com sucesso")]
        [Category("Clientes")]
        [Fact]
        public async Task CriarCliente_Sucesso()
        {
            // Arrange
            _repository.Setup(m => m.Salvar(NovoCliente())).Returns(Task.FromResult(true));
            var command = new SalvarClienteCommand("Antônio Cléssio", "61470054051");

            // Act
            var result = await _commandHandler.Handle(command, new CancellationToken(false));

            // Assert
            Assert.True(result);
        }

        [Trait("Manipulação de clientes", "CPF em uso")]
        [Category("Clientes")]
        [Fact]
        public async Task CriarCliente_VerificarDuplicidade_Falha()
        {
            // Arrange
            _repository.Setup(m => m.ObterPorCPF("38093208038")).Returns(Task.FromResult(NovoCliente()));

            var command = new SalvarClienteCommand("Antônio Cléssio", "38093208038");

            // Act
            var result = await _commandHandler.Handle(command, new CancellationToken(false));

            // Assert
            Assert.False(result);
        }
    }
}
