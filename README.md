# BooksLife
Books' Life is a simple application for libraries to manage their books, readers and borrows. The application is made with ASP.NET Core MVC and Entity Framework Core. I am still working on it, but it is already functional.

## Server requirements
- .NET 7 Runtime (or SDK)
- SQL Server 2022

## Configuration
In appsettings.json file put the connection string for your database as "DefaultConnection".

For example:
```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BooksLife;Trusted_Connection=True;MultipleActiveResultSets=true;"
  },
```
Remember to put 'MultipleActiveResultSets=true;' at the end, since it's necessary for application to work properly.

## Logs
Logs are stored at `C:\Users\%USERNAME%\AppData\Roaming\BooksLife\Logs`.
