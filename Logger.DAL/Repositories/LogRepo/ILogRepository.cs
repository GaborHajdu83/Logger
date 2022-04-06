using Logger.Dtos;
using Logger.Entities.Log;

namespace Logger.DAL.Repositories.LogRepo
{
    public interface ILogRepository : IRepository<Log>
    {
        Task<IEnumerable<Log>> GetLogsByConditions(SearchConditionDto searchConditionDto);
        Task<IEnumerable<Log>> GetLogsByDateTo(DateTime? dateTo);
    }
}
