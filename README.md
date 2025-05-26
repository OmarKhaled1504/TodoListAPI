# ✅ TodoListAPI

A clean and secure RESTful API built with ASP.NET Core and Entity Framework Core for managing user-based to-do lists. Features include user registration and login, JWT authentication, personalized to-do management, and a service-based architecture for scalability and testability.

---

## 🚀 Features

- 🔐 JWT-based user authentication
- 📝 CRUD operations for user-specific to-do items
- 🧼 DTO-based request/response models
- 👥 User registration with unique username/email validation
- 🔐 Password hashing for secure authentication
- 🧠 Separated business logic into services for maintainability
- 📄 Global error handling and proper HTTP status code usage
- 🐬 MySQL database integration via Pomelo provider

---

## 🛠️ Technologies Used

- **ASP.NET Core 8**
- **Entity Framework Core**
- **Pomelo.EntityFrameworkCore.MySql**
- **MySQL**
- **C#**

---

## 📁 Project Structure

```
TodoListAPI/
├── Controllers/           # API controllers (handle requests)
├── Data/                  # EF DbContext and configuration
├── Dtos/                  # Data Transfer Objects
├── Entities/              # Domain models (User, Todo)
├── Mapping/               # Extension methods for model-DTO conversion
├── Migrations/            # EF Core migrations
├── Responses/             # Standard response models
├── Services/              # Business logic for Auth and Todo
├── appsettings.json       # Configuration file
├── Program.cs             # Application entry point
└── TodoListAPI.csproj     # Project configuration
```

---

## ⚙️ Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/)
- Visual Studio / VS Code

### Installation Steps

1. **Clone the repository**

```bash
git clone https://github.com/OmarKhaled1504/TodoListAPI.git
cd TodoListAPI
```

2. **Set your database connection string**

In `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;port=3306;database=TodoListDB;user=root;password=yourpassword;"
}
```

> 💡 Use [User Secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets) or environment variables to avoid storing sensitive data in code.

3. **Apply EF Core migrations**

```bash
dotnet ef database update
```

4. **Run the application**

```bash
dotnet run
```

Visit `https://localhost:5001` or `http://localhost:5000`.

---

## 🔐 Authentication

- `POST /api/auth/register` – Register new users
- `POST /api/auth/login` – Authenticate and receive JWT

---

## 📬 API Endpoints

### Todos

- `GET /api/todos` – Get all todos for the authenticated user
- `GET /api/todos/{id}` – Get a specific todo
- `POST /api/todos` – Create a new todo
- `PUT /api/todos/{id}` – Update a todo
- `DELETE /api/todos/{id}` – Delete a todo

> 🔐 All todo routes require a valid JWT token via `Authorization: Bearer <token>`

### Sample Register Request

```json
{
  "username": "omar123",
  "email": "omar@example.com",
  "password": "MySecurePass123!"
}
```

### Sample Todo Creation

```json
{
  "title": "Complete .NET Project",
  "description": "Finish the API and write README",
  "isDone": false
}
```

---

## 🧪 Testing

Use [Postman](https://www.postman.com/) or Swagger UI to test endpoints.

---

## 📄 License

Licensed under the [MIT License](LICENSE).

---

## 📫 Contact

Created by [Omar Khaled](https://github.com/OmarKhaled1504)

**Inspired by [roadmap.sh's Todo List API project](https://roadmap.sh/projects/todo-list-api).**
