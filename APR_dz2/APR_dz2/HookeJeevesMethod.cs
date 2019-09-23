using APR_dz1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz2
{
    public class HookeJeevesMethod
    {
        private static String algorithmName = "Hooke-Jeeves";

        /// <summary>
        /// Finds minimum for function using Hooke-Jeeves Optimization algorithm.
        /// </summary>
        /// <param name="startingPoint">Starting point of algorithm.</param>
        /// <param name="function">Function used in algorithm.</param>
        /// <param name="e">Precision.</param>
        /// <param name="deltaX">Step used for calculating new points.</param>
        /// <returns>Minimum of function.</returns>

        public static Matrica FindMinimum(Matrica startingPoint, Function function, Matrica e, Matrica deltaX)
        {
            if(startingPoint.NoOfRows != e.NoOfRows || startingPoint.NoOfRows != deltaX.NoOfRows 
                || startingPoint.NoOfColumns != 1 || e.NoOfColumns != 1 || deltaX.NoOfColumns != 1)
            {
                throw new ArgumentException("Matrice koje ste poslali nisu odgovarajućih dimenzija za Hooke Jeeves metodu!");
            }
            Matrica xp = new Matrica();
            Matrica xb = new Matrica();
            xp.Equals(startingPoint);
            xb.Equals(startingPoint);
            //double[] xp = xpMatrix.VectorToArray();
            //double[] xb = xbMatrix.VectorToArray();
            double xnFunctionValue, xbFunctionValue;
            Matrica assistingMatrix = new Matrica();

            do
            {
                double[] xn = Search(xp.VectorToArray(), function, deltaX);
                xnFunctionValue = function.CalculateValue(xn);
                function.IncreaseCounter(algorithmName);
                xbFunctionValue = function.CalculateValue(xb.VectorToArray());
                function.IncreaseCounter(algorithmName);
                WritePointsAndValuesInConsole(xb, xp, Matrica.ArrayToVector(xn), function);

                if (xnFunctionValue < xbFunctionValue)
                {
                    assistingMatrix.Equals(Matrica.ArrayToVector(xn));
                    assistingMatrix.MultiplyByScalar(2);
                    xp = assistingMatrix.SubtractMatrices(xb);
                    //xb = new Matrica();

                    xb.Equals(Matrica.ArrayToVector(xn));
                }
                else
                {
                    DecreaseDelta(deltaX);
                    xp.Equals(xb);
                }
            } while (IsTerminationCriteriaSatisfied(deltaX, e));

            return xb;
        }

        /// <summary>
        /// Checks whether termination criteria is satisfied.
        /// </summary>
        /// <param name="deltaX">Step used for calculating new points.</param>
        /// <param name="e">Precision.</param>
        /// <returns>True if criteria is not satisfied and loop can keep executing, false if loop should end.</returns>

        public static bool IsTerminationCriteriaSatisfied(Matrica deltaX, Matrica e)
        {
            for (int i = 0; i < deltaX.NoOfRows; i++)
            {
                if(deltaX.LoadedMatrix[i][0] <= e.LoadedMatrix[i][0])
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

        public static double[] Search(double[] startingSearchPoint, Function function, Matrica deltaX)
        {
            Matrica x = new Matrica();
            x.Equals(Matrica.ArrayToVector(startingSearchPoint));
            double xpFunctionValue, xnFunctionValue;
            for (int i = 0; i < startingSearchPoint.Length; i++)
            {
                xpFunctionValue = function.CalculateValue(x.VectorToArray());
                function.IncreaseCounter(algorithmName);
                x.LoadedMatrix[i][0] += deltaX.LoadedMatrix[i][0];
                xnFunctionValue = function.CalculateValue(x.VectorToArray());
                function.IncreaseCounter(algorithmName);
                if (xnFunctionValue > xpFunctionValue)
                {
                    x.LoadedMatrix[i][0] -= 2 * deltaX.LoadedMatrix[i][0];
                    xnFunctionValue = function.CalculateValue(x.VectorToArray());
                    function.IncreaseCounter(algorithmName);
                    if (xnFunctionValue > xpFunctionValue)
                    {
                        x.LoadedMatrix[i][0] += deltaX.LoadedMatrix[i][0];
                    }
                }
            }

            return x.VectorToArray();
        }

        /// <summary>
        /// Writes points and their function values in console.
        /// </summary>
        /// <param name="xb">Base point Xb.</param>
        /// <param name="xp">Starting search point Xp.</param>
        /// <param name="xn">Point obtained in search Xn.</param>
        /// <param name="function">Function used in algorithm.</param>

        public static void WritePointsAndValuesInConsole(Matrica xb, Matrica xp, Matrica xn, Function function)
        {
            Console.WriteLine("\nXb:");
            Console.WriteLine("=====");
            xb.WriteMatrixInConsole();
            Console.WriteLine("\nf(Xb) = " + function.CalculateValue(xb.VectorToArray()));

            Console.WriteLine("\nXp:");
            Console.WriteLine("=====");
            xp.WriteMatrixInConsole();
            Console.WriteLine("\nf(Xp) = " + function.CalculateValue(xp.VectorToArray()));

            Console.WriteLine("\nXn:");
            Console.WriteLine("=====");
            xn.WriteMatrixInConsole();
            Console.WriteLine("\nf(Xn) = " + function.CalculateValue(xn.VectorToArray()));

            Console.WriteLine("\n================");
        }
    }
}
