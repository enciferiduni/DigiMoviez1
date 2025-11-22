# DigiMoviez

DigiMoviez is a modern web application designed for movie enthusiasts. It provides a platform to explore movies, view detailed information, and interact with other users through comments and reviews.

## Features
- **Movie Management:** Add, update, delete, and fetch movies with pagination.
- **User Authentication:** Secure JWT-based authentication for user login and registration.
- **Comments and Replies:** Post comments or replies on movies.
- **Admin Features:** Manage genres, users, and other entities.
- **Caching:** Optimized performance with in-memory caching.

## Technologies Used
- **Backend:** ASP.NET Core, Entity Framework Core
- **Database:** SQL Server
- **Authentication:** JWT
- **Design Patterns:** Clean Architecture, Dependency Injection, Repository Pattern
- **Documentation:** Swagger

## Getting Started

### Prerequisites
- .NET 6 SDK
- SQL Server
- Docker (optional, for containerized setup)

### Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/enciferiduni/DigiMoviez1.git
   cd DigiMoviez1
   ```
2. Configure the database connection in `appsettings.json`.
3. Run the migrations to set up the database:
   ```bash
   dotnet ef database update
   ```
4. Build and run the application:
   ```bash
   dotnet run
   ```
5. Access the API via Swagger at `http://localhost:5000/swagger`.

## Challenges
- **Scalability:** Optimizing for high traffic may require distributed caching or database sharding.
- **Security:** Additional measures like rate limiting and input validation can enhance security.
- **Testing:** Automated tests are recommended for better reliability.

## Screenshots

### Comment API Endpoints
![Comment API Endpoints](screenshot\Get.comment.png)

## License
This project is licensed under the MIT License.