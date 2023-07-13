# DigitalSpace Challenge #

ASP.NET Core 7 application simulating a petrol station with API.

### Summary ###

#### Rules ####

- A new vehicle of a random type is created every 1500 to 2200 milliseconds with 
a random supported fuel type and a random amount of fuel between 0 and a quarter 
of the vehicles tank capacity.
- If one of the nine pumps is free then the vehicle immediately occupies that pump 
and fills their tank to full capacity.
- If no pump is free then the vehicle waits until one becomes free.

#### ToDo ####

- Take into consideration the pumps within a lane when deciding if a pump is free. 
If a pump is in use then all pumps within the lane are blocked and classed as in use.
- Vehicles waiting for a random amount of time between one and two seconds rage quit 
and leave the forecourt without fueling.
- A limitation with the mechanism used to feed the system with randomly generated vehicles 
means that the time between each vehicle creation is constant and not random. Only the 
initial selection of a time between 1500 and 2200 milliseconds is randomised. This might 
be available as a feature in .NET8? https://github.com/dotnet/runtime/issues/60384
- Hangfire (the package used to manage scheduling) is not happy when the application 
is restarted. Before every restart, the Hangfire DB tables must be dropped:

```postgresql
drop schema hangfire cascade;
```

### Technologies ###

- [ASP.NET Core 7](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-7.0)
- [Entity Framework Core 7](https://learn.microsoft.com/en-us/ef/core/)
- [MediatR](https://github.com/jbogard/MediatR)
- [Hangfire](https://github.com/HangfireIO/Hangfire)
- [NUnit](https://nunit.org/) & [Moq](https://github.com/moq/moq)

### Design ###

- [Domain Driven Design (DDD) & Command Query Responsibility Segregation (CQRS)](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/)
- [Minimal APIs](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-7.0)
- [Clean Architecture](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#clean-architecture)

### Entity Framework ###

#### Migrations ####

To add a new migration, run the following command from the root of the repository:

```
dotnet ef migrations add <<MIGRATION_NAME>> --startup-project .\src\DigitalSpace.Challenge.Api\ --project .\src\DigitalSpace.Challenge.Infrastructure\ --output-dir .\Persistence\Migrations --context ChallengeDbContext
```

To remove the most recent migration, run the following command from the root of the repository:

```
dotnet ef migrations remove --startup-project .\src\DigitalSpace.Challenge.Api\ --project .\src\DigitalSpace.Challenge.Infrastructure\ --context ChallengeDbContext
```

### Local Development ###

#### User Secrets ####
https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=windows

Add Postgres connection string to secret storage by running the following command from the root of the DigitalSpace.Challenge.API project replacing the value with your Postgres connection string.

Connection string format: Host=localhost;Username=USERNAME_HERE;Password=PASSWORD_HERE;Database=DigitalSpace.Challenge.Api;Include Error Detail=true

```
dotnet user-secrets set "ConnectionStrings:Postgres" "POSTGRES_CONNECTION_STRING"
```