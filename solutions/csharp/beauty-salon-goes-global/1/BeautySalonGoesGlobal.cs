using System.Globalization;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc)
    => dtUtc.ToLocalTime();


    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        var timeZoneId = location switch
        {
            Location.London => "Europe/London",
            Location.NewYork => "America/New_York",
            Location.Paris => "Europe/Paris",
            _ => throw new TimeZoneNotFoundException()
        };
        var tzi = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        return TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse(appointmentDateDescription), tzi);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        var timeSpan = alertLevel switch
        {
            AlertLevel.Early => TimeSpan.FromDays(1),
            AlertLevel.Standard => TimeSpan.FromHours(1, 45),
            AlertLevel.Late => TimeSpan.FromMinutes(30),
            _ => throw new ArgumentOutOfRangeException()
        };
        return appointment - timeSpan;
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        var timeZoneId = location switch
        {
            Location.London => "Europe/London",
            Location.NewYork => "America/New_York",
            Location.Paris => "Europe/Paris",
            _ => throw new TimeZoneNotFoundException()
        };
        var tzi = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        return tzi.IsDaylightSavingTime(dt) != tzi.IsDaylightSavingTime(dt - TimeSpan.FromDays(7));
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    => location switch
    {
        Location.London => DateTime.Parse(dtStr, new CultureInfo("en-US").DateTimeFormat),
        Location.NewYork => DateTime.Parse(dtStr, new CultureInfo("en-US").DateTimeFormat),
        Location.Paris => DateTime.Parse(dtStr, new CultureInfo("fr-FR").DateTimeFormat),
        _ => new DateTime(1, 1, 1)

    };

}
