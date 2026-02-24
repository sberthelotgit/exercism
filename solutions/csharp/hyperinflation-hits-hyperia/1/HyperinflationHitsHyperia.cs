public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {

        try
        {
            checked
            {
                return (@base * multiplier).ToString();
            }
        }
        catch
        {
            return "*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        try
        {
            checked
            {
                var result = (@base * multiplier).ToString();
                if (result == "Infinity") throw new OverflowException();
                return result;
            }
        }
        catch
        {
            return "*** Too Big ***";
        }
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try
        {
            checked
            {
                return (@salaryBase * multiplier).ToString();
            }
        }
        catch
        {
            return "*** Much Too Big ***";
        }
    }
}
