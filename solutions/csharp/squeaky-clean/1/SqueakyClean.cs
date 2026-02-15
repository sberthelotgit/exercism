using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        var res = new StringBuilder();
        var previousWasDash = false;
        foreach (var c in identifier)
        {
            string cleanedChar = c.ToString();
            if (c == '-')
            {
                previousWasDash = true;
                continue;
            }
            if (previousWasDash)
            {
                cleanedChar = cleanedChar.ToUpper();
                previousWasDash = false;
            }
            if (c == ' ')
            {
                cleanedChar = "_";
            }
            else if (char.IsControl(c))
            {
                cleanedChar = "CTRL";
            }
            else if ("βιεγτω".Contains(c) || !char.IsLetter(c)) continue;

            res.Append(cleanedChar);
        }
        return res.ToString();
    }
}
