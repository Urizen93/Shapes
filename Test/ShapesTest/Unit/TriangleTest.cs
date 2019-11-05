using Shapes;
using System;
using Xunit;

namespace ShapesTest.Unit
{
    public sealed class TriangleTest
    {
        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(-1, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(1, -1, 1)]
        [InlineData(1, 1, 0)]
        [InlineData(1, 1, -1)]
        public void When_AnyOfTheEdgesIsEqualsOrLesserThanZero_Expect_Triangle_ToThrow_ArgumentOutOfRangeException(
            double a, double b, double c)
        {
            void Code()
            {
                var _ = new Triangle(a, b, c);
            }

            Assert.Throws<ArgumentOutOfRangeException>(Code);
        }

        [Theory]
        [InlineData(5, 10, 15)]
        [InlineData(10, 15, 5)]
        [InlineData(15, 5, 10)]
        public void When_SumOfAnyOfTwoSidesGreaterThanThird_Expect_Triangle_ToThrow_ArgumentException(
            double a, double b, double c)
        {
            void Code()
            {
                var _ = new Triangle(a, b, c);
            }

            Assert.Throws<ArgumentException>(Code);
        }

        [Theory]
        [InlineData(18, 24, 30, 216)]
        public void Expect_GetArea_ToReturn_Area(double a, double b, double c, double expectedArea)
        {
            var sut = new Triangle(a, b, c);

            var actualArea = sut.GetArea();

            Assert.Equal(expectedArea, actualArea);
        }

        [Theory]
        [InlineData(8, 15, 17)]
        public void When_TriangleIsRightAngled_Expect_IsRightAngled_ToReturn_True(double a, double b, double c)
        {
            var sut = new Triangle(a, b, c);

            var isRightAngled = sut.IsRightAngled;

            Assert.True(isRightAngled);
        }

        [Theory]
        [InlineData(8, 15, 18)]
        public void When_TriangleIsNotRightAngled_Expect_IsRightAngled_ToReturn_False(double a, double b, double c)
        {
            var sut = new Triangle(a, b, c);

            var isRightAngled = sut.IsRightAngled;

            Assert.False(isRightAngled);
        }
    }
}