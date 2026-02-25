class WeighingMachine
{
    // TODO: define the 'Precision' property
    public int Precision { get; set; }

    private double weight;
    public double Weight
    {
        get { return weight; }
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException();
            weight = value;
        }
    }

    public double TareAdjustment { get; set; } = 5;

    public WeighingMachine(int precision)
    {
        Precision = precision;
    }

    public string DisplayWeight
    {
        get
        {
            return $"{Math.Round(Weight - TareAdjustment, Precision).ToString($"F{Precision}")} kg";
        }
    }
}
