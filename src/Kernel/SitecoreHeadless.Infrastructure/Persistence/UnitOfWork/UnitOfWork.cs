using SitecoreHeadless.Infrastructure.Interfaces.Repository;

namespace SitecoreHeadless.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbFactory _dbFactory;

        public UnitOfWork(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<bool> CommitAsync()
        {
            return await _dbFactory._dbContext.SaveChangesAsync() != 0;
        }
    }
}
