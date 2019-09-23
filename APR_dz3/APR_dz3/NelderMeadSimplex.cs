using APR_dz1;
using APR_dz3;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APR_dz2
{
    public class NelderMeadSimplex
    {
        private static String algorithmName = "Nelder-Mead Simplex";

        /// <summary>
        /// Finds minimum for function using Nelder-Mead Simplex Optimization algorithm.
        /// </summary>
        /// <param name="startingPoint">Starting point of algorithm.</param>
        /// <param name="shift">Shift used in calculating points of simplex.</param>
        /// <param name="function">Function used in algorithm.</param>
        /// <param name="alfa">Constant used for calculating point of reflection.</param>
        /// <param name="beta">Constant used for calcualating point of contraction.</param>
        /// <param name="gamma">Constant used for calculating point of expansion.</param>
        /// <param name="e">Precision.</param>
        /// <param name="sigma">Constant used for moving points of simplex closer to minimal value.</param>
        /// <returns>Minimum of function.</returns>

        public static Matrica FindMinimum(Matrica startingPoint, double shift, Function function, double alfa, double beta, double gamma, double e, double sigma)
        {
            double[] startPoint = startingPoint.VectorToArray();
            List<double[]> simplexPoints = GetSimplexPoints(startPoint, shift);
            List<double> functionValues = new List<double>();
            double[] xc;
            int h, l;
            do
            {
                functionValues = GetSimplexPointsFunctionValues(simplexPoints, function);
                l = functionValues.IndexOf(functionValues.Min());
                h = functionValues.IndexOf(functionValues.Max());
                xc = GetCentroidPoint(simplexPoints, h);
                Console.WriteLine("\nCentroid point Xc:");
                Console.WriteLine("================");
                Matrica.ArrayToVector(xc).WriteMatrixInConsole();
                Console.WriteLine("\nf(Xc) = " + function.CalculateValue(xc));
                function.IncreaseCounterValue(algorithmName);
                double[] xr = Reflection(xc, simplexPoints[h], alfa);

                double xrFunctionValue = function.CalculateValue(xr);
                function.IncreaseCounterValue(algorithmName);

                if (xrFunctionValue < functionValues[l])
                {
                    double[] xe = Expansion(xc, xr, gamma);
                    double xeFunctionValue = function.CalculateValue(xe);
                    function.IncreaseCounterValue(algorithmName);

                    if (xeFunctionValue < functionValues[l])
                    {
                        simplexPoints[h] = xe;
                        functionValues[h] = xeFunctionValue;
                    }
                    else
                    {
                        simplexPoints[h] = xr;
                        functionValues[h] = xrFunctionValue;
                    }
                }
                else
                {
                    if (CheckIfReflectionGreaterThanSimplexPoints(xr, simplexPoints, function, h))
                    {
                        if (xrFunctionValue < functionValues[h])
                        {
                            simplexPoints[h] = xr;
                            functionValues[h] = xrFunctionValue;
                        }
                        double[] xk = Contraction(xc, simplexPoints[h], beta);
                        double xkFunctionValue = function.CalculateValue(xk);
                        function.IncreaseCounterValue(algorithmName);

                        if (xkFunctionValue < functionValues[h])
                        {
                            simplexPoints[h] = xk;
                            functionValues[h] = xkFunctionValue;
                        }
                        else
                        {
                            for (int j = 0; j < simplexPoints.Count; j++)
                            {
                                if (j != l)
                                {
                                    MovePointCloserToMinValue(simplexPoints, l, j, sigma);
                                }
                            }
                            functionValues = GetSimplexPointsFunctionValues(simplexPoints, function);
                        }
                    }
                    else
                    {
                        simplexPoints[h] = xr;
                        functionValues[h] = xrFunctionValue;
                    }
                }
            } while (!IsTerminationCriteriaMet(simplexPoints, xc, function, e));

            return Matrica.ArrayToVector(simplexPoints[functionValues.IndexOf(functionValues.Min())]);
        }

        /// <summary>
        /// Checks if reflection point has greater values of all coordinates comparing to all points of simplex.
        /// </summary>
        /// <param name="xr">Reflection point Xr.</param>
        /// <param name="simplexPoints">Points of simplex.</param>
        /// <param name="function">Function used in algorithm.</param>
        /// <param name="h">Index of simplex point with highest function value.</param>
        /// <returns>True if reflection point has greater values of all coordinates comparing to all points of simplex, otherwise returns false.</returns>

        public static bool CheckIfReflectionGreaterThanSimplexPoints(double[] xr, List<double[]> simplexPoints, Function function, int h)
        {
            for (int i = 0; i < simplexPoints.Count; i++)
            {
                if (i != h)
                {
                    if (function.CalculateValue(xr) <= function.CalculateValue(simplexPoints[i]))
                    {
                        return false;
                    }
                    function.IncreaseCounterValue(algorithmName);
                    function.IncreaseCounterValue(algorithmName);
                }
            }
            return true;
        }

        /// <summary>
        /// Checks whether termination criteria is met.
        /// </summary>
        /// <param name="simplexPoints">Points of simplex.</param>
        /// <param name="centroid">Centroid point.</param>
        /// <param name="function">Function used in algorithm.</param>
        /// <param name="e">Precision.</param>
        /// <returns>Returns false if criteria is not met, otherwise returns true.</returns>

        public static bool IsTerminationCriteriaMet(List<double[]> simplexPoints, double[] centroid, Function function, double e)
        {
            double sum = 0;
            double xcFunctionValue = function.CalculateValue(centroid);
            function.IncreaseCounterValue(algorithmName);
            double xiFunctionValue;
            for (int i = 0; i < simplexPoints.Count; i++)
            {
                xiFunctionValue = function.CalculateValue(simplexPoints[i]);
                function.IncreaseCounterValue(algorithmName);
                sum += Math.Pow(xiFunctionValue - xcFunctionValue, 2);
            }
            return Math.Sqrt((1.0 / simplexPoints.Count) * sum) <= e;
        }

        /// <summary>
        /// Moves simplex point closer to point with minimal function value.
        /// </summary>
        /// <param name="simplexPoints">Points of simplex.</param>
        /// <param name="l">Index of point with smallest function value.</param>
        /// <param name="j">Index of simplex point.</param>
        /// <param name="sigma">Constant used for moving points of simplex closer to minimal value.</param>

        public static void MovePointCloserToMinValue(List<double[]> simplexPoints, int l, int j, double sigma)
        {
            Matrica xl = new Matrica();
            xl.Equals(Matrica.ArrayToVector(simplexPoints[l]));
            Matrica point = new Matrica();
            point.Equals(Matrica.ArrayToVector(simplexPoints[j]));
            point.MultiplyByScalar(sigma);
            xl.MultiplyByScalar(1 - sigma);
            simplexPoints[j] = point.AddMatrices(xl).VectorToArray();
        }

        /// <summary>
        /// Executes contraction of simplex.
        /// </summary>
        /// <param name="centroid">Centroid point.</param>
        /// <param name="highestValue">Point Xh.</param>
        /// <param name="beta">Constant used for contraction.</param>
        /// <returns>Contraction point.</returns>

        public static double[] Contraction(double[] centroid, double[] highestValue, double beta)
        {
            Matrica xc = new Matrica();
            xc.Equals(Matrica.ArrayToVector(centroid));
            Matrica xh = new Matrica();
            xh.Equals(Matrica.ArrayToVector(highestValue));
            xc.MultiplyByScalar(1 - beta);
            xh.MultiplyByScalar(beta);
            return xc.AddMatrices(xh).VectorToArray();
        }

        /// <summary>
        /// Executes expansion of simplex.
        /// </summary>
        /// <param name="centroid">Centroid point.</param>
        /// <param name="reflectionPoint">Reflection point.</param>
        /// <param name="gamma">Constant used for expansion.</param>
        /// <returns>Expansion point.</returns>

        public static double[] Expansion(double[] centroid, double[] reflectionPoint, double gamma)
        {
            Matrica xc = new Matrica();
            xc.Equals(Matrica.ArrayToVector(centroid));
            Matrica xr = new Matrica();
            xr.Equals(Matrica.ArrayToVector(reflectionPoint));
            xc.MultiplyByScalar(1 - gamma);
            xr.MultiplyByScalar(gamma);
            return xc.AddMatrices(xr).VectorToArray();
        }

        /// <summary>
        /// Executes reflection of simplex.
        /// </summary>
        /// <param name="centroid">Centroid point.</param>
        /// <param name="highestValue">Point Xh.</param>
        /// <param name="alfa">Constant used for reflection.</param>
        /// <returns>Reflection point.</returns>

        public static double[] Reflection(double[] centroid, double[] highestValue, double alfa)
        {
            Matrica xc = new Matrica();
            xc.Equals(Matrica.ArrayToVector(centroid));
            Matrica xh = new Matrica();
            xh.Equals(Matrica.ArrayToVector(highestValue));
            xc.MultiplyByScalar(1 + alfa);
            xh.MultiplyByScalar(alfa);
            return xc.SubtractMatrices(xh).VectorToArray();
        }

        /// <summary>
        /// Calculates centroid point Xc.
        /// </summary>
        /// <param name="simplexPoints">Points of simplex.</param>
        /// <param name="h">Index of point Xh in simplex.</param>
        /// <returns></returns>

        public static double[] GetCentroidPoint(List<double[]> simplexPoints, int h)
        {
            Matrica centroid = new Matrica();
            centroid.NoOfColumns = 1;
            centroid.NoOfRows = simplexPoints[0].Length;
            for (int i = 0; i < centroid.NoOfRows; i++)
            {
                List<double> row = new List<double>();
                row.Insert(0, 0);
                centroid.LoadedMatrix.Add(i, row);
            }
            for (int i = 0; i < simplexPoints.Count; i++)
            {
                if (i == h) continue;
                centroid.AddValue(Matrica.ArrayToVector(simplexPoints[i]));
            }
            centroid.MultiplyByScalar(1.0 / (simplexPoints.Count - 1));
            return centroid.VectorToArray();
        }

        /// <summary>
        /// Calculates function value for every simplex point.
        /// </summary>
        /// <param name="simplexPoints">Points of simplex.</param>
        /// <param name="function">Function used in algorithm.</param>
        /// <returns>List of simplex function values.</returns>

        public static List<double> GetSimplexPointsFunctionValues(List<double[]> simplexPoints, Function function)
        {
            List<double> result = new List<double>();
            for (int i = 0; i < simplexPoints.Count; i++)
            {
                result.Insert(i, function.CalculateValue(simplexPoints[i]));
                function.IncreaseCounterValue(algorithmName);
            }

            return result;
        }

        /// <summary>
        /// Calculates simplex points using starting point.
        /// </summary>
        /// <param name="startingPoint">Starting point.</param>
        /// <param name="shift">Shift used for getting simplex points from starting point.</param>
        /// <returns>List of simplex points.</returns>

        public static List<double[]> GetSimplexPoints(double[] startingPoint, double shift)
        {
            List<double[]> simplexPoints = new List<double[]>();
            simplexPoints.Insert(0, startingPoint);
            for (int i = 0; i < startingPoint.Length; i++)
            {
                Matrica point = new Matrica();
                point.Equals(Matrica.ArrayToVector(startingPoint));
                point.LoadedMatrix[i][0] += shift;
                simplexPoints.Insert(i + 1, point.VectorToArray());
            }

            return simplexPoints;
        }
    }
}
