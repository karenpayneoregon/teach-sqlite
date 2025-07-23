using System.Diagnostics;
using System.Text.RegularExpressions;

namespace NorthWindCategories.Classes;
public static partial class StringExtensions
{
    /// <summary>
    /// Splits a PascalCase or camelCase string into separate words.
    /// </summary>
    /// <param name="sender">The input string to be split.</param>
    /// <returns>A string where the words in the input are separated by spaces.</returns>

    [DebuggerStepThrough]
    public static string SplitCase(this string sender) =>
        string.Join(" ", CaseRegEx().Matches(sender)
            .Select(m => m.Value));

    [GeneratedRegex(@"([A-Z][a-z]+)")]
    private static partial Regex CaseRegEx();
}
