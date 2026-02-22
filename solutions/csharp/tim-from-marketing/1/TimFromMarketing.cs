using System.Text;

static class Badge
{
    public static string Print(int? id, string name, string? department)
        // => $"{(id != null ? "[" + id + "] - " : "")}{name} - {(department ?? "Owner").ToUpper()}";
        => new StringBuilder(id != null ? "[" + id + "] - " : "")
            .Append(name).Append(" - ")
            .Append((department ?? "Owner").ToUpper())
            .ToString();

}
