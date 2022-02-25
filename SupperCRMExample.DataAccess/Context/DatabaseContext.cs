using Microsoft.EntityFrameworkCore;
using SupperCRMExample.Entities;
using System.Linq;

namespace SupperCRMExample.DataAccess.Context
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            var migrations = Database.GetPendingMigrations().ToList();

            if (migrations.Count > 0)
            {
                Database.Migrate();
            }
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Notify> Notifies { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Lead> Leads { get; set; }
    }
}
