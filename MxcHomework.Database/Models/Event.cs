namespace MxcHomework.Database.Models;

public partial class Event
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string? Country { get; set; }

    public int? Capacity { get; set; }
}
