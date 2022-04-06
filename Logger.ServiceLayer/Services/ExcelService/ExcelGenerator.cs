using Logger.Entities.Log;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Logger.ServiceLayer.Services.ExcelService
{
    public class ExcelGenerator : IExcelGenerator
    {
        public byte[] GenerateLogsExcel(IEnumerable<LogEntity> logs)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new())
            {

                var workSheet = excelPackage.Workbook.Worksheets.Add("Logs");

                workSheet.Row(1).Height = 20;
                workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Row(1).Style.Font.Bold = true;

                workSheet.Column(2).Width = 36.43;
                workSheet.Column(3).Width = 30.71;
                workSheet.Column(4).Width = 18.57;

                workSheet.Cells[1, 1].Value = "Id";
                workSheet.Cells[1, 2].Value = "Message";
                workSheet.Cells[1, 3].Value = "LogLevel";
                workSheet.Cells[1, 4].Value = "Timestamp";

                int recordIndex = 2;

                foreach (var log in logs)
                {
                    workSheet.Cells[recordIndex, 1].Value = log.Id;
                    workSheet.Cells[recordIndex, 2].Value = log.Message;
                    workSheet.Cells[recordIndex, 3].Value = log.LogLevel;
                    workSheet.Cells[recordIndex, 4].Value = log.Timestamp.ToString("yyyy'.'MM'.'dd'.'' 'HH':'mm':'ss");
                    recordIndex++;
                }

                using(var stream = new MemoryStream())
                {
                    excelPackage.SaveAs(stream);
                    var content = stream.ToArray();
                    return content;
                }
            }
        }
    }
}
