using Attendance.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDBContext context;
        private readonly DbSet<T> entities;
        public Repository(ApplicationDBContext context)
        {
            this.context = context;
           entities = context.Set<T>();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> expression, List<string> references)
        {
            if (references != null && references.Any())
            {
                IQueryable<T> query = entities.Include(references.FirstOrDefault());

                if (references.Count > 1)
                    foreach (var item in references.Skip(1))
                    {
                        query = query.Include(item);
                    }

                return query.FirstOrDefault(expression);
            }
            else
                return entities.FirstOrDefault(expression);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression, List<string> references)
        {
            if (references != null && references.Any())
            {
                IQueryable<T> query = entities.Include(references.FirstOrDefault());

                if (references.Count > 1)
                    foreach (var item in references.Skip(1))
                    {
                        query = query.Include(item);
                    }

                return query.Where(expression);
            }
            else
                return entities.Where(expression);
        }

        public IEnumerable<T> GetAllPaginated(Expression<Func<T, bool>> expression, int page, int pageSize, List<string> references, bool ascending = true)
        {
            if (references != null && references.Any())
            {
                IQueryable<T> query = entities.Include(references.FirstOrDefault());

                if (references.Count > 1)
                    foreach (var item in references.Skip(1))
                    {
                        query = query.Include(item);
                    }

                if (ascending)
                    return query.Where(expression).OrderBy(x => x.Id).Skip(page * pageSize).Take(pageSize);
                else
                    return query.Where(expression).OrderByDescending(x => x.Id).Skip(page * pageSize).Take(pageSize);
            }
            else
            {
                if (ascending)
                    return entities.Where(expression).OrderBy(x => x.Id).Skip(page * pageSize).Take(pageSize);
                else
                    return entities.Where(expression).OrderByDescending(x => x.Id).Skip(page * pageSize).Take(pageSize);
            }
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Update(IList<T> entity)
        {
            if (!entity.Any())
            {
                throw new ArgumentNullException("entity");
            }
            foreach (var en in entity)
            {
                entities.Update(en);
            }
            context.SaveChanges();
        }
    }
}
