using System.Collections.Generic;

namespace Mjcheetham
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Take all elements in the sequence except the last <paramref name="n"/> elements.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="n"/> is less than zero</exception>
        /// <typeparam name="T">Type of each element</typeparam>
        /// <param name="source">Source element sequence</param>
        /// <param name="n">Number of elements to skip from the end of the sequence</param>
        /// <returns>All elements except the last <paramref name="n"/>.</returns>
        public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> source, int n)
        {
            ArgumentAssert.NotNull(source, nameof(source));
            ArgumentAssert.NonNegative(n, nameof(n));

            var q = new Queue<T>(n + 1);
            using (var @enum = source.GetEnumerator())
            {
                while (@enum.MoveNext())
                {
                    q.Enqueue(@enum.Current);
                    if (q.Count > n)
                    {
                        yield return q.Dequeue();
                    }
                }
            }
        }
    }
}
