using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GerenciamentoVultorian.Infra.Persistence.Contexts;

public class VultorianContext : DbContext
{
    public VultorianContext(DbContextOptions opt) : base(opt)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}