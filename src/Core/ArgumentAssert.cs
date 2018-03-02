using System;
using System.Runtime.CompilerServices;

namespace Mjcheetham
{
    /// <summary>
    /// Helper class for argument validation.
    /// </summary>
    /// <remarks>All methods are aggressively inlined.</remarks>
    public static class ArgumentAssert
    {
        #region Integer

        /// <summary>
        /// Ensure <paramref name="n"/> is not zero.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="n"/> is zero</exception>
        /// <param name="n">Integer value to check</param>
        /// <param name="name">Argument name</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NonZero(long n, string name)
        {
            if (n == 0) throw new ArgumentOutOfRangeException(name);
        }

        /// <summary>
        /// Ensure <paramref name="n"/> is not negative.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="n"/> is negative</exception>
        /// <param name="n">Integer value to check</param>
        /// <param name="name">Argument name</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NonNegative(long n, string name) => GreaterThanOrEqual(n, 0, name);

        /// <summary>
        /// Ensure <paramref name="n"/> is strictly positive (not negative and not zero).
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="n"/> is negative or zero</exception>
        /// <param name="n">Integer value to check</param>
        /// <param name="name">Argument name</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void PositiveNonZero(long n, string name) => GreaterThan(n, 0, name);

        /// <summary>
        /// Ensure <paramref name="n"/> is strictly greater than <paramref name="limit"/>.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="n"/> is less than or equal to <paramref name="limit"/></exception>
        /// <param name="n">Integer value to check</param>
        /// <param name="name">Argument name</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GreaterThan(long n, int limit, string name)
        {
            if (n <= limit) throw new ArgumentOutOfRangeException(name);
        }

        /// <summary>
        /// Ensure <paramref name="n"/> is greater than or equal to <paramref name="limit"/>.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="n"/> is strictly less than <paramref name="limit"/></exception>
        /// <param name="n">Integer value to check</param>
        /// <param name="name">Argument name</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GreaterThanOrEqual(long n, long limit, string name)
        {
            if (n < limit) throw new ArgumentOutOfRangeException(name);
        }

        /// <summary>
        /// Ensure <paramref name="n"/> is strictly less than <paramref name="limit"/>.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="n"/> is greater than or equal to <paramref name="limit"/></exception>
        /// <param name="n">Integer value to check</param>
        /// <param name="name">Argument name</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LessThan(long n, long limit, string name)
        {
            if (n >= limit) throw new ArgumentOutOfRangeException(name);
        }

        /// <summary>
        /// Ensure <paramref name="n"/> is less than or equal to <paramref name="limit"/>.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="n"/> is strictly less than <paramref name="limit"/></exception>
        /// <param name="n">Integer value to check</param>
        /// <param name="name">Argument name</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LessThanOrEqual(long n, long limit, string name)
        {
            if (n > limit) throw new ArgumentOutOfRangeException(name);
        }

        #endregion

        #region Null

        /// <summary>
        /// Ensure <paramref name="obj"/> is not null.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="obj"/> is null</exception>
        /// <typeparam name="T">Type of reference</typeparam>
        /// <param name="obj">Reference to check for null</param>
        /// <param name="name">Argument name</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NotNull<T>(T obj, string name) where T : class
        {
            if (obj == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        /// <summary>
        /// Ensure <paramref name="str"/> is not null or an empty string.
        /// </summary>
        /// <remarks>See <seealso cref="string.IsNullOrEmpty(string)"/></remarks>
        /// <exception cref="ArgumentNullException"><paramref name="str"/> is null or empty</exception>
        /// <typeparam name="T">Type of reference</typeparam>
        /// <param name="obj">Reference to check for null or empty</param>
        /// <param name="name">Argument name</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NotNullOrEmpty(string str, string name)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException(name);
            }
        }

        /// <summary>
        /// Ensure <paramref name="str"/> is not null or white space.
        /// </summary>
        /// <remarks>See <seealso cref="string.IsNullOrWhiteSpace(string)"/></remarks>
        /// <exception cref="ArgumentNullException"><paramref name="str"/> is null or white space</exception>
        /// <typeparam name="T">Type of reference</typeparam>
        /// <param name="obj">Reference to check for null or white space</param>
        /// <param name="name">Argument name</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NotNullOrWhiteSpace(string str, string name)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentNullException(name);
            }
        }

        #endregion
    }
}
