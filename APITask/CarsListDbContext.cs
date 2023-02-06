namespace APITask;
using Microsoft.EntityFrameworkCore;

public class CarsListDbContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Account> Accounts { get; set; }

    public CarsListDbContext(DbContextOptions<CarsListDbContext> options) : base(options)
    {

    }
}

