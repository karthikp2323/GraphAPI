using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemoDAL.IRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        TEntity GetById(long id);
        IQueryable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        TEntity Get(
            Expression<Func<TEntity, bool>> filter = null,
            string includeTables = "");

        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeTables = "");

        void Add(TEntity entity);
        void AddRange(List<TEntity> entityList);
        void Delete(TEntity entity);
        void DeleteRange(List<TEntity> entityList);
    }
}
