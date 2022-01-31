using SupperCRMExample.DataAccess.Abstract;
using SupperCRMExample.DataAccess.Context;
using SupperCRMExample.Entities;

namespace SupperCRMExample.DataAccess
{
    public interface INotifyRepository : IRepository<Notify>
    {

    }

    public class NotifyRepository : Repository<Notify>, INotifyRepository
    {
        private readonly DatabaseContext _context;

        public NotifyRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

    }
}
