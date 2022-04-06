namespace Logger.Dtos
{
    public class SearchConditionDto
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set;}
        public string? LogLevel { get; set; }
    }
}
