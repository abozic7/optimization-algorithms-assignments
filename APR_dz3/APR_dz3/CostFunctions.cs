using APR_dz1;
using System;

namespace APR_dz3
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
            if (coordinates.Length == 1 && parameters != null)
            {
                FunctionOptimization.Expression expression0 = parameters[0];
                FunctionOptimization.Expression expression1 = parameters[1];
                double x0 = expression0(coordinates[0]);
                double x1 = expression1(coordinates[0]);
                return 100 * Math.Pow(x1 - Math.Pow(x0, 2), 2) + Math.Pow(1 - x0, 2);
            }
            else
            {
                return 100 * Math.Pow(coordinates[1] - Math.Pow(coordinates[0], 2), 2) + Math.Pow(1 - coordinates[0], 2);
            }
        }

        /// <summary>
        /// Calculates value of gradient for given point.
        /// </summary>
        /// <param name="coordinates">Point for which we want to calculate gradient value.</param>
        /// <returns>Gradient of function.</returns>

        public override Matrica CalculateGradientValue(params double[] coordinates)
        {
            double[] result = new double[2];

            result[0] = ((-400) * coordinates[0]) * (coordinates[1] - (coordinates[0] * coordinates[0])) - 2 * (1 - coordinates[0]);
            result[1] = 200 * (coordinates[1] - (coordinates[0] * coordinates[0]));

            SetGradientNorm(Math.Sqrt(Math.Pow(result[0], 2) + Math.Pow(result[1], 2)));

            return Matrica.ArrayToVector(result);
        }

        /// <summary>
        /// Calculates value of Hessian matrix for given point.
        /// </summary>
        /// <param name="coordinates">Point for which we want to calculate Hessian matrix.</param>
        /// <returns>Hessian matrix of function.</returns>

        public override Matrica CalculateHessianMatrix(params double[] coordinates)
        {
            double[][] result = new double[2][];
            result[0] = new double[2];
            result[1] = new double[2];

            result[0][0] = (-400) * (coordinates[1] - 3 * (coordinates[0] * coordinates[0])) + 2;
            result[0][1] = (-400) * coordinates[0];
            result[1][0] = (-400) * coordinates[0];
            result[1][1] = 200;

            return new Matrica(result);
        }
    }

    public class CostFunction2 : Function
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
                FunctionOptimization.Expression expression0 = parameters[0];
                FunctionOptimization.Expression expression1 = parameters[1];
                double x0 = expression0(coordinates[0]);
                double x1 = expression1(coordinates[0]);
                return Math.Pow(x0 - 4, 2) + 4 * Math.Pow(x1 - 2, 2);
            }
            else
            {
                return Math.Pow(coordinates[0] - 4, 2) + 4 * Math.Pow(coordinates[1] - 2, 2);
            }
        }

        /// <summary>
        /// Calculates value of gradient for given point.
        /// </summary>
        /// <param name="coordinates">Point for which we want to calculate gradient value.</param>
        /// <returns>Gradient of function.</returns>

        public override Matrica CalculateGradientValue(params double[] coordinates)
        {
            double[] result = new double[2];

            result[0] = 2 * (coordinates[0] - 4);
            result[1] = 8 * (coordinates[1] - 2);

            SetGradientNorm(Math.Sqrt(Math.Pow(result[0], 2) + Math.Pow(result[1], 2)));

            return Matrica.ArrayToVector(result);
        }

        /// <summary>
        /// Calculates value of Hessian matrix for given point.
        /// </summary>
        /// <param name="coordinates">Point for which we want to calculate Hessian matrix.</param>
        /// <returns>Hessian matrix of function.</returns>

        public override Matrica CalculateHessianMatrix(params double[] coordinates)
        {
            double[][] result = new double[2][];
            result[0] = new double[2];
            result[1] = new double[2];

            result[0][0] = 2;
            result[0][1] = 0;
            result[1][0] = 0;
            result[1][1] = 8;

            return new Matrica(result);
        }
    }

    public class CostFunction3 : Function
    {
        /// <summary>
        /// Calculates value of function for given point.
        /// </summary>
        /// <param name="coordinates">Point for which we want to calculate function value.</param>
        /// <returns>Value of function.</returns>
        /// 
        public override double CalculateValue(params double[] coordinates)
        {
            if (coordinates.Length == 1 && parameters != null)
            {
                FunctionOptimization.Expression expression0 = parameters[0];
                FunctionOptimization.Expression expression1 = parameters[1];
                double x0 = expression0(coordinates[0]);
                double x1 = expression1(coordinates[0]);
                return Math.Pow(x0 - 2, 2) + Math.Pow(x1 + 3, 2);
            }
            else
            {
                return Math.Pow(coordinates[0] - 2, 2) + Math.Pow(coordinates[1] + 3, 2);
            }
        }

        /// <summary>
        /// Calculates value of gradient for given point.
        /// </summary>
        /// <param name="coordinates">Point for which we want to calculate gradient value.</param>
        /// <returns>Gradient of function.</returns>

        public override Matrica CalculateGradientValue(params double[] coordinates)
        {
            double[] result = new double[2];

            result[0] = 2 * (coordinates[0] - 2);
            result[1] = 2 * (coordinates[1] + 3);

            SetGradientNorm(Math.Sqrt(Math.Pow(result[0], 2) + Math.Pow(result[1], 2)));

            return Matrica.ArrayToVector(result);
        }

        /// <summary>
        /// Calculates value of Hessian matrix for given point.
        /// </summary>
        /// <param name="coordinates">Point for which we want to calculate Hessian matrix.</param>
        /// <returns>Hessian matrix of function.</returns>

        public override Matrica CalculateHessianMatrix(params double[] coordinates)
        {
            double[][] result = new double[2][];
            result[0] = new double[2];
            result[1] = new double[2];

            result[0][0] = 2;
            result[0][1] = 0;
            result[1][0] = 0;
            result[1][1] = 2;

            return new Matrica(result);
        }
    }

    public class CostFunction4 : Function
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
                FunctionOptimization.Expression expression0 = parameters[0];
                FunctionOptimization.Expression expression1 = parameters[1];
                double x0 = expression0(coordinates[0]);
                double x1 = expression1(coordinates[0]);
                return Math.Pow(x0 - 3, 2) + Math.Pow(x1, 2);
            }
            else
            {
                return Math.Pow(coordinates[0] - 3, 2) + Math.Pow(coordinates[1], 2);
            }
        }

        /// <summary>
        /// Calculates value of gradient for given point.
        /// </summary>
        /// <param name="coordinates">Point for which we want to calculate gradient value.</param>
        /// <returns>Gradient of function.</returns>

        public override Matrica CalculateGradientValue(params double[] coordinates)
        {
            double[] result = new double[2];

            result[0] = 2 * (coordinates[0] - 3);
            result[1] = 2 * coordinates[1];

            SetGradientNorm(Math.Sqrt(Math.Pow(result[0], 2) + Math.Pow(result[1], 2)));

            return Matrica.ArrayToVector(result);
        }

        /// <summary>
        /// Calculates value of Hessian matrix for given point.
        /// </summary>
        /// <param name="coordinates">Point for which we want to calculate Hessian matrix.</param>
        /// <returns>Hessian matrix of function.</returns>

        public override Matrica CalculateHessianMatrix(params double[] coordinates)
        {
            double[][] result = new double[2][];
            result[0] = new double[2];
            result[1] = new double[2];

            result[0][0] = 2;
            result[0][1] = 0;
            result[1][0] = 0;
            result[1][1] = 2;

            return new Matrica(result);
        }
    }
}
