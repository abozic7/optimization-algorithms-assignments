using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz3
{
    public class FunctionOptimization
    {
        /// <summary>
        /// Delegate used for masking function with multiple variables to function with one variable.
        /// </summary>
        /// <param name="lambda">Value of new expression.</param>
        /// <returns>Value of function.</returns>

        public delegate double Expression(double lambda);

        /// <summary>
        /// Delegate used for masking implicit restriction expression.
        /// </summary>
        /// <param name="lambda">Value of new expression.</param>
        /// <returns>Value of implicit restriction.</returns>

        public delegate double ImplicitRestrictionExpression(double lambda);
    }
}
