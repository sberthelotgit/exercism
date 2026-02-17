static class AssemblyLine
{
    static int carPerSpeed = 221;

    public static double SuccessRate(int speed) => speed switch
    {
        0 => 0,
        <= 4 => 1,
        <= 8 => 0.9,
        <= 9 => 0.8,
        _ => 0.77
    };

    public static double ProductionRatePerHour(int speed) => double.Round(speed * carPerSpeed * (SuccessRate(speed)), 1);


    public static int WorkingItemsPerMinute(int speed) => (int)(ProductionRatePerHour(speed) / 60);
}
