# MxcHomework

## Database

To rescaffold the database run the following command in the Package Manager Console in the Database project:
```powershell
Scaffold-DbContext "Host=localhost;Username=MxcHomeworkRole;Password=Password;Database=MxcHomework" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir "Models" -ContextDir "Data"
```