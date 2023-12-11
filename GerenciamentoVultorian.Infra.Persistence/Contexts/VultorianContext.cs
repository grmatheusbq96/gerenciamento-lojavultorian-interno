using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GerenciamentoVultorian.Infra.Persistence.Contexts;

public class VultorianContext : DbContext
{
    public VultorianContext(DbContextOptions opt) : base(opt)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Vultorian;Integrated Security=True;Connect Timeout=30;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}