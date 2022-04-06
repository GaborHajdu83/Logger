using Logger.Dtos;
using Logger.Entities.Log;

namespace Logger.ServiceLayer.Services.LogService
{
    public interface ILogService
    {
        Task<Log> AddLog(LogDto logDto);
        Task<IEnumerable<Log>> GetLogsByConditions(SearchConditionDto searchConditionDto);
        Task<byte[]> GetLogsInExcelFile();
        Task DeleteLogsByDateTo(DateTime? dateTo);
    }
}
