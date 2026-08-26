# MiniCRM

API REST para gestão de clientes, desenvolvida com ASP.NET Core e Entity Framework Core.

## Funcionalidades

- Criar clientes
- Listar clientes
- Consultar um cliente por ID
- Atualizar clientes
- Eliminar clientes
- Validação dos dados dos clientes
- Persistência dos dados numa base de dados através do Entity Framework Core
- Testes dos endpoints através do Swagger

## Tecnologias

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI

## Como executar

1. Abrir a solução `MiniCRM.sln` no Visual Studio.
2. Restaurar as dependências do projeto.
3. Executar as migrations da base de dados, caso necessário.
4. Iniciar o projeto através do Visual Studio.
5. Abrir o Swagger para testar a API.

## Endpoints

| Método | Endpoint | Descrição |
|---|---|---|
| GET | `/api/Clientes` | Lista todos os clientes |
| GET | `/api/Clientes/{id}` | Consulta um cliente |
| POST | `/api/Clientes` | Cria um novo cliente |
| PUT | `/api/Clientes/{id}` | Atualiza um cliente |
| DELETE | `/api/Clientes/{id}` | Elimina um cliente |

## Exemplo de cliente

```json
{
"id": 0,
"nome": "Cliente Teste",
"email": "cliente.teste@email.com",
"telefone": "912345678"
}