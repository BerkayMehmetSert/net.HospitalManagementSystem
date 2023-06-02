# Net Hospital Management System

This folder structure represents a layered architecture approach for the hospital management system API.

## Installing

1. Clone the repository

```shell
git clone https://github.com/BerkayMehmetSert/net.HospitalManagementSystem.git
```

2. Install dependencies

```shell
dotnet restore
```

3. Create database

```shell
dotnet ef database update
```

4. Run the project

```shell
dotnet run
```

## Prerequisites ⚙️

* .NET 6.0
* Entity Framework Core 6.0
* Microsoft SQL Server
* Swagger
* AutoMapper
* RabbitMQ
* AspNetCoreRateLimit
* Docker
* Docker Compose

### Docker Compose

1. Build the project

```shell
docker-compose build
```

2. Run the project

```shell
docker-compose up
```

## Usage

### Swagger

```text
{host}/swagger/index.html
```

### RabbitMQ

```text
http://localhost:15672
```

**Admin Credentials🔒**

```text
Email: example@example.com
Password: 1234
```

## Built With 🛠️

* [Rider](https://www.jetbrains.com/rider/) - IDE
* [ASP.NET Core 6.0](https://docs.microsoft.com/tr-tr/aspnet/core/?view=aspnetcore-6.0) - Web Framework
* [Entity Framework Core 6.0](https://docs.microsoft.com/tr-tr/ef/core/) - ORM
* [Microsoft SQL Server](https://www.microsoft.com/tr-tr/sql-server/sql-server-downloads) - Database
* [Swagger](https://swagger.io/) - API Documentation
* [AutoMapper](https://automapper.org/) - Object-Object Mapper
* [RabbitMQ](https://www.rabbitmq.com/) - Message Broker
* [Docker](https://www.docker.com/) - Containerization
* [Docker Compose](https://docs.docker.com/compose/) - Container Orchestration

