using System.Text.RegularExpressions;

namespace Track.Extensions
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Replace insensitive
        /// </summary>
        /// <param name="input"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static string ReplaceInsensitive(this string input, string oldValue, string newValue)
        {
            string result = Regex.Replace(
                input,
                Regex.Escape(oldValue),
                newValue.Replace("$", "$$"),
                RegexOptions.IgnoreCase
            );
            return result;
        }
    }
}