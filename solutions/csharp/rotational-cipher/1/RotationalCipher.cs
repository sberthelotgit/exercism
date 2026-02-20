using System.Reflection.PortableExecutable;

public static class RotationalCipher
{
    const int UpperUnicodeCharStart = 64;
    const int lowerUnicodeCharStart = 97;
    public static string Rotate(string text, int shiftKey) => text.Select(c =>
    c switch
        {
            _ when c is < 'A' or > 'z' => c,
            _ when char.IsUpper(c) => (char)(((c - UpperUnicodeCharStart + shiftKey) % 26) + UpperUnicodeCharStart),
            _ => (char)((c - lowerUnicodeCharStart + shiftKey) % 26 + lowerUnicodeCharStart)
        }
    ).Aggregate("", (str, c) => str + c);

}