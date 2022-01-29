using System.Text.RegularExpressions;

namespace Challenge.Common.Extensions
{
    /// <summary>
    /// String Common Extension
    /// </summary>
    public static class StringExtension
    {
        public static string RemoveSpaces<T>(this T data) => Regex.Replace(data.ToString(), @"\s", "");
    }
}
