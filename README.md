
AssetManagement.WebApi

A production-ready, enterprise-grade C# / .NET Web API built for modern Asset and Ticket tracking. This backend system is architected to solve core resource-tracking problems, ensuring high availability, strict clean code guidelines, and seamless containerized deployments.

🚀 Key Features & Architecture

• Clean Architecture & Domain Separation: Strictly isolates layers using specialized directories (Models, Data, Repositories, Controllers).
• Repository Design Pattern: Decouples business logic and controllers from database queries using an abstract IAssetRepository layer for optimal testability and maintainability.
• Enterprise Database & Containerization: Powered by a containerized Microsoft SQL Server (MSSQL) instance managed entirely via Docker Compose.
• Infrastructure as Code & Environment Parity: Ensures every developer operates on identical database states using automated Entity Framework Core migrations and automated database data seeding on application startup.
• Cloud-Ready Design: Configured to instantly migrate from local Docker instances to production-grade Microsoft Azure cloud services by updating connection configurations.
• Zero-Secret Security Compliance: Database credentials and sensitive tokens are decoupled from the codebase and injected securely using .NET User Secrets during local development.

🛠️ Tech Stack

• Framework: .NET 8.0 / .NET 9.0 / .NET 10.0 (Web API)
• Language: C# (Strongly Typed, Async/Await architecture)
• Database Moat: Microsoft SQL Server (MSSQL 2022)
• ORM: Entity Framework Core (EF Core) with SQL Server Provider
• DevOps: Docker & Docker Compose (WSL2 Backend)
• Documentation: Swagger UI (OpenAPI)

💻 Getting Started (Local Development)

Follow these steps to spin up the entire environment with isolated configurations on any local machine:

1. Prerequisites

Ensure you have the following software installed:
• .NET SDK
• Docker Desktop (with WSL2 Engine enabled)

2. Configure Local Secrets

Initialize the secure secret store and set up your local development connection string:
powershell
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost,1433;Database=AssetManagementDb;User Id=sa;Password=EnterpriseSecureToken_2026_Prod!;TrustServerCertificate=True;"
Käytä koodia harkiten.

3. Run the Containerized Database

Inject your secure password into the environment session and spin up the Microsoft SQL Server container:
powershell
$env:MSSQL_SECURE_PASSWORD="EnterpriseSecureToken_2026_Prod!"
docker compose up -d
Käytä koodia harkiten.

4. Launch the Web API

Build the solution, enforce the development environment context, and execute the backend assembly safely through the .NET runtime host:
powershell
dotnet build
$env:ASPNETCORE_ENVIRONMENT="Development"
dotnet .\bin\Debug\net10.0\AssetManagement.WebApi.dll
Käytä koodia harkiten.
Note: On startup, the engine automatically verifies database parity, executes missing Entity Framework migrations, and seeds deterministic mock asset logs into the database.

5. Explore the API

Once the application launches, open your browser and navigate to the interactive Swagger documentation page to test the endpoints live:
text
http://localhost:5000/swagger/index.html
Käytä koodia harkiten.

📐 Project Structure

text
AssetManagement.WebApi/
├── Controllers/       # Exposes REST API endpoints and handles HTTP transport
├── Data/              # Entity Framework DbContext configurations and DB mappings
├── Models/            # Strongly-typed database entities and schemas
├── Repositories/      # Abstract interfaces and query logic (Repository Pattern)
├── Properties/        # Local launch configurations and profile environment maps
├── appsettings.json   # Environment configurations without sensitive data
└── Program.cs         # Dependency Injection engine and middleware setup
Käytä koodia harkiten.

🔒 Coding Guidelines & Standards Compliance

This repository enforces strict industry-standard coding conventions:
• Asynchronous Execution: All I/O-bound database transactions natively utilize async and await keywords, preventing thread starvation.
• Dependency Injection (DI): Services and repositories are registered natively and resolved via interfaces (IAssetRepository) to adhere to SOLID principles.
• Naming Conventions: Strictly adheres to formal Microsoft C# Coding Guidelines (e.g., PascalCase for methods, camelCase with underscore prefixes _ for private read-only infrastructure variables).
• Model Validation: Implements strict Data Annotations and ModelState filters to ensure input data sanitization before it reaches the persistence layer.