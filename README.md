# Todo Web API

The Todos Web API is an experiment resource built using ASP.NET 8 and follows the Clean Architecture pattern. It showcases various features including clean architecture principles, data access with EntityFramework and PostgreSQL, Docker Compose setup for PostgreSQL, user management using ASP.NET Core Identity, cookie authentication, and JWT authentication.

## Features

- **Clean Architecture**: The project is structured following the Clean Architecture principles, separating concerns into layers.
- **EntityFramework and PostgreSQL**: Data access is implemented using EntityFramework Core with PostgreSQL as the underlying database.
- **Docker Compose Setup**: Included Docker Compose YAML file facilitates setting up PostgreSQL for local development and testing.
- **User Management with ASP.NET Core Identity**: ASP.NET Core Identity is used for managing users, including authentication and authorization.
- **Cookie Authentication**: Authentication is supported via cookie-based authentication.
- **JWT Authentication**: JSON Web Token (JWT) authentication is also implemented for securing API endpoints.
## Getting Started

To get started with the Todos Web API, follow these steps:

1. Clone the repository:

    ```bash
    git clone https://github.com/flynnbui/ToDosApp-ASP.NET.git
    ```

2. Navigate to the project directory:

    ```bash
    cd TodoApp.WebAPI
    ```

3. Set up Docker Compose for PostgreSQL:

    ```bash
    docker-compose up dev-db
    ```

4. Open the solution in Visual Studio or your preferred IDE.

5. Build and run the application.

6. Explore the API endpoints and functionalities.

## Dependencies

The Todos Web API relies on the following dependencies:

- ASP.NET 8
- EntityFramework Core
- PostgreSQL
- AutoMapper
- Docker
- ASP.NET Core Identity

## Reference 
- Todo application by David Fowl - https://github.com/davidfowl/TodoApi
- Common web application architectures - https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures -
- Sample ASP.NET Core 8.0 reference application, powered by Microsoft - https://github.com/dotnet-architecture/eShopOnWeb
