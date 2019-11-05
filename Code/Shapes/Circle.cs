using System;

namespace Shapes
{
    public sealed class Circle : Shape
    {
        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentOutOfRangeException(nameof(radius), radius, "Must be strictly greater than zero!");

            Radius = radius;
        }

        public double Radius { get; }

        protected override double CalculateArea() =>
            Radius * Radius * Math.PI;
    }
}