using System;
using System.Collections.Generic;

namespace MxcHomework.Database.Models;

public partial class Event
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Location { get; set; }

    public string? Country { get; set; }

    public int? Capacity { get; set; }
}
