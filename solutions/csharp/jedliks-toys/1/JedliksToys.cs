class RemoteControlCar
{
    private int Distance = 0;
    private int BatteryPct = 100;
    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {Distance} meters";
    }

    public string BatteryDisplay()
    {
        return BatteryPct == 0 ? "Battery empty" : $"Battery at {BatteryPct}%";
    }

    public void Drive()
    {
        if (BatteryPct > 0)
        {
            Distance += 20;
            BatteryPct--;
        }
    }
}
