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

        public async Task<LogEntity> AddLog(LogDto logDto)
        {
            ArgumentNullException.ThrowIfNull(logDto, nameof(logDto));

            LogEntity log = _mapper.Map<LogDto, LogEntity>(logDto);
            log.Timestamp = DateTime.Now;

            await _unitOfWork.LogRepository.AddAsync(log);
            await _unitOfWork.SaveChangesAsync();

            return log;
        }

        public async Task<IEnumerable<LogEntity>> GetLogsByConditions(SearchConditionDto searchConditionDto)
        {
            IEnumerable<LogEntity> logs = await _unitOfWork.LogRepository.GetLogsByConditions(searchConditionDto);

            return logs;
        }

        public async Task<byte[]> GetLogsInExcelFile()
        {
            IEnumerable<LogEntity> logs = await _unitOfWork.LogRepository.GetAllAsync();

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
            IEnumerable<LogEntity> logs = await _unitOfWork.LogRepository.GetLogsByDateTo(dateTo);

            _unitOfWork.LogRepository.RemoveRange(logs);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
