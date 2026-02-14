using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using Microsoft.VisualBasic;

class Lasagna
{
    private const int cookingTime = 40;
    private const int preparationTimePerLayer = 2;

    public int ExpectedMinutesInOven()
    {
        return cookingTime;
    }

    public int RemainingMinutesInOven(int timePast)
    {
        return cookingTime - timePast;
    }

    public int PreparationTimeInMinutes(int layers)
    {
        return layers * preparationTimePerLayer;
    }

    public int ElapsedTimeInMinutes(int layers, int timePast)
    {
        return PreparationTimeInMinutes(layers) + timePast;
    }
}
