namespace Elfland.Core.Collections.Extensions;

public static class CollectionExtensions
{
    public static string ToDisplayString<T>(this IEnumerable<T> ary) =>
        $"[{string.Join(", ", ary)}]";

    public static IEnumerable<string> ToDisplayStrings<TKey, TValue>(
        this IDictionary<TKey, TValue> dict
    ) => dict.Select(element => $"{{\"{element.Key} \": \"{element.Value}\"}}");
}
