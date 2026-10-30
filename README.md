# AssetManagement.WebApi

A production-ready, enterprise-grade **C# / .NET Web API** built for modern Asset and Ticket tracking. This backend system is architected to solve core resource-tracking problems, ensuring high availability, strict clean code guidelines, and seamless containerized deployments.

## 🚀 Key Features & Architecture

- **Clean Architecture & Domain Separation:** Strictly isolates layers using specialized directories (`Models`, `Data`, `Repositories`, `Controllers`).
- **Repository Design Pattern:** Decouples business logic and controllers from database queries using an abstract `IAssetRepository` layer for optimal testability and maintainability.
- **Enterprise Database & Containerization:** Powered by a containerized **Microsoft SQL Server (MSSQL)** instance managed entirely via Docker Compose.
- **Infrastructure as Code & Environment Parity:** Ensures every developer operates on identical database states using automated Entity Framework Core migrations and automated database data seeding on application startup.
- **Cloud-Ready Design:** Configured to instantly migrate from local Docker instances to production-grade **Microsoft Azure** cloud services by updating connection configurations.

---

## 🛠️ Tech Stack

- **Framework:** .NET 8.0 / .NET 9.0 (Web API)
- **Language:** C# (Strongly Typed, Async/Await architecture)
- **Database Moat:** Microsoft SQL Server (MSSQL 2022)
- **ORM:** Entity Framework Core (EF Core) with SQL Server Provider
- **DevOps:** Docker & Docker Compose
- **Documentation:** Swagger UI (OpenAPI)

---

## 💻 Getting Started (Local Development)

Follow these steps to spin up the entire environment with isolated configurations on any local machine:

### 1. Prerequisites
Ensure you have the following software installed:
- [.NET SDK](https://microsoft.com)
- [Docker Desktop](https://docker.com)

### 2. Run the Containerized Database
Spin up the isolated Microsoft SQL Server instance in the background via Docker Compose:
```bash
docker compose up -d
```

### 3. Launch the Web API
Run the C# backend application. On startup, the system will automatically run missing database migrations and seed default mock assets into your local MSSQL instance:
```bash
dotnet run
```

### 4. Explore the API
Once the application launches, open your browser and navigate to the interactive Swagger documentation page to test the endpoints live:
```text
http://localhost:5000/swagger
```

---

## 📐 Project Structure

```text
AssetManagement.WebApi/
├── Controllers/       # Exposes REST API endpoints and handles HTTP transport
├── Data/              # Entity Framework DbContext configurations and DB mappings
├── Models/            # Strongly-typed database entities and schemas
├── Repositories/      # Abstract interfaces and query logic (Repository Pattern)
├── appsettings.json   # Environment configurations and DB Connection Strings
└── Program.cs         # Dependency Injection engine and middleware setup
```

---

## 🔒 Coding Guidelines & Standards Compliance

This repository enforces strict industry-standard coding conventions:
- **Asynchronous Execution:** All I/O-bound database transactions natively utilize `async` and `await` keywords, preventing thread starvation.
- **Dependency Injection (DI):** Services and repositories are registered natively and resolved via interfaces (`IAssetRepository`) to adhere to SOLID principles.
- **Naming Conventions:** Strictly adheres to formal Microsoft C# Coding Guidelines (e.g., PascalCase for methods, camelCase with underscore prefixes `_` for private read-only infrastructure variables).
