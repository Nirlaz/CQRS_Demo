# 🚀 CQRS CRUD API (ASP.NET Core) — Full Example with Clean Architecture

[![.NET](https://img.shields.io/badge/.NET-8-blue.svg)]()
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)]()
[![Status](https://img.shields.io/badge/Project-Active-success.svg)]()

This repository demonstrates a simple and beginner-friendly implementation of **CQRS (Command Query Responsibility Segregation)** in ASP.NET Core using clean separation of **Read (Query)** and **Write (Command)** logic.

The solution contains:

✔ CRUD operations  
✔ CQRS architecture  
✔ In-Memory database (no SQL setup needed)  
✔ Swagger UI for API testing  
✔ Clean maintainable structure  

---

## 📂 Project Structure Overview

CQRS-CRUD/
│── API/ → Controllers + Program.cs + Swagger
│── Command/ → Create, Update, Delete (Write operations)
│── Query/ → Read operations (Get, List)
│── Common/ → Response wrappers, DTO models
│── Data/ → ApplicationDbContext (InMemory DB)
│── README.md → You're reading this 🙂

yaml
Copy code

---

## 🧠 Why CQRS?

CQRS splits the application logic into two sides:

| COMMAND (Write) | QUERY (Read) |
|----------------|--------------|
| Create         | Get All      |
| Update         | Get By Id    |
| Delete         | Filters/List |
| Changes Data   | Returns Data |

This pattern improves **scalability, maintainability, and clarity**.

---

## 🏗 Architecture Diagram

```mermaid
flowchart LR

A[API Controllers] --> B[Command Layer <br/> Create/Update/Delete]
A --> C[Query Layer <br/> Read Operations]

B --> D[(InMemory Database)]
C --> D
🔥 Features
Feature	Status
CRUD Operation	✔
CQRS Separation	✔
Swagger UI Integrated	✔
InMemory Database	✔
DTO + Response Wrapper	✔
Unit Tests	🔜 Coming Soon

⚙ How To Run The Project
bash
Copy code
# Clone the project
git clone https://github.com/your-username/your-repo.git

cd your-repo

# Build the solution
dotnet build

# Run API
dotnet run --project ./API
Now open Swagger in browser 👇
🔗 http://localhost:5120/swagger

📌 Available API Endpoints
Method	Endpoint	Description
POST	/api/student	Create student
GET	/api/student	Get all students
GET	/api/student/{id}	Get student by ID
PUT	/api/student/{id}	Update student
DELETE	/api/student/{id}	Delete student

📝 Example Request Body (Create Student)
json
Copy code
{
  "name": "John Doe",
  "email": "john@example.com",
  "age": 22
}
📁 Sample Response
json
Copy code
{
  "success": true,
  "message": "Student created successfully",
  "data": {
    "id": "a3d9...",
    "name": "John Doe",
    "email": "john@example.com",
    "age": 22
  }
}
🛠 Technologies Used
Technology	Purpose
ASP.NET Core (.NET 8+)	API Development
EF Core InMemory	Lightweight DB
CQRS Pattern	Read/Write separation
Swagger UI	Interactive API testing

🔥 Next Version Plan
Add Unit Tests (xUnit / Moq)

Add FluentValidation

Add MediatR implementation

Convert DB to SQL Server or PostgreSQL option

🤝 Contributing
Contributions are welcome!
Feel free to fork this repo, make improvements and submit PRs 🚀

bash
Copy code
# Create feature branch
git checkout -b feature/update-api

# Add commits
git commit -m "Improved CQRS handler implementation"

# Submit PR
⭐ If this repository helped you — don't forget to give it a star!
