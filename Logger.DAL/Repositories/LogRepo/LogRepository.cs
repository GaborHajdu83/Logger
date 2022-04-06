using Logger.Dtos;
using Logger.Entities.Log;
using Microsoft.EntityFrameworkCore;

namespace Logger.DAL.Repositories.LogRepo
{
    public class LogRepository : Repository<LogEntity>, ILogRepository
    {
        private readonly LoggerDbContext _context;

        public LogRepository(LoggerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LogEntity>> GetLogsByConditions(SearchConditionDto searchConditionDto)
        {
            List<LogEntity> logs = await _context.Logs
                .Where(log => (!searchConditionDto.DateFrom.HasValue || (searchConditionDto.DateFrom.HasValue && log.Timestamp >= searchConditionDto.DateFrom.Value)) &&
                              (!searchConditionDto.DateTo.HasValue || (searchConditionDto.DateTo.HasValue && log.Timestamp <= searchConditionDto.DateTo.Value)) &&
                              (string.IsNullOrEmpty(searchConditionDto.LogLevel) || (!string.IsNullOrEmpty(searchConditionDto.LogLevel) && log.LogLevel == searchConditionDto.LogLevel))).ToListAsync();

            return logs;
        }

        public async Task<IEnumerable<LogEntity>> GetLogsByDateTo(DateTime? dateTo)
        {
            List<LogEntity> logs = await _context.Logs
                .Where(log => !dateTo.HasValue || (dateTo.HasValue && log.Timestamp <= dateTo.Value)).ToListAsync();

            return logs;
        }
    }
}
