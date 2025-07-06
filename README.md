# 📝 BlogAPI

**BlogAPI** is a RESTful API built with ASP.NET Core and Entity Framework Core for managing blog posts and comments. The project follows a clean 3-Tier Architecture and includes secure user authentication using JWT and ASP.NET Core Identity.

---

## 🚀 Features

- ✅ CRUD operations for blog posts
- ✅ Add and manage comments per post
- ✅ User registration and login
- ✅ JWT-based authentication
- ✅ Clean 3-Tier Architecture
- ✅ SQL Server as the database
- ✅ Developed and tested on macOS with Rider

---

## 🛠️ Tech Stack

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- JWT Authentication
- 3-Tier Architecture
- JetBrains Rider (macOS)

---

## 🧱 Project Structure
BlogAPI/
├── BlogAPI.Domain/         # Domain entities
├── BlogAPI.Application/    # Services, interfaces, DTOs
├── BlogAPI.Infrastructure/ # DbContext, Repositories
├── BlogAPI/                # Presentation layer (Controllers, Startup)

---

## 🔐 Authentication Endpoints

- `POST /api/Account/register` → Register new users
- `POST /api/Account/login` → Get JWT token

Authenticated routes require Bearer token in the `Authorization` header.

---

## 📬 Example API Usage

**Add a comment** (requires login):
```http
POST /api/comment
Authorization: Bearer <your_token>

{
"content": "This post is awesome!",
"postId": 1
}
```
```bash
git clone https://github.com/Mohammed-gittech/BlogAPI.git
cd BlogAPI
dotnet ef database update
dotnet run --project BlogAPI
```
## 👨‍💻 Developed by

**Mohammed Abd** — Junior Backend Developer  
📫 Connect on [LinkedIn](https://www.linkedin.com/in/mohammed-abed-9163a536b) | [GitHub](https://github.com/Mohammed-gittech)
