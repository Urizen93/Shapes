using Shapes;
using System;
using Xunit;

namespace ShapesTest.Unit
{
    public sealed class ShapeTest
    {
        [Fact]
        public void Expect_GetArea_ToReturn_ResultOfCalculateArea()
        {
            const double expected = 1;
            var sut = new ShapeStub(expected);

            var actual = sut.GetArea();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(NanAndInfinities))]
        public void When_CalculateAreaReturnsNanOrInfinity_Expect_GetArea_ToThrow_InvalidOperationException(double calculateAreaResult)
        {
            var sut = new ShapeStub(calculateAreaResult);

            void Code()
            {
                var _ = sut.GetArea();
            }

            Assert.Throws<InvalidOperationException>(Code);
        }

        public static TheoryData<double> NanAndInfinities => new TheoryData<double>
        {
            double.NaN, double.PositiveInfinity, double.NegativeInfinity
        };

        private sealed class ShapeStub : Shape
        {
            private readonly double _calculateAreaResult;

            public ShapeStub(double calculateAreaResult) => _calculateAreaResult = calculateAreaResult;

            protected override double CalculateArea() => _calculateAreaResult;
        }
    }
}