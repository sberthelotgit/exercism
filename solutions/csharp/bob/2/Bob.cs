
using System.Runtime.CompilerServices;

public static class Bob
{
    public static string Response(string statement)
    {
        var cleanStatement = statement.Trim();
        var isQuestion = cleanStatement.EndsWith('?');
        var allCapital = cleanStatement.Any(char.IsLetter) && cleanStatement.ToUpperInvariant() == cleanStatement;
        return cleanStatement switch
        {
            _ when string.IsNullOrEmpty(cleanStatement) => "Fine. Be that way!",
            _ when isQuestion && allCapital => "Calm down, I know what I'm doing!",
            _ when allCapital => "Whoa, chill out!",
            _ when isQuestion => "Sure.",
            _ => "Whatever."
        };
    }
}