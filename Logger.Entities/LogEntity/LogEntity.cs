namespace Logger.Entities.Log
{
    public class LogEntity
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public string? LogLevel { get; set; }
        public DateTime Timestamp { get; set; }
    }
}