Este é um projeto para o desafio tecnico proposto pela Lyncas.


## Tecnologias utilizadas
* .NET Core 3
* Entity Framework Core 3
* PostgreSQL 12.3
* Angular 9

## Como executar

# Backend:
1. Instalar a ultima versão do .NET Core SDK (caso já não tenha) e a ultima versão do postgres.
2. Navegue para a pasta do projeto utilizando `cd backend\src\Api\`
3. Após isso você precisa atualizar o banco utilizando `dotnet ef database update`
4. Para iniciar o servidor utilize `dotnet run`

# Frontend:
1. Obter os pacotes utilizando o comando `npm install` ou `yarn`
2. Execute a aplicação utilizando o comando `ng serve`
3. Abra a aplicação no navegador com o seguinte link `http:\\localhost:4200`