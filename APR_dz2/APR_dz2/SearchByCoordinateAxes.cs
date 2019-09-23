using APR_dz1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz2
{
    public class SearchByCoordinateAxes
    {
        /// <summary>
        /// Delegate used for masking function with multiple variables to function with one variable.
        /// </summary>
        /// <param name="lambda">Value of new expression.</param>
        /// <returns>Value of function.</returns>

        public delegate double Expression(double lambda);

        private static String algorithmName = "Coordinate Descent";

        /// <summary>
        /// Finds minimum for function using Coordinate Descent Optimization algorithm.
        /// </summary>
        /// <param name="vector">Starting point.</param>
        /// <param name="e">Precision.</param>
        /// <param name="function">Function used in algorithm.</param>
        /// <param name="h">Shift used for getting unimodal interval.</param>
        /// <returns>Minimum of function.</returns>

        public static Matrica FindMinimum(Matrica vector, Matrica e, Function function, int h)
        {
            Matrica x = new Matrica();
            x.Equals(vector);
            Matrica xs = new Matrica();
            function.SetParametersSize(x.NoOfRows);

            do
            {
                xs = new Matrica();
                xs.Equals(x);
                for (int i = 0; i < vector.NoOfRows; i++)
                {
                    Matrica ei = new Matrica();
                    ei.NoOfColumns = 1;
                    ei.NoOfRows = vector.NoOfRows;
                    for (int j = 0; j < vector.NoOfRows; j++)
                    {
                        List<double> row = new List<double>();
                        if (i == j) row.Insert(0, 1);
                        else row.Insert(0, 0);
                        ei.LoadedMatrix.Add(j, row);
                    }

                    for (int j = 0; j < x.NoOfRows; j++)
                    {
                        double value = x.LoadedMatrix[j][0];
                        if (i == j)
                        {
                            Expression expression = lambda => value + lambda;
                            function.SetParameters(j, expression);
                        }
                        else
                        {
                            Expression expression = lambda => value;
                            function.SetParameters(j, expression);
                        }
                    }

                    UnimodalInterval interval = UnimodalInterval.FindUnimodalInterval(function, 0, h);
                    UnimodalInterval lambdaInterval = GoldenSection.FindMinimum(function, interval.Minimum, interval.Maximum, e.LoadedMatrix[i][0]);
                    double lambdaMin = (lambdaInterval.Minimum + lambdaInterval.Maximum) / 2;
                    ei.MultiplyByScalar(lambdaMin);
                    x.AddValue(ei);
                }
            } while (x.SubtractMatrices(xs).IsLessThanOrEqual(e));
            function.DeleteParameters();

            return x;
        }
    }
}
