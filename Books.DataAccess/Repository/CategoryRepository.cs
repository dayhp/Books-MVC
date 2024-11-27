using Books.DataAccess.Data;
using Books.DataAccess.Repository.IRepository;
using Books.Models;

namespace Books.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _dbContext;
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Update(Category category)
        {
            _dbContext.Update(category);
        }
    }
}
