# Venda de Discos
- Foi utilizado Docker, Entity Framework, DotNet Core, AutoMapper e Visual Studio 2019.

## Build
- Para execução do projeto, apenas realizar o git, e compilação básica.
- É necessário ter o docker instalado, pois o projeto será executado com base na imagem definida no projeto. O Dockerfile está no projeto WebAPI.

## Fluxo para utilização dos endpoints é:
- Executar o get de produtos que, caso nenhum produto seja encontrado, o spotify será executado para então alimentar a base de dados.
- Já existe um cliente que será cadastrado.
- Ao executar o endpoint de pedidos, o sistema irá buscar a tabela de cashback vigente que deve ser utilizada para realizar os cálculos dos percentuais, o cálculo é realizado por produto.
- Um pedido ao ser criado, fica com o status "Aberto" e precisa ser finalizado.
- Quando o pedido é finalizado, é registrada então uma transação de crédito de cashback para o usuário que pode ser verificada com o endpoint específico.
