using Logger.Dtos;
using Logger.Entities.Log;
using Logger.ServiceLayer.Services.LogService;
using Microsoft.AspNetCore.Mvc;

namespace Logger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoggerController : ControllerBase
    {
        private readonly ILogService _logService;

        public LoggerController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpPost("AddLog")]
        public async Task<IActionResult> AddLog([FromBody] LogDto loggerDto)
        {
            try
            {
                Log result = await _logService.AddLog(loggerDto);

                return Created(nameof(AddLog), result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetLogsByConditions")]
        public async Task<IActionResult> GetLogsByConditions([FromBody] SearchConditionDto searchConditionDto)
        {
            try
            {
                IEnumerable<Log> result = await _logService.GetLogsByConditions(searchConditionDto);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetLogsInExcelFile")]
        public async Task<IActionResult> GetLogsInExcelFile()
        {
            try
            {
                var content = await _logService.GetLogsInExcelFile();

                string fileName = $"Logs-{DateTime.Now.ToString("yyyy'.'MM'.'dd'.'' 'HH':'mm':'ss")}.xlsx";

                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteLogsByDateTo")]
        public async Task<IActionResult> DeleteLogsByDateTo(DateTime? dateTo)
        {
            try
            {
                await _logService.DeleteLogsByDateTo(dateTo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}