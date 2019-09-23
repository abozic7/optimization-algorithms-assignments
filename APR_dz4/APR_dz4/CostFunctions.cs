using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz4
{
    public class CostFunction1 : Function
    {
        /// <summary>
        /// Calculates value of function for given point.
        /// </summary>
        /// <param name="coordinates">Point for which we want to calculate function value.</param>
        /// <returns>Value of function.</returns>

        public override double CalculateValue(params double[] coordinates)
        {
            return 100 * Math.Pow(coordinates[1] - Math.Pow(coordinates[0], 2), 2) + Math.Pow(1 - coordinates[0], 2);
        }
    }

    public class CostFunction3 : Function
    {
        /// <summary>
        /// Calculates value of function for given point.
        /// </summary>
        /// <param name="coordinates">Point for which we want to calculate function value.</param>
        /// <returns>Value of function.</returns>

        public override double CalculateValue(params double[] coordinates)
        {
            double sum = 0;

            for (int i = 0; i < coordinates.Length; i++)
            {
                sum += Math.Pow(coordinates[i] - (i + 1), 2);
            }
            return sum;
        }
    }

    public class CostFunction6 : Function
    {
        /// <summary>
        /// Calculates value of function for given point.
        /// </summary>
        /// <param name="coordinates">Point for which we want to calculate function value.</param>
        /// <returns>Value of function.</returns>

        public override double CalculateValue(params double[] coordinates)
        {
            double sum = 0;
            
            for (int i = 0; i < coordinates.Length; i++)
            {
                sum += Math.Pow(coordinates[i], 2);
            }

            return 0.5 + (Math.Pow(Math.Sin(Math.Sqrt(sum)), 2) - 0.5) / Math.Pow(1 + 0.001 * sum, 2);
        }
    }

    public class CostFunction7 : Function
    {
        /// <summary>
        /// Calculates value of function for given point.
        /// </summary>
        /// <param name="coordinates">Point for which we want to calculate function value.</param>
        /// <returns>Value of function.</returns>

        public override double CalculateValue(params double[] coordinates)
        {
            double sum = 0;

            for (int i = 0; i < coordinates.Length; i++)
            {
                sum += Math.Pow(coordinates[i], 2);
            }

            return Math.Pow(sum, 0.25) * (1 + Math.Pow(Math.Sin(50 * Math.Pow(sum, 0.1)), 2));
        }
    }
}
