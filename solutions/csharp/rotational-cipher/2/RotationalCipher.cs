using System.Reflection.PortableExecutable;

public static class RotationalCipher
{
    const char UpperUnicodeCharStart = 'A';
    const char LowerUnicodeCharStart = 'a';
    public static string Rotate(string text, int shiftKey) => text.Select(c =>
    c switch
        {
            _ when c is < 'A' or > 'z' => c,
            _ when char.IsUpper(c) => (char)(((c - UpperUnicodeCharStart + shiftKey) % 26) + UpperUnicodeCharStart),
            _ => (char)((c - LowerUnicodeCharStart + shiftKey) % 26 + LowerUnicodeCharStart)
        }
    ).Aggregate("", (str, c) => str + c);

}