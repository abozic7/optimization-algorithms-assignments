using APR_dz1;
using APR_dz2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz3
{
    public class BoxMethod
    {
        private static double minimumForRandom = 0;
        private static double maximumForRandom = 1;
        private static String algorithmName = "Box Method";

        /// <summary>
        /// Finds minimum of function using Box optimization method.
        /// </summary>
        /// <param name="function">Function used to optimize.</param>
        /// <param name="implicitRestrictions">List of implicit restrictions used in Box method.</param>
        /// <param name="explicitRestriction">List of explicit restrictions used in Box method.</param>
        /// <param name="startingPoint">Starting point of algorithm.</param>
        /// <param name="alfa">Constant alpha used in algorithm.</param>
        /// <param name="iterations">Number of iterations of algorithm.</param>
        /// <returns></returns>

        public static Matrica FindMinimum(Function function, List<RestrictionExpression> implicitRestrictions, ExplicitRestriction explicitRestriction, Matrica startingPoint, double alfa, int iterations)
        {
            if(OptimizationUtils.CheckIfExplicitConstraintsAreMet(explicitRestriction, startingPoint) == false || 
                OptimizationUtils.CheckIfImplicitConstraintsAreMet(implicitRestrictions, startingPoint) == false)
            {
                throw new ArgumentException("Starting point does not meet explicit and/or implicit conditions!");
            }

            int iter = 0;
            function.SetParametersSize(startingPoint.NoOfRows);
            Matrica centroid = new Matrica();
            centroid.Equals(startingPoint);
            int n = startingPoint.NoOfRows;
            Random random = new Random();
            double R;
            List<Matrica> simplex = new List<Matrica>();
            UnimodalInterval interval = explicitRestriction.GetInterval();

            for (int t = 0; t < 2*n; t++)
            {
                double[] point = new double[n];
                for (int i = 0; i < n; i++)
                {
                    R = random.NextDouble() * (maximumForRandom - minimumForRandom) + minimumForRandom;
                    point[i] = interval.Minimum + R * (interval.Maximum - interval.Minimum);
                }

                simplex.Insert(t, Matrica.ArrayToVector(point));

                bool[] simplexPointMeetsImplicitRestrictions = new bool[implicitRestrictions.Count];
                for (int i = 0; i < implicitRestrictions.Count; i++)
                {
                    simplexPointMeetsImplicitRestrictions[i] = false;
                }

                while (true)
                {
                    for (int i = 0; i < implicitRestrictions.Count; i++)
                    {
                        simplexPointMeetsImplicitRestrictions[i] = implicitRestrictions[i].CheckIfMet(simplex[t].VectorToArray());
                        if (simplexPointMeetsImplicitRestrictions[i] == false)
                        {
                            simplex[t].AddValue(centroid);
                            simplex[t].MultiplyByScalar(1.0 / 2);
                            break;
                        }
                    }

                    if (!simplexPointMeetsImplicitRestrictions.Contains(false))
                    {
                        break;
                    }
                }

                centroid = GetCentroidPoint(simplex);
            }

            List<double> functionValues = GetSimplexPointsFunctionValues(simplex, function);
            Matrica xr = new Matrica();

            do
            {
                int h = GetIndexOfWorstPoint(functionValues);
                int h2 = GetIndexOfSecondWorstPoint(functionValues, h);
                centroid = GetCentroidPoint(simplex, h);
                xr = Reflection(centroid, simplex[h], alfa);

                for (int i = 0; i < xr.NoOfRows; i++)
                {
                    if(xr.LoadedMatrix[i][0] < interval.Minimum)
                    {
                        xr.LoadedMatrix[i][0] = interval.Minimum;
                    }
                    else if(xr.LoadedMatrix[i][0] > interval.Maximum)
                    {
                        xr.LoadedMatrix[i][0] = interval.Maximum;
                    }
                }

                bool[] reflectionMeetsImplicitRestrictions = new bool[implicitRestrictions.Count];
                for (int i = 0; i < implicitRestrictions.Count; i++)
                {
                    reflectionMeetsImplicitRestrictions[i] = false;
                }

                while(true)
                {
                    for (int i = 0; i < implicitRestrictions.Count; i++)
                    {
                        reflectionMeetsImplicitRestrictions[i] = implicitRestrictions[i].CheckIfMet(xr.VectorToArray());
                        if(reflectionMeetsImplicitRestrictions[i] == false)
                        {
                            xr.AddValue(centroid);
                            xr.MultiplyByScalar(1.0 / 2);
                            break;
                        }
                    }

                    if (!reflectionMeetsImplicitRestrictions.Contains(false))
                    {
                        break;
                    }
                }

                double xrFunctionValue = function.CalculateValue(xr.VectorToArray());
                function.IncreaseCounterValue(algorithmName);
                if (xrFunctionValue > functionValues[h2])
                {
                    xr.AddValue(centroid);
                    xr.MultiplyByScalar(1.0 / 2);
                }

                simplex[h] = xr;
                functionValues[h] = xrFunctionValue;
                iter++;
            } while (iter < iterations);

            function.DeleteParameters();
            return simplex.ElementAt(functionValues.IndexOf(functionValues.Min()));
        }

        /// <summary>
        /// Calculates centroid point of given simplex.
        /// </summary>
        /// <param name="simplexPoints">Simplex points of Box algorithm.</param>
        /// <param name="h">Index of the worst simplex point.</param>
        /// <returns>Centroid point vector.</returns>

        public static Matrica GetCentroidPoint(List<Matrica> simplexPoints, int h)
        {
            Matrica centroid = new Matrica();
            centroid.NoOfColumns = 1;
            centroid.NoOfRows = simplexPoints[0].NoOfRows;
            for (int i = 0; i < centroid.NoOfRows; i++)
            {
                List<double> row = new List<double>();
                row.Insert(0, 0);
                centroid.LoadedMatrix.Add(i, row);
            }
            for (int i = 0; i < simplexPoints.Count; i++)
            {
                if (i == h) continue;
                centroid.AddValue(simplexPoints[i]);
            }
            centroid.MultiplyByScalar(1.0 / (simplexPoints.Count - 1));
            return centroid;
        }

        /// <summary>
        /// Calculates centroid point of given simplex.
        /// </summary>
        /// <param name="simplexPoints">Simplex points of Box algorithm.</param>
        /// <returns>Centroid point vector.</returns>

        public static Matrica GetCentroidPoint(List<Matrica> simplexPoints)
        {
            Matrica centroid = new Matrica();
            centroid.NoOfColumns = 1;
            centroid.NoOfRows = simplexPoints[0].NoOfRows;
            for (int i = 0; i < centroid.NoOfRows; i++)
            {
                List<double> row = new List<double>();
                row.Insert(0, 0);
                centroid.LoadedMatrix.Add(i, row);
            }
            for (int i = 0; i < simplexPoints.Count; i++)
            {
                centroid.AddValue(simplexPoints[i]);
            }
            centroid.MultiplyByScalar(1.0 / simplexPoints.Count);
            return centroid;
        }

        /// <summary>
        /// Calculates reflection point.
        /// </summary>
        /// <param name="centroid">Centroid point.</param>
        /// <param name="highestValue">Value of the worst simplex point.</param>
        /// <param name="alfa">Constant alpha used in calculating reflection point.</param>
        /// <returns>Reflection point.</returns>

        public static Matrica Reflection(Matrica centroid, Matrica highestValue, double alfa)
        {
            Matrica xc = new Matrica();
            xc.Equals(centroid);
            Matrica xh = new Matrica();
            xh.Equals(highestValue);
            xc.MultiplyByScalar(1 + alfa);
            xh.MultiplyByScalar(alfa);
            return xc.SubtractMatrices(xh);
        }

        /// <summary>
        /// Finds index of the worst simplex point.
        /// </summary>
        /// <param name="functionValues">List of values of simplex point for given function.</param>
        /// <returns>Index of worst simplex point.</returns>

        public static int GetIndexOfWorstPoint(List<double> functionValues)
        {
            return functionValues.IndexOf(functionValues.Max());
        }

        /// <summary>
        /// Finds index of second worst simplex point.
        /// </summary>
        /// <param name="functionValues">List of values of simplex point for given function.</param>
        /// <param name="h">Index of worst simplex point.</param>
        /// <returns>Index of second worst simplex point.</returns>

        public static int GetIndexOfSecondWorstPoint(List<double> functionValues, int h)
        {
            double max;
            int indexOfMax;

            if (h != 0)
            {
                max = functionValues[0];
                indexOfMax = 0;
            }
            else {
                max = functionValues[1];
                indexOfMax = 1;
            }

            for (int i = 1; i < functionValues.Count; i++)
            {
                if(functionValues[i] > max && i != h)
                {
                    max = functionValues[i];
                    indexOfMax = i;
                }
            }

            return indexOfMax;
        }

        /// <summary>
        /// Calculates function values for simplex points.
        /// </summary>
        /// <param name="simplexPoints">Simplex points.</param>
        /// <param name="function">Function used in Box algorithm.</param>
        /// <returns>List of values of simplex point for given function.</returns>

        public static List<double> GetSimplexPointsFunctionValues(List<Matrica> simplexPoints, Function function)
        {
            List<double> result = new List<double>();
            for (int i = 0; i < simplexPoints.Count; i++)
            {
                result.Insert(i, function.CalculateValue(simplexPoints.ElementAt(i).VectorToArray()));
                function.IncreaseCounterValue(algorithmName);
            }

            return result;
        }
    }
}
