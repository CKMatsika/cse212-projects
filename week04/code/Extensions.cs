using System.Collections.Generic;
using System.Linq;

/// <summary>
/// A static class to hold custom extension methods.
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Converts an IEnumerable collection to a specific string format for testing.
    /// Example: "<IEnumerable>{1, 2, 3}"
    /// </summary>
    /// <param name="items">The collection to convert.</param>
    /// <returns>A formatted string representation of the collection.</returns>
    public static string AsString(this IEnumerable<int> items)
    {
        return "<IEnumerable>{" + string.Join(", ", items) + "}";
    }
}