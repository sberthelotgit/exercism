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
    => TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse(appointmentDateDescription), location.ToTimeZoneInfo());


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

        var tzi = location.ToTimeZoneInfo();
        return tzi.IsDaylightSavingTime(dt) != tzi.IsDaylightSavingTime(dt - TimeSpan.FromDays(7));
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    => DateTime.TryParse(dtStr, location.ToCultureInfo().DateTimeFormat, out var dateTime) ? dateTime : DateTime.MinValue;



    public static TimeZoneInfo ToTimeZoneInfo(this Location location)
    => TimeZoneInfo.FindSystemTimeZoneById(location switch
    {
        Location.London => OperatingSystem.IsWindows() ? "GMT Standard Time" : "Europe/London",
        Location.NewYork => OperatingSystem.IsWindows() ? "Eastern Standard Time" : "America/New_York",
        Location.Paris => OperatingSystem.IsWindows() ? "W. Europe Standard Time" : "Europe/Paris",
        _ => throw new ArgumentOutOfRangeException(nameof(location), location, null)
    });

    public static CultureInfo ToCultureInfo(this Location location)
   => location switch
   {
       Location.London => CultureInfo.GetCultureInfo("en-GB"),
       Location.NewYork => CultureInfo.GetCultureInfo("en-US"),
       Location.Paris => CultureInfo.GetCultureInfo("fr-FR"),
       _ => throw new ArgumentOutOfRangeException(nameof(location), location, null)

   };

}
