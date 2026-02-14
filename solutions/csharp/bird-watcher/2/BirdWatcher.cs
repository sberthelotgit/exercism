class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        var BirdCount = new BirdCount(new int[] { 0, 2, 5, 3, 7, 8, 4 });
        return BirdCount.birdsPerDay;
    }

    public int Today()
    {
        return birdsPerDay.Last();
    }

    public void IncrementTodaysCount()
    {
        birdsPerDay[^1]++;
    }

    public bool HasDayWithoutBirds()
    {
        return birdsPerDay.Contains(0);
    }

    public int CountForFirstDays(int numberOfDays)
    {
        return birdsPerDay.Take(numberOfDays).Sum();
    }

    public int BusyDays()
    {
        return birdsPerDay.Count(count => count >= 5);
    }
}
