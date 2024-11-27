namespace Books.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public ICategoryRepository Category { get; }
        public ICompanyRepository Company { get; }
        void Save();
    }
}
