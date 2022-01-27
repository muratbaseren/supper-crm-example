using SupperCRMExample.DataAccess.Abstract;
using SupperCRMExample.DataAccess.Context;
using SupperCRMExample.Entities;

namespace SupperCRMExample.DataAccess
{
    public interface IClientRepository : IRepository<Client>
    {

    }

    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly DatabaseContext _context;

        public ClientRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

    }
}
