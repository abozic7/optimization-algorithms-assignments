using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APR_dz1;

namespace APR_dz3
{
    public class TransformedFunction : Function
    {
        private Function function;
        private List<RestrictionExpression> implicitRestrictions;
        private double t;

        /// <summary>
        /// Constructor for transformed function.
        /// </summary>
        /// <param name="function">Function that has to be transformed.</param>
        /// <param name="implicitRestrictions">List of implicit restrictions.</param>
        /// <param name="t">Parameter of transformation.</param>

        public TransformedFunction(Function function, List<RestrictionExpression> implicitRestrictions, double t)
        {
            this.function = function;
            this.implicitRestrictions = implicitRestrictions;
            this.t = t;
        }

        /// <summary>
        /// Sets parameter of transformation.
        /// </summary>
        /// <param name="t">Value of parameter of transformation.</param>

        public void SetT(double t)
        {
            this.t = t;
        }

        /// <summary>
        /// Gets parameter of transformation.
        /// </summary>
        /// <returns>Parameter of transformation.</returns>

        public double GetT()
        {
            return t;
        }

        /// <summary>
        /// Calculates gradient of function for given point.
        /// </summary>
        /// <param name="coordinates">Coordinates of point.</param>
        /// <returns>Gradient of function.</returns>

        public override Matrica CalculateGradientValue(params double[] coordinates)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates Hessian matrix of function for given point.
        /// </summary>
        /// <param name="coordinates">Coordinates of point.</param>
        /// <returns>Hessian matrix of function.</returns>

        public override Matrica CalculateHessianMatrix(params double[] coordinates)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates value of implicit restriction for given point.
        /// </summary>
        /// <param name="coordinates">Coordinates of point.</param>
        /// <returns>Value of implicit restrictions.</returns>

        public override double CalculateValue(params double[] coordinates)
        {
            double result = function.CalculateValue(coordinates);
            for (int i = 0; i < implicitRestrictions.Count; i++)
            {
                if(!implicitRestrictions[i].GetIsEquationFlag())
                {
                    result -= (1.0 / t) * Math.Log(implicitRestrictions[i].CalculateValue(coordinates));
                }
                else
                {
                    result += t * Math.Pow(implicitRestrictions[i].CalculateValue(coordinates), 2);
                }
            }

            return result;
        }
    }
}
