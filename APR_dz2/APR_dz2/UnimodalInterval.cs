using APR_dz1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz2
{
    public class UnimodalInterval
    {
        private static String algorithmName = "Golden Section";

        public double Minimum { get; set; }
        public double Maximum { get; set; }

        /// <summary>
        /// Creates new unimodal interval.
        /// </summary>

        public UnimodalInterval()
        {

        }

        /// <summary>
        /// Creates new unimodal interval using minimum and maximum of interval.
        /// </summary>
        /// <param name="minimum">Minimum of unimodal interval.</param>
        /// <param name="maximum">Maximum of unimodal interval.</param>

        public UnimodalInterval(double minimum, double maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }

        /// <summary>
        /// Finds unimodal interval for given function and starting point.
        /// </summary>
        /// <param name="function">Function.</param>
        /// <param name="startingPoint">Starting point.</param>
        /// <param name="h">Shift.</param>
        /// <returns>Unimodal interval.</returns>

        public static UnimodalInterval FindUnimodalInterval(Function function, double startingPoint, double h)
        {
            UnimodalInterval result = new UnimodalInterval(startingPoint - h, startingPoint + h);
            double m = startingPoint;
            double funcValueForMinimum, funcValueForMaximum, funcValueForM;
            uint step = 1;

            funcValueForM = function.CalculateValue(startingPoint);
            function.IncreaseCounter(algorithmName);
            funcValueForMinimum = function.CalculateValue(result.Minimum);
            function.IncreaseCounter(algorithmName);
            funcValueForMaximum = function.CalculateValue(result.Maximum);
            function.IncreaseCounter(algorithmName);

            if (funcValueForM < funcValueForMaximum && funcValueForM < funcValueForMinimum)
            {
                return new UnimodalInterval(startingPoint - h, startingPoint + h);
            }
            else if (funcValueForM > funcValueForMaximum)
            {
                do
                {
                    result.Minimum = m;
                    m = result.Maximum;
                    funcValueForM = funcValueForMaximum;
                    result.Maximum = startingPoint + h * (step *= 2);
                    funcValueForMaximum = function.CalculateValue(result.Maximum);
                    function.IncreaseCounter(algorithmName);
                } while (funcValueForM > funcValueForMaximum);
            }
            else
            {
                do
                {
                    result.Maximum = m;
                    m = result.Minimum;
                    funcValueForM = funcValueForMinimum;
                    result.Minimum = startingPoint - h * (step *= 2);
                    funcValueForMinimum = function.CalculateValue(result.Minimum);
                    function.IncreaseCounter(algorithmName);
                } while (funcValueForM > funcValueForMinimum);
            }

            return result;
        }
    }
}
