using Microsoft.EntityFrameworkCore;

namespace Congratulatory.Db;

public class CongratulatoryDbContext : DbContext
{
    private string connectionString;

    public CongratulatoryDbContext(string connectionString)
    {
        this.connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(connectionString);
    }
}