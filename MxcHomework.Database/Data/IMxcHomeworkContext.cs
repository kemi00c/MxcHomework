using Microsoft.EntityFrameworkCore;
using MxcHomework.Database.Models;

namespace MxcHomework.Database.Data
{
    public interface IMxcHomeworkContext
    {
        DbSet<Event> Events { get; set; }
    }
}