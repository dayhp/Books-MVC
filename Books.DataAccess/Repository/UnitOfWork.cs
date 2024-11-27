using Books.DataAccess.Data;
using Books.DataAccess.Repository.IRepository;

namespace Books.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Category { get; private set; }
        public ICompanyRepository Company { get; private set; }
        private ApplicationDbContext _dbContext;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Category = new CategoryRepository(_dbContext);
            Company = new CompanyRepository(_dbContext);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
