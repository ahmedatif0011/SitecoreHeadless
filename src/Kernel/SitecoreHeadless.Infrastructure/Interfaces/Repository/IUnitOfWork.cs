namespace SitecoreHeadless.Infrastructure.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
