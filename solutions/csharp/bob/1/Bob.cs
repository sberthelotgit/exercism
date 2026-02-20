
using System.Runtime.CompilerServices;

public static class Bob
{
    public static string Response(string statement)
    {
        var cleanStatement = statement.Trim();
        if (cleanStatement.Length == 0) return "Fine. Be that way!";
        var isQuestion = cleanStatement[cleanStatement.Length - 1] == '?';
        var text = isQuestion ? cleanStatement[..(cleanStatement.Length - 1)] : cleanStatement;
        var allCapital = text.FirstOrDefault(c => char.IsLetter(c) && !char.IsUpper(c)) == 0
            && text.FirstOrDefault(c => char.IsUpper(c)) != 0;
        return cleanStatement switch
        {
            _ when isQuestion && allCapital => "Calm down, I know what I'm doing!",
            _ when allCapital => "Whoa, chill out!",
            _ when isQuestion => "Sure.",
            _ => "Whatever."
        };
    }
}