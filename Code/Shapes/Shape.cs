using System;
using System.Diagnostics.Contracts;

namespace Shapes
{
    public abstract class Shape
    {
        /// <summary>
        /// <exception cref="InvalidOperationException"/>
        /// </summary>
        [Pure]
        public double GetArea()
        {
            var result = CalculateArea();
            var isNaNOrInfinity = double.IsNaN(result) || double.IsInfinity(result);

            return isNaNOrInfinity
                ? throw new InvalidOperationException(
                    "Unable to calculate the area! Value cannot be NaN or infinity!")
                : result;
        }

        [Pure]
        protected abstract double CalculateArea();
    }
}
