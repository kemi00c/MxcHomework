# MxcHomework

## Database

The MxcHomework.Database project contains the database layer of the application, with the EntityFramework bindings.
The database requires PostgreSQL 17 or later. To create the database execute the provided SQL script in the Scripts/ folder on a local PostgreSQL folder.
Any changes in the database requires rescaffolding. To do that run the following command in the Package Manager Console in the Database project:
```powershell
Scaffold-DbContext "Host=localhost;Username=MxcHomeworkRole;Password=Password;Database=MxcHomework" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir "Models" -ContextDir "Data"
```