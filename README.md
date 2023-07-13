# DigitalSpace Challenge #

ASP.NET Core 7 application simulating a petrol station with API.

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