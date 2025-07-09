# CRUD Fullstack - Sistema de Gerenciamento de Clientes

## 📖 Visão Geral

Este projeto é um sistema completo de gerenciamento de clientes com funcionalidades CRUD (Create, Read, Update, Delete), construído com ASP.NET Core utilizando a **Arquitetura Limpa** (Clean Architecture). Ele é composto por:

- **Web API RESTful** para comunicação com dados
- **Aplicação Web MVC** como interface do usuário

---

## 🛠 Tecnologias Utilizadas

- .NET 6.0
- ASP.NET Core MVC
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server (LocalDB para dev)
- Bootstrap 5
- jQuery
- Swagger/OpenAPI

---

## 🧱 Arquitetura do Projeto

O projeto está organizado nas seguintes camadas:

- **Projeto.Application**: Entidades de negócio e interfaces
- **Projeto.Domain**: Entidades de domínio
- **Projeto.Infrastructure**: Repositórios e acesso a dados (EF Core)
- **Projeto.WebAPI**: Endpoints RESTful e DTOs
- **Projeto.WebAppMVC**: Interface web responsiva e integração com API

---

## 🗃️ Modelo de Dados

### Cliente
- Dados do cliente

### TipoTelefone
- Tipo de Contato Telefônico

### Telefone
- Telefone de Contato

---

## ✅ Funcionalidades

### 🔌 Web API
- `GET /api/clientes` – Lista todos os clientes
- `GET /api/clientes/{id}` – Detalha cliente por ID
- `POST /api/clientes` – Cria cliente
- `PUT /api/clientes/{id}` – Atualiza cliente
- `DELETE /api/clientes/{id}` – Remove cliente
- `GET /api/tipostelefone` – Lista tipos de telefone
- `GET /api/tipostelefone/ativos` – Lista tipos ativos

### 💻 Web App MVC
- Listagem
- Cadastro e edição com validação
- Visualização de detalhes
- Exclusão com confirmação
- Gerenciamento de telefones dinâmico

---

## ⚙️ Configuração e Execução

### Pré-requisitos
- .NET 6.0 SDK
- SQL Server (ou LocalDB)
- Visual Studio 2022 ou VS Code

### Etapas
1. **Configure a Connection String**
2. **Execute as migrações do EF Core**
3. **Inicie a Web API**
4. **Inicie o WebApp MVC**

---

## 🚀 Seeds e Inicialização

A aplicação aguarda o SQL Server estar ativo antes de executar as seeds de dados, garantindo que não ocorra falhas por indisponibilidade do banco no momento da carga.

🧪 Testes e Demonstração

![2025-07-08_21-18-48](https://github.com/user-attachments/assets/67ea6908-1376-4bd6-a3f3-3e0eddc4084f)


![2025-07-06_22-19-07](https://github.com/user-attachments/assets/224bf872-1061-4d5a-ab13-e5ac267a2bb7)


![2025-07-08_17-24-34](https://github.com/user-attachments/assets/43f1ee3e-7197-48b8-85aa-50d269fe15bb)

👨‍💻 Autor

Welton Silva Sousa
📧 weltonsousa@gmail.com
💼 Desenvolvedor Fullstack .NET / Arquitetura DDD / Microsserviços / Mensageria
