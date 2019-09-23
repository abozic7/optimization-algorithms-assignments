using System;

namespace APR_dz2
{
    public class GoalFunction1 : Function
    {
        /// <summary>
        /// Calculates value of function for given point.
        /// </summary>
        /// <param name="coordinates">Point for which we want to calculate function value.</param>
        /// <returns>Value of function.</returns>

        public override double CalculateValue(params double[] coordinates)
        {
            if(coordinates.Length == 1 && parameters != null)
            {
                SearchByCoordinateAxes.Expression expression0 = parameters[0];
                SearchByCoordinateAxes.Expression expression1 = parameters[1];
                double x0 = expression0(coordinates[0]);
                double x1 = expression1(coordinates[0]);
                return 100 * Math.Pow(x1 - Math.Pow(x0, 2), 2) + Math.Pow(1 - x0, 2);
            }
            else
            {
                return 100 * Math.Pow(coordinates[1] - Math.Pow(coordinates[0], 2), 2) + Math.Pow(1 - coordinates[0], 2);
            }
        }
    }

    public class GoalFunction2 : Function
    {
        /// <summary>
        /// Calculates value of function for given point.
        /// </summary>
        /// <param name="coordinates">Point for which we want to calculate function value.</param>
        /// <returns>Value of function.</returns>

        public override double CalculateValue(params double[] coordinates)
        {
            if(coordinates.Length == 1 && parameters != null)
            {
                SearchByCoordinateAxes.Expression expression0 = parameters[0];
                SearchByCoordinateAxes.Expression expression1 = parameters[1];
                double x0 = expression0(coordinates[0]);
                double x1 = expression1(coordinates[0]);
                return Math.Pow(x0 - 4, 2) + 4 * Math.Pow(x1 - 2, 2);
            }
            else
            {
                return Math.Pow(coordinates[0] - 4, 2) + 4 * Math.Pow(coordinates[1] - 2, 2);
            }
        }
    }

    public class GoalFunction3 : Function
    {
        /// <summary>
        /// Calculates value of function for given point.
        /// </summary>
        /// <param name="coordinates">Point for which we want to calculate function value.</param>
        /// <returns>Value of function.</returns>

        public override double CalculateValue(params double[] coordinates)
        {
            double sum = 0;
            if (coordinates.Length == 1 && parameters != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    SearchByCoordinateAxes.Expression expression = parameters[i];
                    double xi = expression(coordinates[0]);
                    sum += Math.Pow(xi - (i+1), 2);
                }
            }
            else
            {
                for (int i = 0; i < coordinates.Length; i++)
                {
                    sum += Math.Pow(coordinates[i] - (i+1), 2);
                }
            }
            return sum;
        }
    }

    public class GoalFunction4 : Function
    {
        /// <summary>
        /// Calculates value of function for given point.
        /// </summary>
        /// <param name="coordinates">Point for which we want to calculate function value.</param>
        /// <returns>Value of function.</returns>

        public override double CalculateValue(params double[] coordinates)
        {
            if(coordinates.Length == 1 && parameters != null)
            {
                SearchByCoordinateAxes.Expression expression0 = parameters[0];
                SearchByCoordinateAxes.Expression expression1 = parameters[1];
                double x0 = expression0(coordinates[0]);
                double x1 = expression1(coordinates[0]);
                return Math.Abs((x0 - x1) * (x0 + x1)) + Math.Sqrt(Math.Pow(x0, 2) + Math.Pow(x1, 2));
            }
            else
            {
                return Math.Abs((coordinates[0] - coordinates[1]) * (coordinates[0] + coordinates[1]))
                    + Math.Sqrt(Math.Pow(coordinates[0], 2) + Math.Pow(coordinates[1], 2));
            }
        }
    }

    public class GoalFunction6 : Function
    {
        /// <summary>
        /// Calculates value of function for given point.
        /// </summary>
        /// <param name="coordinates">Point for which we want to calculate function value.</param>
        /// <returns>Value of function.</returns>

        public override double CalculateValue(params double[] coordinates)
        {
            double sum = 0;
            if (coordinates.Length == 1 && parameters != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    SearchByCoordinateAxes.Expression expression = parameters[i];
                    double xi = expression(coordinates[0]);
                    sum += Math.Pow(xi, 2);
                }
            }
            else
            {
                for (int i = 0; i < coordinates.Length; i++)
                {
                    sum += Math.Pow(coordinates[i], 2);
                }
            }

            return 0.5 + (Math.Pow(Math.Sin(sum), 2) - 0.5) / Math.Pow(1 + 0.001 * sum, 2);
        }
    }

    public class GoalFunctionZad1 : Function
    {
        /// <summary>
        /// Calculates value of function for given point.
        /// </summary>
        /// <param name="coordinates">Point for which we want to calculate function value.</param>
        /// <returns>Value of function.</returns>

        public override double CalculateValue(params double[] coordinates)
        {
            if (coordinates.Length == 1 && parameters != null)
            {
                SearchByCoordinateAxes.Expression expression = parameters[0];
                double x0 = expression(coordinates[0]);
                return Math.Pow(x0 - 3, 2);
            }
            else
            {
                return Math.Pow(coordinates[0] - 3, 2);
            }
        }
    }
}
