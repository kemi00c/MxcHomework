# MxcHomework

## Database

The MxcHomework.Database project contains the database layer of the application, with the EntityFramework bindings.
The database requires PostgreSQL 17 or later. To create the database execute the provided SQL script in the Scripts/ folder on a local PostgreSQL folder.
Any changes in the database requires rescaffolding. To do that run the following command in the Package Manager Console in the Database project:
```powershell
Scaffold-DbContext "Host=localhost;Username=MxcHomeworkRole;Password=Password;Database=MxcHomework" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir "Models" -ContextDir "Data"
```

Bare in mind, that this way, the connection string will be hard-coded into the context class. To prevent this modify this line:
```C#
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Username=MxcHomeworkRole;Password=Password;Database=MxcHomework");
```
to this:
```C#
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    var connectionString = config.GetConnectionString("DefaultConnection");
    optionsBuilder.UseNpgsql(connectionString);
}
```

## Data

The MxcHomework.Data project is responsible for handling event data (adding, deleting, modifying and listing of events).