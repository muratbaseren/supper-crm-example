using SupperCRMExample.DataAccess.Abstract;
using SupperCRMExample.DataAccess.Context;
using SupperCRMExample.Entities;

namespace SupperCRMExample.DataAccess
{
    public class ClientRepository : Repository<Client>, IRepository<Client>
    {
        private readonly DatabaseContext _context;

        public ClientRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

    }
}
