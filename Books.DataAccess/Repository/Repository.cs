using Books.DataAccess.Data;
using Books.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Books.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        public DbSet<T> Dbset { get; set; }
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            this.Dbset = _dbContext.Set<T>();
            _dbContext.Product.Include(u => u.Category).Include(u => u.CategoryId);
        }
        public void Add(T entity)
        {
            _dbContext.Add(entity);
        }

        public void AddRange(List<T> entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            _dbContext.Remove(entity);
        }

        public void DeleteRange(List<T> entity)
        {
            _dbContext.RemoveRange(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query;
            if (tracked)
            {
                query = Dbset;
            }
            else
            {
                query = Dbset.AsNoTracking();
            }
            if (includeProperties != null)
            {
                foreach (var includePro in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includePro);
                }
            }
            var result = query.Where(filter).FirstOrDefault();

            return result;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = Dbset;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includePro in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(includePro);
                }
            }
            return query.ToList();
        }
    }
}
