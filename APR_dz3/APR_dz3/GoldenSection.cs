using APR_dz3;
using System;

namespace APR_dz2
{
    public class GoldenSection
    {
        private static readonly double k = 0.5 * (Math.Sqrt(5) - 1);

        /// <summary>
        /// Finds minimum for function using Golden Section Optimization algorithm.
        /// </summary>
        /// <param name="function">Function used in algorithm.</param>
        /// <param name="a">Minimum of unimodal interval.</param>
        /// <param name="b">Maximum od unimodal interval.</param>
        /// <param name="e">Precision.</param>
        /// <returns>Interval contatining minimum of function.</returns>

        public static UnimodalInterval FindMinimum(Function function, double a, double b, double e, string algorithmName)
        {
            double c = b - k * (b - a);
            double d = a + k * (b - a);
            double funcValueOfC = function.CalculateValue(c);
            function.IncreaseCounterValue(algorithmName);
            double funcValueOfD = function.CalculateValue(d);
            function.IncreaseCounterValue(algorithmName);

            while ((b - a) > e)
            {
                if (funcValueOfC < funcValueOfD)
                {
                    b = d;
                    d = c;
                    c = b - k * (b - a);
                    funcValueOfD = funcValueOfC;
                    funcValueOfC = function.CalculateValue(c);
                    function.IncreaseCounterValue(algorithmName);
                }
                else
                {
                    a = c;
                    c = d;
                    d = a + k * (b - a);
                    funcValueOfC = funcValueOfD;
                    funcValueOfD = function.CalculateValue(d);
                    function.IncreaseCounterValue(algorithmName);
                }
            }

            return new UnimodalInterval(a, b);
        }
    }
}
