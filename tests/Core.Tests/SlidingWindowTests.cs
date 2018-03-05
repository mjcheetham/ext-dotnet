using Xunit;

namespace Mjcheetham.Tests
{
    public class SlidingWindowTests
    {
        [Fact(DisplayName = nameof(SlideNext_SlidesWindowByOne))]
        public void SlideNext_SlidesWindowByOne()
        {
            var sequence = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            using (SlidingWindow<int> window = sequence.GetSlidingWindow(3))
            {
                AssertWindow(window, 1, 2, 3);

                Assert.True(window.SlideNext());
                AssertWindow(window, 2, 3, 4);

                Assert.True(window.SlideNext());
                AssertWindow(window, 3, 4, 5);

                Assert.True(window.SlideNext());
                AssertWindow(window, 4, 5, 6);

                Assert.True(window.SlideNext());
                AssertWindow(window, 5, 6, 7);

                Assert.True(window.SlideNext());
                AssertWindow(window, 6, 7, 8);

                Assert.True(window.SlideNext());
                AssertWindow(window, 7, 8, 9);

                Assert.True(window.SlideNext());
                AssertWindow(window, 8, 9, 10);
            }
        }

        private static void AssertWindow<T>(SlidingWindow<T> window, params T[] expectedValues)
        {
            Assert.Equal(window.WindowSize, expectedValues.Length);

            for (int i = 0; i < expectedValues.Length; i++)
            {
                Assert.Equal(expectedValues[i], window[i]);
            }
        }
    }
}
