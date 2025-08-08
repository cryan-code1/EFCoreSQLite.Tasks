# 📌 EFCoreSQLite Tasks API

API CRUD para gerenciamento de tarefas, construída com **.NET Core**, **Entity Framework Core** e **SQLite**.  
O objetivo é fornecer um backend simples, mas extensível, para ser consumido por um frontend futuramente (Angular, React, Blazor ou outro).

---

## 🚀 Tecnologias
- **.NET 8 / ASP.NET Core Web API**
- **Entity Framework Core**
- **SQLite** (banco de dados leve e local)
- **C#** (async/await, LINQ, Controllers)

---

## 📂 Estrutura atual
- **POST** `/api/task` — Cria uma nova tarefa
- **GET** `/api/task` — Lista todas as tarefas
- **GET** `/api/task/{id}` — Busca tarefa pelo ID
- **GET** `/api/task/status/{status}` — Filtra tarefas por status
- **GET** `/api/task/count` — Retorna contagem de tarefas (total, concluídas, pendentes)
- **PUT** `/api/task/{id}?newStatus=...` — Atualiza status de uma tarefa
- **DELETE** `/api/task/{id}` — Remove uma tarefa

---

## 🛠 Como rodar
1. **Clonar o repositório**
```bash
git clone https://github.com/seuusuario/seurepositorio.git
cd seurepositorio
```

2. **Instalar dependências**
```bash
dotnet restore
```

3. **Criar/atualizar banco de dados**
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

4. **Rodar API**
```bash
dotnet run
```
## 🔮 Funcionalidades futuras <br>
✅ Autenticação JWT <br>
✅ Validação de dados (FluentValidation ou DataAnnotations) <br>
✅ Logs de requisições e erros (Serilog, NLog ou Microsoft.Extensions.Logging) <br>
✅ Paginação e ordenação nos endpoints <br>
✅ Filtros de pesquisa por datas <br>
✅ Testes automatizados (xUnit / NUnit) <br>
✅ Integração com Swagger/OpenAPI <br>
✅ Configuração via variáveis de ambiente <br>
✅ Tratamento global de exceções (Middleware) <br>
✅ Versionamento de API <br> 

🖥 Exemplo de uso futuro
Esta API será consumida por um frontend que exibirá:
- Lista de tarefas com status e datas
- Filtros por status e data
- Formulário para adicionar/editar tarefas
- Autenticação de usuários

📜 Licença
Este projeto está sob a licença MIT.
Sinta-se livre para usar, modificar e distribuir.
