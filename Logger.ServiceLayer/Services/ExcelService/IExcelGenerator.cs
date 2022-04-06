using Logger.Entities.Log;

namespace Logger.ServiceLayer.Services.ExcelService
{
    public interface IExcelGenerator
    {
        byte[] GenerateLogsExcel(IEnumerable<LogEntity> logs);
    }
}
