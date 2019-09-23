using APR_dz1;
using APR_dz3;
using System;

namespace APR_dz2
{
    public class HookeJeevesMethod
    {
        /// <summary>
        /// Finds minimum for function using Hooke-Jeeves Optimization algorithm.
        /// </summary>
        /// <param name="startingPoint">Starting point of algorithm.</param>
        /// <param name="function">Function used in algorithm.</param>
        /// <param name="e">Precision.</param>
        /// <param name="deltaX">Step used for calculating new points.</param>
        /// <returns>Minimum of function.</returns>

        public static Matrica FindMinimum(Matrica startingPoint, Function function, Matrica e, Matrica deltaX, string algorithmName)
        {
            if (startingPoint.NoOfRows != e.NoOfRows || startingPoint.NoOfRows != deltaX.NoOfRows
                || startingPoint.NoOfColumns != 1 || e.NoOfColumns != 1 || deltaX.NoOfColumns != 1)
            {
                throw new ArgumentException("Matrice koje ste poslali nisu odgovarajućih dimenzija za Hooke Jeeves metodu!");
            }
            Matrica xp = new Matrica();
            Matrica xb = new Matrica();
            xp.Equals(startingPoint);
            xb.Equals(startingPoint);
            double xnFunctionValue, xbFunctionValue;
            Matrica assistingMatrix = new Matrica();

            do
            {
                double[] xn = Search(xp.VectorToArray(), function, deltaX, algorithmName);
                xnFunctionValue = function.CalculateValue(xn);
                function.IncreaseCounterValue(algorithmName);
                xbFunctionValue = function.CalculateValue(xb.VectorToArray());
                function.IncreaseCounterValue(algorithmName);

                if (xnFunctionValue < xbFunctionValue)
                {
                    assistingMatrix.Equals(Matrica.ArrayToVector(xn));
                    assistingMatrix.MultiplyByScalar(2);
                    xp = assistingMatrix.SubtractMatrices(xb);
                    xb.Equals(Matrica.ArrayToVector(xn));
                }
                else
                {
                    DecreaseDelta(deltaX);
                    xp.Equals(xb);
                }
            } while (IsTerminationCriteriaMet(deltaX, e));

            return xb;
        }

        /// <summary>
        /// Checks whether termination criteria is met.
        /// </summary>
        /// <param name="deltaX">Step used for calculating new points.</param>
        /// <param name="e">Precision.</param>
        /// <returns>True if criteria is not met and loop can keep executing, false if loop should end.</returns>

        public static bool IsTerminationCriteriaMet(Matrica deltaX, Matrica e)
        {
            for (int i = 0; i < deltaX.NoOfRows; i++)
            {
                if (deltaX.LoadedMatrix[i][0] <= e.LoadedMatrix[i][0])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Decreases value of delta X.
        /// </summary>
        /// <param name="deltaX">Step used for calculating new points.</param>

        public static void DecreaseDelta(Matrica deltaX)
        {
            deltaX.MultiplyByScalar(1.0 / 2);
        }

        /// <summary>
        /// Searches for point Xn.
        /// </summary>
        /// <param name="startingSearchPoint">Point Xp.</param>
        /// <param name="function">Function used in algorithm.</param>
        /// <param name="deltaX">Step used for calculating new points.</param>
        /// <returns>Point Xn.</returns>

        public static double[] Search(double[] startingSearchPoint, Function function, Matrica deltaX, string algorithmName)
        {
            Matrica x = new Matrica();
            x.Equals(Matrica.ArrayToVector(startingSearchPoint));
            double xpFunctionValue, xnFunctionValue;
            for (int i = 0; i < startingSearchPoint.Length; i++)
            {
                xpFunctionValue = function.CalculateValue(x.VectorToArray());
                function.IncreaseCounterValue(algorithmName);
                x.LoadedMatrix[i][0] += deltaX.LoadedMatrix[i][0];
                xnFunctionValue = function.CalculateValue(x.VectorToArray());
                function.IncreaseCounterValue(algorithmName);
                if (xnFunctionValue > xpFunctionValue)
                {
                    x.LoadedMatrix[i][0] -= 2 * deltaX.LoadedMatrix[i][0];
                    xnFunctionValue = function.CalculateValue(x.VectorToArray());
                    function.IncreaseCounterValue(algorithmName);
                    if (xnFunctionValue > xpFunctionValue)
                    {
                        x.LoadedMatrix[i][0] += deltaX.LoadedMatrix[i][0];
                    }
                }
            }

            return x.VectorToArray();
        }
    }
}
