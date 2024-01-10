

using Microsoft.EntityFrameworkCore;
using ThundersChallenge.Domain.Models;


namespace ThundersChallenge.Infra.Context;

public class InMemoryDatabaseContext(DbContextOptions<InMemoryDatabaseContext> options) : DbContext(options)
{
    public DbSet<BusinessTask> BusinessTasks { get; set; }
}
