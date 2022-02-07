using Microsoft.EntityFrameworkCore;
using SupperCRMExample.DataAccess.Abstract;
using SupperCRMExample.DataAccess.Context;
using SupperCRMExample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SupperCRMExample.DataAccess
{
    public interface ILogRepository : IRepository<Log>
    {

    }

    public class LogRepository : Repository<Log>, ILogRepository
    {
        private readonly DatabaseContext _context;

        public LogRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public override List<Log> GetAll()
        {
            return _set.Include(x => x.User).ToList();
        }

        public override List<Log> GetAll(Expression<Func<Log, bool>> predicate)
        {
            return _set.Include(x => x.User).Where(predicate).ToList();
        }

        public override Log Get(int id)
        {
            return _set.Include(x => x.User).SingleOrDefault(x => x.Id == id);
        }

    }
}
