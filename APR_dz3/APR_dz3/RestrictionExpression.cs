using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz3
{
    public abstract class RestrictionExpression
    {
        protected FunctionOptimization.ImplicitRestrictionExpression[] parameters;
        private bool isEquation;

        /// <summary>
        /// Checks if implicit restriction is met for given point.
        /// </summary>
        /// <param name="coordinates">Coordinates of point.</param>
        /// <returns>True if the implicit restriction is met, otherwise returns false.</returns>

        public abstract bool CheckIfMet(params double[] coordinates);

        /// <summary>
        /// Calculates value of implicit restriction for given point.
        /// </summary>
        /// <param name="coordinates">Coordinates of point.</param>
        /// <returns>Value of implicit restriction for given point.</returns>

        public abstract double CalculateValue(params double[] coordinates);

        /// <summary>
        /// Sets the value of equation flag.
        /// </summary>
        /// <param name="value">New value of equation flag.</param>

        public void SetIsEquationFlag(bool value)
        {
            isEquation = value;
        }

        /// <summary>
        /// Gets the value of equation flag.
        /// </summary>
        /// <returns>The value of equation flag.</returns>

        public bool GetIsEquationFlag()
        {
            return isEquation;
        }

        /// <summary>
        /// Sets size of parameters field.
        /// </summary>
        /// <param name="size">Size of parameters field</param>

        public void SetParametersSize(int size)
        {
            parameters = new FunctionOptimization.ImplicitRestrictionExpression[size];
        }

        /// <summary>
        /// Sets parameters to null.
        /// </summary>

        public void DeleteParameters()
        {
            parameters = null;
        }

        /// <summary>
        /// Sets parameters of function.
        /// </summary>
        /// <param name="index">Index of parameters field.</param>
        /// <param name="expression">Expression used as a parameter.</param>

        public void SetParameters(int index, FunctionOptimization.ImplicitRestrictionExpression expression)
        {
            parameters[index] = expression;
        }
    }
}
