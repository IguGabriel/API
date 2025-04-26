# RO.DevTest.API

Projeto de API de E-commerce desenvolvido em .NET 8 como parte de desafio técnico.

## 🔥 Tecnologias Utilizadas
- .NET 8
- ASP.NET Core
- Entity Framework Core
- PostgreSQL
- JWT (Autenticação)
- Swagger (Documentação)

## 🛠️ Requisitos para Rodar o Projeto
- .NET 8 SDK
- PostgreSQL (Banco de dados)
- Visual Studio, Rider ou VS Code (recomendado)
- Gerenciador de pacotes como o `dotnet` CLI ou o NuGet

## 📦 Configuração do Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/seu-repositorio.git
   cd seu-repositorio



2 - Configure o appsettings.json com sua conexão do banco de dados:

"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=devtestdb;Username=seu_usuario;Password=sua_senha"
},
"JwtSettings": {
  "SecretKey": "sua-chave-secreta-grande-e-segura",
  "Issuer": "suaempresa.com",
  "Audience": "suaempresa.com"
}

3 - Execute as migrações para criar as tabelas no banco:

dotnet ef database update

4 - Rode a aplicação:

dotnet run

5 - Acesse o Swagger para testar a API:

https://localhost:5001/swagger


Funcionalidades Principais
CRUD de Clientes

CRUD de Produtos

CRUD de Vendas

Autenticação e Registro de Usuários

Paginação de listagens

Análise de vendas

Proteção de endpoints com autenticação JWT

🔒 Autenticação
Registre-se usando /api/auth/register

Faça login usando /api/auth/login para obter o token

Copie o token JWT e adicione no Swagger usando o botão Authorize

📂 Organização do Projeto
Domain: Entidades e Exceções

Application: Serviços, Interfaces e Casos de Uso

Infrastructure: Configurações de Banco de Dados, Repositórios

Presentation: Controllers e configuração da API

🛠️ Observação sobre o PostgreSQL
O projeto precisa de um banco PostgreSQL instalado para rodar.
Você pode:

Deixar no README o link para o instalador oficial do PostgreSQL ➔ Baixar PostgreSQL

OU incluir um pequeno tutorial ensinando a instalar e criar o banco de dados (devtestdb).

Não precisa enviar o instalador junto dos arquivos. Só explique no README.

📑 Scripts Úteis
Criar banco de dados manualmente:

sql

CREATE DATABASE devtestdb;

📬 Contato
Projeto desenvolvido por [Seu Nome] para avaliação técnica.

Email: duigor5@gmail.com

LinkedIn: https://www.linkedin.com/in/igor-gabriel-843726252/
