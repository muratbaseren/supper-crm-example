using SupperCRMExample.DataAccess.Abstract;
using SupperCRMExample.Entities.Abstract;
using System.Collections.Generic;

namespace SupperCRMExample.Services.Abstract
{
    public interface IServiceBase<TEntity> where TEntity : EntityBase
    {
        void Delete(int id);
        TEntity GetById(int id);
        List<TEntity> List();
    }

    public class ServiceBase<TEntity, TRepository> : IServiceBase<TEntity> where TEntity : EntityBase
where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _repository;

        public ServiceBase(TRepository repository)
        {
            _repository = repository;
        }

        public List<TEntity> List()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.Get(id);
        }

        public void Delete(int id)
        {
            _repository.Remove(id);
        }
    }
}
