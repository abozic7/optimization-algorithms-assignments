using APR_dz1;
using APR_dz2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz3
{
    public class TransformFunctionMethod
    {
        private static String algorithmName = "Transform Function Method";

        /// <summary>
        /// Finds minimum of functions by transforming it to form solvable by Hooke-Jeeves algorithm.
        /// </summary>
        /// <param name="implicitRestrictions">List of implicit restrictions.</param>
        /// <param name="function">Function used in algorithm.</param>
        /// <param name="t">Parameter of transformation.</param>
        /// <param name="e">Precision.</param>
        /// <param name="startingPoint">Starting point of algorithm.</param>
        /// <param name="epsilon">Precision used in Hooke-Jeeves method.</param>
        /// <param name="deltaX">Step used for calculating new point.</param>
        /// <param name="iterations">Number of iterations of algorithm.</param>
        /// <returns>Minimum of function.</returns>

        public static Matrica FindMinimum(List<RestrictionExpression> implicitRestrictions, Function function, double t, double e, Matrica startingPoint, Matrica epsilon, Matrica deltaX, int iterations)
        {
            Matrica x = new Matrica();
            x.Equals(startingPoint);
            int counter = 0;

            while(true)
            {
                Matrica dx = new Matrica();
                dx.Equals(deltaX);
                TransformedFunction transformedFunction = new TransformedFunction(function, implicitRestrictions, t);
                Matrica xs = new Matrica();
                xs.Equals(x);
                x = HookeJeevesMethod.FindMinimum(xs, transformedFunction, epsilon, dx, algorithmName);
                t *= 10;
                counter++;

                if (OptimizationUtils.CheckIfPointsAreSimilar(x, xs, e) || counter > iterations)
                {
                    break;
                }
            }

            function.DeleteParameters();
            return x;
        }
    }
}
