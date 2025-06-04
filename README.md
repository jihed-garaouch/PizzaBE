# PizzaBE
📦 Local Development Setup with Docker Compose

This project includes:

    🧠 .NET 8 Web API backend

    🗄️ SQL Server database (running in a container)

🛠 Prerequisites

    Docker Desktop installed and running

    .NET 8 SDK (optional for development outside containers)

▶️ How to Run the Entire Stack Locally

From the root of the project (where docker-compose.yml is located), run:

docker-compose up --build

🌐 Accessing the App
Component	URL
Frontend	http://localhost:3000
Backend API	http://localhost:8080
SQL Server	localhost:1433 (for tools like DBeaver / SSMS)
📁 Folder Structure

/backend     → ASP.NET Core Web API (.NET 8)
/frontend    → React + Vite frontend
/docker-compose.yml → Multi-service orchestration file

🧪 Common Docker Commands
Command	Description
docker-compose up --build	Build and start all services
docker-compose down	Stop and remove containers
docker ps	List running containers
docker logs <service>	View logs (e.g., backend, db)
⚠️ Notes

    The backend automatically applies EF Core migrations at startup.

    Database connection string is defined in docker-compose.yml for dev purposes.

    To persist DB data across restarts, add a volume to the db service.

