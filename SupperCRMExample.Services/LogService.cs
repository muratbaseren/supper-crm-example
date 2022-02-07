using SupperCRMExample.DataAccess;
using SupperCRMExample.Entities;
using SupperCRMExample.Services.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace SupperCRMExample.Services
{
    public interface ILogService : IServiceBase<Log>
    {
        Log Create(string text, LogType type, int userId);
        List<Log> ListByUserId(int userId, int count = 10);
    }

    public class LogService : ServiceBase<Log, ILogRepository>, ILogService
    {
        private readonly ILogRepository _repository;

        public LogService(ILogRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Log Create(string text, LogType type, int userId)
        {
            Log log = new Log
            {
                Text = text,
                Type = type,
                UserId = userId,
                CreatedAt = System.DateTime.Now
            };

            _repository.Add(log);
            return log;
        }

        public List<Log> ListByUserId(int userId, int count = 10)
        {
            if (count == -1)
            {
                return _repository
                .GetAll(x => x.UserId == userId)
                .OrderByDescending(x => x.CreatedAt)
                .ToList();
            }
            else
            {
                return _repository
                .GetAll(x => x.UserId == userId)
                .OrderByDescending(x => x.CreatedAt)
                .Take(10)
                .ToList();
            }
        }
    }
}
