public static class LogAnalysis
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string text, string delimiter)
     => text[(text.IndexOf(delimiter) + delimiter.Length)..];

    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween(this string text, string start, string end)
        => text[(text.IndexOf(start) + start.Length)..text.IndexOf(end)];

    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string log)
        => log.SubstringAfter(": ");

    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string log)
        => log.SubstringBetween("[", "]");
}