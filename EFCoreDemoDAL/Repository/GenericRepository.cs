using EFCoreDemoDAL.IRepository;
using EFCoreDemoDAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemoDAL.Repository
{
    public partial class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly SampleContext _context;
        protected readonly DbSet<TEntity> _entities;

        public GenericRepository(SampleContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();

        }
        public TEntity GetById(int id)
        {
            return _entities.Find(id);
        }

        public TEntity GetById(long id)
        {
            return _entities.Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _entities.AsQueryable();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.FirstOrDefault(predicate);
        }

        /// <summary>
        /// Generic repository method for eager loading.
        /// </summary>
        /// <param name="filter">Example: u => u.UserId == Id</param>
        /// <param name="includeTables">Example: "EharsClientProfile,Status,Gender,Priority"</param>
        /// <returns>TEntity</returns>
        public virtual TEntity Get(Expression<Func<TEntity, bool>> filter = null, string includeTables = "")
        {
            IQueryable<TEntity> query = _entities;

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeTable in includeTables.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeTable);
            }

            return query.FirstOrDefault();
        }

        /// <summary>
        /// Generic repository method for eager loading.
        /// </summary>
        /// <param name="filter">Example: u => u.UserId == Id</param>
        /// <param name="orderBy">Example: q => q.OrderBy(s => s.LastName)</param>
        /// <param name="includeTables">Example: "EharsClientProfile,Status,Gender,Priority"</param>
        /// <returns>IEnumerable<TEntity></TEntity></returns>
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeTables = "")
        {
            IQueryable<TEntity> query = _entities;

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeTable in includeTables.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeTable);
            }

            if (orderBy != null)
                return orderBy(query).ToList();
            else
                return query.ToList();

        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void AddRange(List<TEntity> entityList)
        {
            _entities.AddRange(entityList);
        }

        public void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }
        public void DeleteRange(List<TEntity> entityList)
        {
            _entities.RemoveRange(entityList);
        }

        public void Update(TEntity entity)
        {
            _entities.Update(entity); 
        }
        public void UpdateRange(List<TEntity> entityList)
        {
            _entities.UpdateRange(entityList); 
        }
    }
}
