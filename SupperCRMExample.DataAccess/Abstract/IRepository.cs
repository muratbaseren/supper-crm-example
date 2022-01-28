using SupperCRMExample.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SupperCRMExample.DataAccess.Abstract
{
    public interface IRepository<TEntity>
    where TEntity : EntityBase
    {
        TEntity Add(TEntity model);
        TEntity Get(int id);
        List<TEntity> GetAll();
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        void Remove(int id);
        void Update(TEntity model);
    }
}
