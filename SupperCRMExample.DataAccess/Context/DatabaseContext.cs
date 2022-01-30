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
    }
}
