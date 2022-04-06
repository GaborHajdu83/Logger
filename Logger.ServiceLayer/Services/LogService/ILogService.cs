using Logger.Dtos;
using Logger.Entities.Log;

namespace Logger.ServiceLayer.Services.LogService
{
    public interface ILogService
    {
        Task<LogEntity> AddLog(LogDto logDto);
        Task<IEnumerable<LogEntity>> GetLogsByConditions(SearchConditionDto searchConditionDto);
        Task<byte[]> GetLogsInExcelFile();
        Task DeleteLogsByDateTo(DateTime? dateTo);
    }
}
