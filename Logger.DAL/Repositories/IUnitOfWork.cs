using Logger.DAL.Repositories.LogRepo;

namespace Logger.DAL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ILogRepository LogRepository { get; }
        
        int SaveChanges();
        
        Task<int> SaveChangesAsync();
    }
}
