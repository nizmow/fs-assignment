# FS Assignment

## Summary

This exciting application can take a numerical input and respond with the equivalent English text! Impress your friends by demonstrating that you can say numbers -- this program will tell you how.

## Contributing

If you'd like to contribute, raising issues is the easiest way. If you'd like to add a feature or fix a bug, please feel free to submit a PR to the `master` branch for review.

### Running

To run this application locally, ensure you have the latest [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1) and [SQL Server Express with LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb). 

If you're not running on Windows, or you'd prefer to use your own SQL Server instance, please modify the `FsAssignment` connection string in `appsettings.Development.json` or set the environment variable `CONNECTIONSTRINGS__FSASSIGNMENT` to your desired connection string. A `docker-compose.yaml` file is provided to run SQL Server if you're on Linux or Mac, simple `docker-compose up -d` and set the connection string to `Server=localhost;Database=FsAssignment;User Id=sa;Password=Password.123`.

Either load `fs-assignment.sln` into your favourite editor (Visual Studio 2019 and up, or other) or run with:

```cmd
$ dotnet run -p .\Application\Application.csproj
```

### Migrations

Database migrations will run automatically if appropriate when starting the application.

If you'd like to add or remove database migrations, please install the [EF Core CLI tool](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet) like so:

```cmd 
$ dotnet tool install --global dotnet-ef
```

To add a migration after making modifications to the DbContext, use:

```cmd
$ dotnet ef migrations add <NAME> -p .\DataAccess\DataAccess.csproj -s .\Application\Application.csproj
```
