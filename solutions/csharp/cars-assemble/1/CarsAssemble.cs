static class AssemblyLine
{
    static int carPerSpeed = 221;

    public static double SuccessRate(int speed) => speed switch
    {
        0 => 0,
        <= 4 => 100,
        <= 8 => 90,
        <= 9 => 80,
        _ => 77
    };

    public static double ProductionRatePerHour(int speed) => double.Round(speed * carPerSpeed * (SuccessRate(speed) / 100), 1);


    public static int WorkingItemsPerMinute(int speed) => (int)(ProductionRatePerHour(speed) / 60);
}
