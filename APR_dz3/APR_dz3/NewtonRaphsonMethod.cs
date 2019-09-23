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
    public class NewtonRaphsonMethod
    {
        private static String algorithmName = "Newton-Raphson Method";

        /// <summary>
        /// Finds minimum of function using Newton-Raphson algorithm.
        /// </summary>
        /// <param name="function">Function used in algorithm.</param>
        /// <param name="e">Precision</param>
        /// <param name="startingPoint">Starting point of algorithm.</param>
        /// <param name="usingGoldenSection">Flag used for tracking whether user wants to use Golden Section algorithm or not.</param>
        /// <returns>Minimum of function.</returns>

        public static Matrica FindMinimum(Function function, double e, Matrica startingPoint, bool usingGoldenSection)
        {
            Matrica x = new Matrica();
            x.Equals(startingPoint);
            function.SetParametersSize(x.NoOfRows);
            Matrica gradient = new Matrica();
            Matrica hessianMatrix = new Matrica();
            int brojac = 0;
            Matrica xs = new Matrica();

            if (usingGoldenSection == false)
            {
                do
                {
                    xs.Equals(x);
                    gradient = function.CalculateGradientValue(x.VectorToArray());
                    function.IncreaseCounterGradientValue(algorithmName);
                    hessianMatrix = function.CalculateHessianMatrix(x.VectorToArray());
                    function.IncreaseCounterHessian(algorithmName);
                    Matrica LU = hessianMatrix.LUPDecomposition(e, gradient);
                    Matrica y = Matrica.ForwardSubstitution(LU, gradient);
                    Matrica deltaX = Matrica.BackwardSubstitution(LU, gradient, e);
                    x.AddValue(deltaX);
                    brojac++;

                    function.IncreaseCounterValue(algorithmName);
                    function.IncreaseCounterValue(algorithmName);
                } while (brojac < 100);
            }
            else
            {
                do
                {
                    xs.Equals(x);
                    gradient = function.CalculateGradientValue(x.VectorToArray());
                    function.IncreaseCounterGradientValue(algorithmName);
                    hessianMatrix = function.CalculateHessianMatrix(x.VectorToArray());
                    function.IncreaseCounterHessian(algorithmName);
                    Matrica LU = hessianMatrix.LUPDecomposition(e, gradient);
                    Matrica y = Matrica.ForwardSubstitution(LU, gradient);
                    Matrica deltaX = Matrica.BackwardSubstitution(LU, gradient, e);
                    x.AddValue(deltaX);

                    for (int i = 0; i < x.NoOfRows; i++)
                    {
                        double value = x.LoadedMatrix[i][0];
                        double vectorValue = deltaX.LoadedMatrix[i][0];
                        Expression expression = lambda => value + lambda * vectorValue;
                        function.SetParameters(i, expression);
                    }

                    UnimodalInterval interval = UnimodalInterval.FindUnimodalInterval(function, 0, 1, algorithmName);
                    UnimodalInterval lambdaInterval = GoldenSection.FindMinimum(function, interval.Minimum, interval.Maximum, e, algorithmName);

                    double lambdaMin = (lambdaInterval.Minimum + lambdaInterval.Maximum) / 2;
                    deltaX.MultiplyByScalar(lambdaMin);
                    x.AddValue(deltaX);

                    function.IncreaseCounterValue(algorithmName);
                    function.IncreaseCounterValue(algorithmName);
                } while (function.GetGradientNorm() >= e);
            }

            function.DeleteParameters();
            return x;
        }
    }
}
