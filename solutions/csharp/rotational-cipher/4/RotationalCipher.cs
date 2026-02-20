using System.Reflection.PortableExecutable;

public static class RotationalCipher
{
    const char UpperUnicodeCharStart = 'A';
    const char LowerUnicodeCharStart = 'a';
    public static string Rotate(string text, int shiftKey) => new string(text.Select(c =>
    c switch
        {
            _ when !char.IsLetter(c) => c,
            _ when char.IsUpper(c) => (char)(((c - UpperUnicodeCharStart + shiftKey) % 26) + UpperUnicodeCharStart),
            _ => (char)((c - LowerUnicodeCharStart + shiftKey) % 26 + LowerUnicodeCharStart)
        }
    ).ToArray());

}