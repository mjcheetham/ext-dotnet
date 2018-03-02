namespace Mjcheetham
{
    public static class StringExtensions
    {
        /// <summary>
        /// Truncate a string to a maximum length.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string Truncate(this string str, int maxLength)
        {
            ArgumentAssert.NotNull(str, nameof(str));
            ArgumentAssert.NonNegative(maxLength, nameof(maxLength));

            if (maxLength == 0)
            {
                return string.Empty;
            }

            if (str.Length <= maxLength)
            {
                return str;
            }

            return str.Substring(0, maxLength);
        }
    }
}
