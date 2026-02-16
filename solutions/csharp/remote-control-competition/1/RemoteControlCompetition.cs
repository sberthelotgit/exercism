// TODO implement the IRemoteControlCar interface

public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; set; }
    public int NumberOfVictories { get; set; }

    public int CompareTo(ProductionRemoteControlCar? other) => other == null || other.NumberOfVictories < this.NumberOfVictories ? 1 : -1;

    public void Drive()
    {
        DistanceTravelled += 10;
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public interface IRemoteControlCar
{
    public int DistanceTravelled { get; set; }
    public void Drive();
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        var list = new List<ProductionRemoteControlCar> { prc1, prc2 };
        list.Sort();
        return list;
    }
}
