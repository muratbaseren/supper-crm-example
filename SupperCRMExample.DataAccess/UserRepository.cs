using SupperCRMExample.DataAccess.Abstract;
using SupperCRMExample.DataAccess.Context;
using SupperCRMExample.Entities;

namespace SupperCRMExample.DataAccess
{
    public interface IUserRepository : IRepository<User>
    {

    }

    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

    }
}
