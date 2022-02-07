using Microsoft.EntityFrameworkCore;
using SupperCRMExample.Entities;

namespace SupperCRMExample.DataAccess.Context
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Notify> Notifies { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
