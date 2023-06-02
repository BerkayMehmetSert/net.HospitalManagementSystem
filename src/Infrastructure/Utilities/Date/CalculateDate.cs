namespace Infrastructure.Utilities.Date;

public static class CalculateDate
{
    public static DateTime GetCurrentDateTime()
    {
        return DateTime.UtcNow;
    }
}