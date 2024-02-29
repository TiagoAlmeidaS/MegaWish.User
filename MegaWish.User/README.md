# [MegaWish.User.MS]()

Breve descrição do que o projeto faz e qual problema ele busca resolver.

## **Funcionalidades**

- **Gerenciamento de Usuários**: Criação, consulta, atualização e remoção de usuários.
- **Comunicação gRPC**: Implementação de serviços gRPC para interação eficiente e performática entre serviços.
- **API HTTP**: Interface HTTP RESTful para fácil integração e acessibilidade.

## **Tecnologias Utilizadas**

- .NET 5/6
- Entity Framework Core
- AutoMapper
- MediatR
- gRPC
- Swagger/OpenAPI (para documentação da API HTTP)

## **Casos de Uso de Usuário**

- **Adicionar Usuário**: Permite a criação de um novo usuário no sistema.
- **Consultar Usuário**: Permite a consulta de usuários por ID ou documento, oferecendo flexibilidade na busca.
- **Atualizar Usuário**: Suporta a atualização de dados do usuário, mantendo as informações relevantes e atualizadas.
- **Remover Usuário**: Habilita a remoção de usuários do sistema, garantindo a gestão eficaz do cadastro de usuários.

## **Iniciando**

### **Pré-requisitos**

- .NET SDK (versão específica)
- PostgreSQL ou outro banco de dados compatível
- Ferramenta de linha de comando gRPC

### **Configuração**

1. **Clone o repositório**

```bash
git clone url-do-repositorio
cd nome-do-projeto
```

1. **Configure o banco de dados**

Edite o arquivo **`appsettings.json`** para apontar para a instância do seu banco de dados.

```json
{
  "ConnectionStrings": {
    "DB": "sua-string-de-conexão-aqui"
  }
}
```

1. **Execute as migrações**

```bash
dotnet ef database update
```

### **Executando o Projeto**

- **Para iniciar o servidor gRPC:**

```bash
dotnet run --project Caminho/Para/O/Projeto/gRPC
```

- **Para iniciar a API HTTP:**

```bash

dotnet run --project Caminho/Para/O/Projeto/HttpApi
```

## **Documentação**

- A documentação da API HTTP está disponível em **`/swagger`** após iniciar o projeto.
- Para gRPC, consulte os arquivos **`.proto`** no diretório **`Protos`** para detalhes sobre os serviços e mensagens.

## **Contribuindo**

Se você está interessado em contribuir para o projeto, por favor, leia nosso **`CONTRIBUTING.md`** para mais informações sobre como começar.

## **Licença**

Este projeto está licenciado sob a Licença MIT - veja o arquivo **`LICENSE`** para detalhes.