using SupperCRMExample.Entities.Abstract;
using System.Collections.Generic;

namespace SupperCRMExample.DataAccess.Abstract
{
    public interface IRepository<TEntity>
    where TEntity : EntityBase
    {
        TEntity Add(TEntity model);
        TEntity Get(int id);
        List<TEntity> GetAll();
        void Remove(int id);
        void Update(TEntity model);
    }
}
