using Logger.Dtos;
using Logger.Entities.Log;

namespace Logger.DAL.Repositories.LogRepo
{
    public interface ILogRepository : IRepository<LogEntity>
    {
        Task<IEnumerable<LogEntity>> GetLogsByConditions(SearchConditionDto searchConditionDto);
        Task<IEnumerable<LogEntity>> GetLogsByDateTo(DateTime? dateTo);
    }
}
