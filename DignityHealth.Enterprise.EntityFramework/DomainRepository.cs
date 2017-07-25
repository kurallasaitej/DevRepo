using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using DignityHealth.Domain.RepositoryInterfaces;

namespace Enterprise.EntityFramework
{
    /// <summary>
    /// Base Repository class for all Repositories
    /// </summary>
    /// <typeparam name="T">Generic type.</typeparam>
    public class DomainRepository<T> : IDomainRepository<T> where T : class
    {
        private readonly DignityHealthContext _context;
        private readonly IDbSet<T> _dbSet;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">DignityHealthContext</param>
        public DomainRepository(DignityHealthContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        /// <summary>
        /// Adds new entity
        /// </summary>
        /// <param name="entity">entity object</param>
        /// <returns>Primary Key Id generated</returns>
        public int Add(T entity)
        {
            _dbSet.Add(entity);
            return _context.SaveChanges();
        }

        /// <summary>
        /// Adds collection of entities
        /// </summary>
        /// <param name="items">IEnumerable objects</param>
        /// <returns>returns Boolean</returns>
        public bool Add(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                _dbSet.Add(item);
            }

            var noOfRecords = _context.SaveChanges();
            return noOfRecords > 0;
        }

        /// <summary>
        /// Updates Entity
        /// </summary>
        /// <param name="entity">entity object</param>
        /// <returns>returns Boolean</returns>
        public bool Update(T entity)
        {
            _dbSet.Attach(entity);
            var noOfRecords = _context.SaveChanges();
            return noOfRecords > 0;
        }

        /// <summary>
        /// Updates Entity
        /// </summary>
        /// <param name="items">List of entity objects</param>
        /// <returns>returns Boolean</returns>
        public bool Update(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                _dbSet.AddOrUpdate(item);
            }

            var noOfRecords = _context.SaveChanges();
            return noOfRecords > 0;
        }

        /// <summary>
        /// Deletes passed entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>returns Boolean</returns>
        public bool Delete(T entity)
        {
            _dbSet.Remove(entity);
            var noOfRecords = _context.SaveChanges();
            return noOfRecords > 0;
        }

        /// <summary>
        /// Deletes all the passed IEnumerable entities.
        /// </summary>
        /// <param name="entities">IEnumerable objects</param>
        /// <returns>returns Boolean</returns>
        public bool Delete(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                _dbSet.Remove(entity);
            }
            var noOfRecords = _context.SaveChanges();
            return noOfRecords > 0;
        }

        /// <summary>
        /// Gets all objects
        /// </summary>
        /// <returns>Returns IQueryable object</returns>
        public IQueryable<T> All()
        {
            return _dbSet;
        }

        /// <summary>
        /// Finds the object based on expression
        /// </summary>
        /// <param name="expression">expression</param>
        /// <returns>Returns object</returns>
        public T FindBy(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return FilterBy(expression).SingleOrDefault();
        }

        /// <summary>
        /// FilterBy passed expression and returns IQueryable objects
        /// </summary>
        /// <param name="expression">expression</param>
        /// <returns>Returns IQueryable objects</returns>
        public IQueryable<T> FilterBy(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return All().Where(expression).AsQueryable();
        }
        
        /// <summary>
        /// Finds entity by passed Id
        /// </summary>
        /// <param name="id">Primary key Id</param>
        /// <returns>Entity object</returns>
        public T FindBy(int id)
        {
            return _dbSet.Find(id);
        }
    }
}
