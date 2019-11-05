using System;
using System.Diagnostics.Contracts;

namespace Shapes
{
    public sealed class Triangle : Shape
    {
        public Triangle(double a, double b, double c)
        {
            if (a <= 0)
                throw new ArgumentOutOfRangeException(nameof(a), a, "Must be strictly greater than zero!");
            if (b <= 0)
                throw new ArgumentOutOfRangeException(nameof(b), b, "Must be strictly greater than zero!");
            if (c <= 0)
                throw new ArgumentOutOfRangeException(nameof(c), c, "Must be strictly greater than zero!");

            if (a + b <= c || a + c <= b || b + c <= a)
                throw new ArgumentException("Impossible triangle: sum of each two sides must be greater than third side!");

            A = a;
            B = b;
            C = c;
        }

        public double A { get; }

        public double B { get; }

        public double C { get; }

        public bool IsRightAngled =>
            IsFirstPassedEdgeHypotenuse(A, B, C)
            || IsFirstPassedEdgeHypotenuse(B, A, C)
            || IsFirstPassedEdgeHypotenuse(C, A, B);

        protected override double CalculateArea()
        {
            var halfPerimeter = (A + B + C) / 2;
            var product = halfPerimeter * (halfPerimeter - A) * (halfPerimeter - B) * (halfPerimeter - C);
            return Math.Sqrt(product);
        }

        [Pure]
        private static bool IsFirstPassedEdgeHypotenuse(double potentialHypotenuse, double firstCathet, double secondCathet) =>
            AreEqualWithTolerance(
                potentialHypotenuse * potentialHypotenuse,
                firstCathet * firstCathet + secondCathet * secondCathet);

        [Pure]
        public static bool AreEqualWithTolerance(double x, double y) =>
            Math.Abs(x - y) <= .00000001;
    }
}