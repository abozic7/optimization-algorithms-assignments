using APR_dz1;
using APR_dz2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static APR_dz3.FunctionOptimization;

namespace APR_dz3
{
    public class GradientDescent
    {
        private static String algorithmName = "Gradient Descent";

        /// <summary>
        /// Finds minimum of given function using the Gradient Descent algorithm.
        /// </summary>
        /// <param name="function">Function used in algorithm.</param>
        /// <param name="e">Precision.</param>
        /// <param name="startingPoint">Starting point of algorithm.</param>
        /// <param name="usingGoldenSection">Flag used for tracking whether user wants to use Golden Section algorithm or not.</param>
        /// <returns>Minimum of function.</returns>

        public static Matrica FindMinimum(Function function, double e, Matrica startingPoint, bool usingGoldenSection)
        {
            Matrica x = new Matrica();
            x.Equals(startingPoint);
            function.SetParametersSize(x.NoOfRows);
            Matrica v = new Matrica();
            int brojac = 0;
            Matrica xs = new Matrica();

            if (usingGoldenSection == false)
            {
                do
                {
                    xs.Equals(x);
                    v = function.CalculateGradientValue(x.VectorToArray());
                    function.IncreaseCounterGradientValue(algorithmName);
                    v.MultiplyByScalar(-1);
                    x.AddValue(v);
                    brojac++;
                    function.IncreaseCounterValue(algorithmName);
                    function.IncreaseCounterValue(algorithmName);
                } while (brojac < 10000);
            }
            else
            {
                do
                {
                    xs.Equals(x);
                    v = function.CalculateGradientValue(x.VectorToArray());
                    function.IncreaseCounterGradientValue(algorithmName);
                    v.MultiplyByScalar(-1);
                    v.MultiplyByScalar(1.0 / function.GetGradientNorm());
                    for (int i = 0; i < x.NoOfRows; i++)
                    {
                        double value = x.LoadedMatrix[i][0];
                        double vectorValue = v.LoadedMatrix[i][0];
                        Expression expression = lambda => value + lambda * vectorValue;
                        function.SetParameters(i, expression);
                    }

                    UnimodalInterval interval = UnimodalInterval.FindUnimodalInterval(function, 0, 1, algorithmName);
                    UnimodalInterval lambdaInterval = GoldenSection.FindMinimum(function, interval.Minimum, interval.Maximum, e, algorithmName);

                    double lambdaMin = (lambdaInterval.Minimum + lambdaInterval.Maximum) / 2;
                    v.MultiplyByScalar(lambdaMin);
                    x.AddValue(v);

                    function.IncreaseCounterValue(algorithmName);
                    function.IncreaseCounterValue(algorithmName);
                } while (function.GetGradientNorm() >= e);
            }

            function.DeleteParameters();
            return x;
        }
    }
}
