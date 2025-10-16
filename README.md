# API de Produtos

Esta é uma API RESTful desenvolvida com .NET 8 para gerenciamento de produtos. Utiliza o Entity Framework Core com banco de dados em memória.
Esta api foi criada como teste técnico para uma vaga de emprego.

## Funcionalidades
- Listar todos os produtos
- Consultar produto por ID
- Criar novo produto
- Atualizar produto existente
- Excluir produto

Cada produto possui os seguintes atributos:
- Id
- Nome
- Descrição
- Preço
- Estoque

## Requisitos
- .NET 8 SDK

## Como Executar
1. Restaure as dependências e faça o build do projeto:
   ```powershell
   dotnet build ProductApi/ProductApi.csproj
   ```
2. Execute a API:
   ```powershell
   dotnet run --project ProductApi/ProductApi.csproj
   ```
3. A API estará disponível em `http://localhost:5019` (ou na porta configurada em `launchSettings.json`).

## Swagger
Para explorar e testar os endpoints da API, acesse a interface Swagger UI:

```
http://localhost:5019/swagger
```

O Swagger fornece uma interface interativa para enviar requisições e visualizar respostas de todos os endpoints disponíveis.