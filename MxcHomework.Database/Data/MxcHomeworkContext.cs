using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MxcHomework.Database.Models;

namespace MxcHomework.Database.Data;

public partial class MxcHomeworkContext : DbContext, IMxcHomeworkContext
{
    public MxcHomeworkContext()
    {
    }

    public MxcHomeworkContext(DbContextOptions<MxcHomeworkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var connectionString = config.GetConnectionString("DefaultConnection");
        optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Events_pkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
