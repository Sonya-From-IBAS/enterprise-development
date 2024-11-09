using InstitutionStatistic.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InstitutionStatistic.WebApi.Repository;

public class InstitutionDbContext(DbContextOptions<InstitutionDbContext> options) : DbContext(options)
{
    public DbSet<Institution> Institution { get; set; }
    public DbSet<Faculty> Faculty { get; set; }
    public DbSet<Group> Group { get; set; }
    public DbSet<Rector> Rector { get; set; }
    public DbSet<Speciality> Speciality { get; set; }
    public DbSet<Department> Department { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //маппиг Institution
        modelBuilder.Entity<Institution>()
            .HasOne(x => x.Rector)
            .WithMany();

        modelBuilder.Entity<Institution>()
            .HasMany(x => x.Faculties)
            .WithOne(x => x.Institution);

        //маппинг Faculty
        modelBuilder.Entity<Faculty>()
            .HasMany(x => x.Departments)
            .WithOne(x => x.Faculty);

        //маппинг Department
        modelBuilder.Entity<Department>()
            .HasMany(x => x.Groups)
            .WithOne(x => x.Department);

        //маппинг Group
        modelBuilder.Entity<Group>()
            .HasOne(x => x.Speciality)
            .WithMany(x => x.Groups);

    }
}
