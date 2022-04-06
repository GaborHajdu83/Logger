using Logger.Entities.Log;
using Microsoft.EntityFrameworkCore;

namespace Logger.DAL
{
    public class LoggerDbContext : DbContext
    {
        public virtual DbSet<Log> Logs { get; set; }

        public LoggerDbContext(DbContextOptions<LoggerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LoggerDbContext).Assembly);
        }
    }
}