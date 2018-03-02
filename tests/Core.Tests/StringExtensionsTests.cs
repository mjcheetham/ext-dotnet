using System;
using Xunit;

namespace Mjcheetham.Tests
{
    public class StringExtensionsTests
    {
        [Fact(DisplayName = nameof(Truncate_NegativeMaxLength_Throws))]
        public void Truncate_NegativeMaxLength_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => StringExtensions.Truncate("string", -1));
        }

        [Theory(DisplayName = nameof(Truncate_ValidString_TruncatesString))]
        [InlineData("A test string!", 14, "A test string!")]
        [InlineData("A test string!", 13, "A test string")]
        [InlineData("A test string!", 12, "A test strin")]
        [InlineData("A test string!", 11, "A test stri")]
        [InlineData("A test string!",  3, "A t")]
        [InlineData("A test string!",  2, "A ")]
        [InlineData("A test string!",  1, "A")]
        [InlineData("A test string!",  0, "")]
        public void Truncate_ValidString_TruncatesString(string input, int maxLength, string expected)
        {
            string actual = StringExtensions.Truncate(input, maxLength);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Truncate_NullString_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => StringExtensions.Truncate(null, 1));
        }
    }
}
