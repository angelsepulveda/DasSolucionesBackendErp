using System.Reflection;
using Membership.Modules.Models;

namespace Membership.Data;

public class MembershipDbContext(DbContextOptions<MembershipDbContext> options) : DbContext(options)
{
    public DbSet<ModuleModel> Modules => Set<ModuleModel>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

}