namespace Infrastructure.Logging;

public class LogDetail
{
    public string MethodName { get; set; } = null!;
    public string Path { get; set; } = null!;
    public string Message { get; set; } = null!;
    public string? User { get; set; }
    public string ClassName { get; set; } = null!;
    public string? InnerException { get; set; }
    public List<LogParameter> LogParameters { get; set; } = null!;
}