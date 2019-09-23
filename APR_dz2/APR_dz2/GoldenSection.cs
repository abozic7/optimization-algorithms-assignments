using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz2
{
    public class GoldenSection
    {
        private static String algorithmName = "Golden Section";

        private static readonly double k = 0.5*(Math.Sqrt(5) - 1);

        /// <summary>
        /// Finds minimum for function using Golden Section Optimization algorithm.
        /// </summary>
        /// <param name="function">Function used in algorithm.</param>
        /// <param name="a">Minimum of unimodal interval.</param>
        /// <param name="b">Maximum od unimodal interval.</param>
        /// <param name="e">Precision.</param>
        /// <returns>Interval contatining minimum of function.</returns>

        public static UnimodalInterval FindMinimum(Function function, double a, double b, double e)
        {
            double c = b - k * (b - a);
            double d = a + k * (b - a);
            double funcValueOfC = function.CalculateValue(c);
            function.IncreaseCounter(algorithmName);
            double funcValueOfD = function.CalculateValue(d);
            function.IncreaseCounter(algorithmName);

            while ((b - a) > e)
            {
                WritePointValuesInConsole(a, b, c, d, function);
                if (funcValueOfC < funcValueOfD)
                {
                    b = d;
                    d = c;
                    c = b - k * (b - a);
                    funcValueOfD = funcValueOfC;
                    funcValueOfC = function.CalculateValue(c);
                    function.IncreaseCounter(algorithmName);
                }
                else
                {
                    a = c;
                    c = d;
                    d = a + k * (b - a);
                    funcValueOfC = funcValueOfD;
                    funcValueOfD = function.CalculateValue(d);
                    function.IncreaseCounter(algorithmName);
                }
            }

            return new UnimodalInterval(a, b);
        }

        /// <summary>
        /// Writes points and their function values in console.
        /// </summary>
        /// <param name="a">Minimum of unimodal interval.</param>
        /// <param name="b">Maximum of unimodal interval.</param>
        /// <param name="c">Calculated point c.</param>
        /// <param name="d">Calculated point d.</param>
        /// <param name="function">Function used in algorithm.</param>

        public static void WritePointValuesInConsole(double a, double b, double c, double d, Function function)
        {
            Console.WriteLine("a = " + a + " -> f(a) = " + function.CalculateValue(a));
            Console.WriteLine("b = " + b + " -> f(b) = " + function.CalculateValue(b));
            Console.WriteLine("c = " + c + " -> f(c) = " + function.CalculateValue(c));
            Console.WriteLine("d = " + d + " -> f(d) = " + function.CalculateValue(d));
            Console.WriteLine();
        }
    }
}
