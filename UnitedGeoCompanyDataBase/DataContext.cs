using Microsoft.EntityFrameworkCore;
using UnitedGeoCompanyDataBase.Models;
namespace UnitedGeoCompanyDataBase;

public class DataContext : DbContext
{
    /// <summary>
    /// Заявки.
    /// </summary>
    public DbSet<Application> Applications { get; set; }

    /// <summary>
    /// Бригады.
    /// </summary>
    public DbSet<Brigade> Brigades { get; set; }

    /// <summary>
    /// Задачи.
    /// </summary>
    public DbSet<Objective> Objectives { get; set; }

    public DataContext(DbContextOptions<DataContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Objective>()
            .HasOne(t => t.Application)
            .WithOne(a => a.Objective)
            .HasForeignKey<Objective>("ApplicationId"); 

        modelBuilder.Entity<Objective>()
            .HasOne(t => t.Brigade)
            .WithMany(b => b.Objectives)
            .HasForeignKey("BrigadeId");
    }
}

