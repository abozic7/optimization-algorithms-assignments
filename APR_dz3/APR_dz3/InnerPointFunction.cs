using APR_dz1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz3
{
    public class InnerPointFunction : Function
    {
        private List<RestrictionExpression> implicitRestrictions;
        private double t;

        /// <summary>
        /// Constructor for setting attributes used for calculating inner point.
        /// </summary>
        /// <param name="implicitRestrictions">List of implicit restrictions.</param>
        /// <param name="t">Parameter of transformation.</param>

        public InnerPointFunction(List<RestrictionExpression> implicitRestrictions, double t)
        {
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
            double result = 0;
            for (int i = 0; i < implicitRestrictions.Count; i++)
            {
                if (!implicitRestrictions[i].GetIsEquationFlag())
                {
                    result -= t * implicitRestrictions[i].CalculateValue(coordinates);
                }
            }

            return result;
        }
    }
}
