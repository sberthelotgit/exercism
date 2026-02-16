static class SavingsAccount
{
    public static float InterestRate(decimal balance) =>
        balance switch
        {
            < 0 => 3.213f,
            < 1000 => 0.5f,
            < 5000 => 1.621f,
            _ => 2.475f
        };


    public static decimal Interest(decimal balance) =>
        balance * (decimal)InterestRate(balance) / 100;


    public static decimal AnnualBalanceUpdate(decimal balance) =>
        balance * (decimal)(1 + (InterestRate(balance) / 100));

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        var years = 0;
        var currentBalance = balance;
        while (currentBalance < targetBalance)
        {
            years++;
            currentBalance = AnnualBalanceUpdate(currentBalance);
        }
        return years;
    }
}
