using Ingemmet.FirmaDocumento.Data;
using Ingemmet.FirmaDocumento.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Ingemmet.FirmaDocumento.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DatabaseContext _context;
        private DbSet<T> _entities;

        public Repository(string connectionString = null)
        {
            _context = string.IsNullOrEmpty(connectionString)
                ? new DatabaseContext() : new DatabaseContext(connectionString);
        }

        public IEnumerable<T> GetAll() =>
        _context.Set<T>().ToList();

        public T Get(object key) =>
        _context.Set<T>().Find(key);

        public T Find(Expression<Func<T, bool>> match) =>
        _context.Set<T>().SingleOrDefault(match);

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match) =>
        _context.Set<T>().Where(match).ToList();

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
            return entities;
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                Entities.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public T Update(T entity, object key)
        {
            if (entity == null)
                return null;

            T existing = _context.Set<T>().Find(key);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                _context.SaveChanges();
            }
            return existing;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }

        public int Count() =>
        _context.Set<T>().Count();

        public int Count(Expression<Func<T, bool>> match)
            => _context.Set<T>().Where(match).Count();

        public bool Exist(Expression<Func<T, bool>> match)
            => _context.Set<T>().Any(match);

        public PagedResult<T> Paged(IQueryable<T> query, int page, int pageSize)
        {
            page = page.Equals(0) ? 1 : page;

            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }

        public PagedResult<T> Skip(IQueryable<T> query, int skip, int pageSize)
        {
            int page = skip / pageSize;
            var result = new PagedResult<T>
            {
                CurrentPage = page.Equals(0) ? 1 : page + 1,
                PageSize = pageSize,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }

        #region Properties

        /// <summary>
        /// Gets an entity set
        /// </summary>
        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();

                return _entities;
            }
        }

        #endregion
    }
}