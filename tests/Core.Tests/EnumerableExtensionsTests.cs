using System;
using System.Linq;
using Xunit;

namespace Mjcheetham.Tests
{
    public class EnumerableExtensionsTests
    {
        [Fact(DisplayName = nameof(SkipLast_OverLargeN_SkipsAllElements))]
        public void SkipLast_OverLargeN_SkipsAllElements()
        {
            Assert.Empty(new[] { 0 }.SkipLast(2));
        }

        [Theory(DisplayName = nameof(SkipLast_PositiveN_SkipsNLastElements))]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, 1, new[] { 1, 2, 3, 4 })]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, 2, new[] { 1, 2, 3 })]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, 3, new[] { 1, 2 })]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, 4, new[] { 1 })]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, 5, new int[0])]
        public void SkipLast_PositiveN_SkipsNLastElements(int[] source, int n, int[] expected)
        {
            Assert.Equal(expected, source.SkipLast(n));
        }

        [Fact(DisplayName = nameof(SkipLast_NegativeN_Throws))]
        public void SkipLast_NegativeN_Throws()
        {
            var source = Enumerable.Range(0, 3);
            Assert.Throws<ArgumentOutOfRangeException>(() => EnumerableExtensions.SkipLast(source, -1).ToArray());
        }

        [Fact(DisplayName = nameof(SkipLast_NullSource_Throws))]
        public void SkipLast_NullSource_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => EnumerableExtensions.SkipLast<object>(null, 0).ToArray());
        }
    }
}
