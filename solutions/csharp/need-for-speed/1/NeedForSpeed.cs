class RemoteControlCar
{
    // TODO: define the constructor for the 'RemoteControlCar' class
    private readonly int speed;
    private readonly int batteryDrain;
    private int batteryLevel = 100;

    private int distanceDrove = 0;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
    }


    public bool BatteryDrained()
    {
        return batteryLevel < batteryDrain;
    }

    public int DistanceDriven()
    {
        return distanceDrove;
    }

    public void Drive()
    {
        if (!BatteryDrained())
        {
            distanceDrove += speed;
            batteryLevel -= batteryDrain;
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);

    }
}
class RaceTrack
{
    // TODO: define the constructor for the 'RaceTrack' class
    private readonly int distance;

    public RaceTrack(int distance)
    {
        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (!car.BatteryDrained() && car.DistanceDriven() < distance)
        {
            car.Drive();
        }
        return car.DistanceDriven() >= distance;
    }
}

