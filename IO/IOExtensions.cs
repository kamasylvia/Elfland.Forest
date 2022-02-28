namespace Elfland.Core.IO.Extensions;

public static class IOExtensions
{
    public static string ToBase64String(this string filePath) =>
        Convert.ToBase64String(File.ReadAllBytes(filePath));

    public static string ToBase64String(this byte[] bytes) => Convert.ToBase64String(bytes);

    public static string ToBase64String(this Stream stream)
    {
        using var memoryStream = new MemoryStream();
        stream.CopyTo(memoryStream);
        return memoryStream.ToArray().ToBase64String();
    }
}
