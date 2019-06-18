using Automoqer;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.PedidoContext.Command;
using VinilSales.Application.PedidoContext.CommandHandlers;
using VinilSales.Application.ProdutoContext.Queries;
using VinilSales.Application.ProdutoContext.Results;
using VinilSales.Application.TabelaCashbackContext.Queries;
using VinilSales.Application.TabelaCashbackContext.Result;
using VinilSales.Domain.CoreContext.Interfaces;
using VinilSales.Domain.ProdutoContext.Enum;
using VinilSales.Repository.Domain.PedidoContext.Entities;
using VinilSales.Repository.Domain.PedidoContext.Interfaces;
using Xunit;

namespace VinilSales.Application.Test.Pedido
{
    public class SalvarPedidoTest
    {
        private readonly CriarPedidoCommandHandler _commandHandler;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IValidationMessage> _validations;
        private readonly Mock<IPedidoRepository> _repository;

        public SalvarPedidoTest()
        {
            var mocker = new AutoMoqer<CriarPedidoCommandHandler>().Build();
            _commandHandler = mocker.Service;

            _mediator = mocker.Param<IMediator>();
            _repository = mocker.Param<IPedidoRepository>();
            _validations = mocker.Param<IValidationMessage>();

            DefaultArrange();
        }

        private PedidoEntity NovoPedido()
        {
            var pedido = new PedidoEntity
            {
                IdCliente = 1,
                IdTabelaCashback = 1,
                ValorPedido = 100
            };

            pedido.Itens.AddRange(new List<Pedido_ItemEntity>
            {
                new Pedido_ItemEntity { IdPedido = 1, IdProduto = 1, ValorUnitario = 10, Quantidade = 10, PercentualCashback = 10 },
                new Pedido_ItemEntity { IdPedido = 1, IdProduto = 2, ValorUnitario = 15, Quantidade = 15, PercentualCashback = 15 }
            });

            return pedido;
        }

        private ObterVigenteResult SimularTabelaCashback()
        {
            var tabela = new ObterVigenteResult
            {
                IdTabelaCashback = 1,
                DataInicioVigencia = DateTime.Now,
                Observacao = "Tabela para cálculo de cashback vigente"
            };

            tabela.Itens.AddRange(new List<ObterVigente_ItensResult>
            {
                new ObterVigente_ItensResult { Genero = (byte)GeneroEnum.Pop, Domingo = 25, Segunda = 7, Terca = 6, Quarta = 2, Quinta = 10, Sexta = 15, Sabado = 20},
                new ObterVigente_ItensResult { Genero = (byte)GeneroEnum.MPB, Domingo = 30, Segunda = 5, Terca = 10, Quarta = 15, Quinta = 20, Sexta = 25, Sabado = 30},
                new ObterVigente_ItensResult { Genero = (byte)GeneroEnum.Classico, Domingo = 35, Segunda = 3, Terca = 5, Quarta = 8, Quinta = 13, Sexta = 18, Sabado = 25},
                new ObterVigente_ItensResult { Genero = (byte)GeneroEnum.Rock, Domingo = 40, Segunda = 10, Terca = 15, Quarta = 15, Quinta = 15, Sexta = 20, Sabado = 40}
            });

            return tabela;
        }

        private ObterProdutoResult SimularProduto(int id)
        {
            ObterProdutoResult produto = null;
            switch (id)
            {
                case 1:
                    produto = new ObterProdutoResult
                    {
                        IdProduto = 1,
                        Genero = (byte)GeneroEnum.Rock,
                        Nome = "... And Justice for All",
                        Artista = "Metallica",
                        Preco = 60
                    };
                    break;
                case 2:
                    produto = new ObterProdutoResult
                    {
                        IdProduto = 2,
                        Genero = (byte)GeneroEnum.Rock,
                        Nome = "Scenes From a Memory",
                        Artista = "Dream Theater",
                        Preco = 70
                    };
                    break;
            }
            return produto;
        }

        private void DefaultArrange()
        {
            _mediator.Setup(m => m.Send(new ObterVigenteQuery(), new CancellationToken(false)))
                     .Returns(Task.FromResult(SimularTabelaCashback()));

            _mediator.Setup(m => m.Send(new ObterProdutoQuery(1), new CancellationToken(false)))
                     .Returns(Task.FromResult(SimularProduto(1)));

            _mediator.Setup(m => m.Send(new ObterProdutoQuery(2), new CancellationToken(false)))
                     .Returns(Task.FromResult(SimularProduto(2)));
        }

        [Trait("Manipulação de Pedidos", "Criar pedido com sucesso")]
        [Category("Pedidos")]
        [Fact]
        public async Task CriarPedido_Sucesso()
        {
            _repository.Setup(m => m.CriarPedido(NovoPedido())).Returns(Task.FromResult(1));
            var command = new CriarPedidoCommand(1,
                new List<CriarPedido_ItemCommand> {
                    new CriarPedido_ItemCommand(0, 1, 10),
                    new CriarPedido_ItemCommand(0, 2, 10)
                });

            // Act
            var result = await _commandHandler.Handle(command, new CancellationToken(false));

            // Assert
            Assert.True(result);
        }
    }
}
