using APR_dz3;
using System;

namespace APR_dz2
{
    public class UnimodalInterval
    {
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

        public static UnimodalInterval FindUnimodalInterval(Function function, double startingPoint, double h, string algorithmName)
        {
            UnimodalInterval result = new UnimodalInterval(startingPoint - h, startingPoint + h);
            double m = startingPoint;
            double funcValueForMinimum, funcValueForMaximum, funcValueForM;
            uint step = 1;

            funcValueForM = function.CalculateValue(startingPoint);
            function.IncreaseCounterValue(algorithmName);
            funcValueForMinimum = function.CalculateValue(result.Minimum);
            function.IncreaseCounterValue(algorithmName);
            funcValueForMaximum = function.CalculateValue(result.Maximum);
            function.IncreaseCounterValue(algorithmName);

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
                    function.IncreaseCounterValue(algorithmName);
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
                    function.IncreaseCounterValue(algorithmName);
                } while (funcValueForM > funcValueForMinimum);
            }

            return result;
        }
    }
}
