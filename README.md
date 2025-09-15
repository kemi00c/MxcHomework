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

## Service

The MxcHomework.Service project contains the REST API endpoints for listing, modifying existing, adding new events or delete events.

### Listing events

The EventListController provides the functionality for listing events.

The EventList/List endpoint provides a simple, unordered list of events
The EventList/ListOrdered endpoint lists events ordered by a specified column in either ascending or descending order.

The EventList/ListPaged and ListPagedOrdered endpoints provide unoredered and ordered lists in chunks of the specified page size. The provided page number in the "page" argument is returned. If page is out of range, Not Found is returned.

### Modifying existing events

The EventModify/Modify endpoint provides the functionality to modify existing events. An event must be provided matching the following pattern:
```json
{
  "id": 0,
  "name": "string",
  "location": "string",
  "country": "string",
  "capacity": 0
}
```
If the event is invalid (name or location is empty, location is longer than 100 characters, or the capacity is not a positive number), Bad Request is returned.
If the event with the specified ID not found, Not Found is returned, otherwise the event is modified.

### Adding new events

The EventAdd/Add endpoint provides the functionality to add new events to the database.
An event must be provided, matching the following pattern:
```json
{
  "id": 0,
  "name": "string",
  "location": "string",
  "country": "string",
  "capacity": 0
}
```
If the event is invalid (name or location is empty, location is longer than 100 characters, or the capacity is not a positive number), Bad Request is returned, otherwise the event is inserted into the database.

### Deleting events

The EventDelete/Delete endpoint provides deleting existing events. To avoid accidental deletion the full event has to be provided matching the following pattern:
```json
{
  "id": 0,
  "name": "string",
  "location": "string",
  "country": "string",
  "capacity": 0
}
```
If the event is invalid (name or location is empty, location is longer than 100 characters, or the capacity is not a positive number), Bad Request is returned.
If the event with the specified ID not found, Not Found is returned, otherwise the event is deleted.

## UI

A simple web UI is created to demonstrate the features of the API. The website can be hosted in a local developer server (for example Live Server in Visual Studio Code), and must listen at port 5500, because the API's CORS configuration.
The index.html lists events fetched from the database, which can be sorted on any specific column. New events can be created or existing ones can be modified or deleted from this page.
The edit.html page provides the input for modifying existing or creating new events.