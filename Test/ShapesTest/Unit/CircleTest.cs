using Shapes;
using System;
using Xunit;

namespace ShapesTest.Unit
{
    public sealed class CircleTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void When_ProvidedRadiusEqualsOrLesserThanZero_Expect_Circle_ToThrow_ArgumentOutOfRangeException(double radius)
        {
            void Code()
            {
                var _ = new Circle(radius);
            }

            Assert.Throws<ArgumentOutOfRangeException>(Code);
        }

        [Theory]
        [InlineData(10, 314.1592653589793)]
        public void Expect_GetArea_ToReturn_Area(double radius, double expectedArea)
        {
            var sut = new Circle(radius);

            var actualArea = sut.GetArea();

            Assert.Equal(expectedArea, actualArea);
        }
    }
}