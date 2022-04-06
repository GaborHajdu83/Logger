using Logger.DAL.Repositories.LogRepo;

namespace Logger.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ILogRepository LogRepository { get; private set; }

        private readonly LoggerDbContext _context;

        public UnitOfWork(LoggerDbContext context)
        {
            _context = context;
            LogRepository = new LogRepository(_context);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
