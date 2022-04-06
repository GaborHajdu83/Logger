using AutoMapper;
using Logger.DAL.Repositories;
using Logger.Dtos;
using Logger.Entities.Log;
using Logger.ServiceLayer.Services.ExcelService;

namespace Logger.ServiceLayer.Services.LogService
{
    public class LogService : ILogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IExcelGenerator _exelGenerator;

        public LogService(IUnitOfWork unitOfWork, IMapper mapper, IExcelGenerator exelGenerator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _exelGenerator = exelGenerator;
        }

        public async Task<Log> AddLog(LogDto logDto)
        {
            ArgumentNullException.ThrowIfNull(logDto, nameof(logDto));

            Log log = _mapper.Map<LogDto, Log>(logDto);
            log.Timestamp = DateTime.Now;

            await _unitOfWork.LogRepository.AddAsync(log);
            await _unitOfWork.SaveChangesAsync();

            return log;
        }

        public async Task<IEnumerable<Log>> GetLogsByConditions(SearchConditionDto searchConditionDto)
        {
            IEnumerable<Log> logs = await _unitOfWork.LogRepository.GetLogsByConditions(searchConditionDto);

            return logs;
        }

        public async Task<byte[]> GetLogsInExcelFile()
        {
            IEnumerable<Log> logs = await _unitOfWork.LogRepository.GetAllAsync();

            if (logs.Any())
            {
                byte[] content = _exelGenerator.GenerateLogsExcel(logs);
                return content;
            }
            else
            {
                throw new Exception("There are not Logs in the Logs table.");
            }
        }

        public async Task DeleteLogsByDateTo(DateTime? dateTo)
        {
            IEnumerable<Log> logs = await _unitOfWork.LogRepository.GetLogsByDateTo(dateTo);

            _unitOfWork.LogRepository.RemoveRange(logs);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
