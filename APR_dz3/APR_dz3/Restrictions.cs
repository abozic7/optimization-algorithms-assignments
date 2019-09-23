using APR_dz1;
using APR_dz2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz3
{
    public class ExplicitRestriction
    {
        UnimodalInterval interval = new UnimodalInterval();

        /// <summary>
        /// Gets interval.
        /// </summary>
        /// <returns>Interval.</returns>

        public UnimodalInterval GetInterval()
        {
            return interval;
        }

        /// <summary>
        /// Sets explicit restriction.
        /// </summary>
        /// <param name="minimum">Minimum of explicit restriction.</param>
        /// <param name="maximum">Maximum of explicit restriction.</param>

        public void SetExplicitRestriction(double minimum, double maximum)
        {
            interval.Minimum = minimum;
            interval.Maximum = maximum;
        }

        /// <summary>
        /// Checks if explicit restriction is met for given point.
        /// </summary>
        /// <param name="point">Point used to check explicit restriction.</param>
        /// <returns>True if explicit restriction is met, otherwise returns false.</returns>

        public bool IsExplicitRestrictionMet(Matrica point)
        {
            for (int i = 0; i < point.NoOfRows; i++)
            {
                if(point.LoadedMatrix[i][0] < interval.Minimum || point.LoadedMatrix[i][0] > interval.Maximum)
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class ImplicitRestrictions1 : RestrictionExpression
    {
        public ImplicitRestrictions1()
        {
            SetIsEquationFlag(false);
        }

        /// <summary>
        /// Calculates value of implicit restriction for given point.
        /// </summary>
        /// <param name="coordinates">Coordinates of point.</param>
        /// <returns>Value of implicit restriction for given point.</returns>

        public override double CalculateValue(params double[] coordinates)
        {
            return coordinates[1] - coordinates[0];
        }

        /// <summary>
        /// Checks if implicit restriction is met for given point.
        /// </summary>
        /// <param name="coordinates">Coordinates of point.</param>
        /// <returns>True if the implicit restriction is met, otherwise returns false.</returns>

        public override bool CheckIfMet(params double[] coordinates)
        {
            return coordinates[1] - coordinates[0] >= 0;
        }
    }

    public class ImplicitRestrictions2 : RestrictionExpression
    {
        public ImplicitRestrictions2()
        {
            SetIsEquationFlag(false);
        }

        /// <summary>
        /// Calculates value of implicit restriction for given point.
        /// </summary>
        /// <param name="coordinates">Coordinates of point.</param>
        /// <returns>Value of implicit restriction for given point.</returns>

        public override double CalculateValue(params double[] coordinates)
        {
            return 2 - coordinates[0];
        }

        /// <summary>
        /// Checks if implicit restriction is met for given point.
        /// </summary>
        /// <param name="coordinates">Coordinates of point.</param>
        /// <returns>True if the implicit restriction is met, otherwise returns false.</returns>

        public override bool CheckIfMet(params double[] coordinates)
        {
            return 2 - coordinates[0] >= 0;
        }
    }

    public class ImplicitRestrictions3 : RestrictionExpression
    {
        public ImplicitRestrictions3()
        {
            SetIsEquationFlag(false);
        }

        /// <summary>
        /// Calculates value of implicit restriction for given point.
        /// </summary>
        /// <param name="coordinates">Coordinates of point.</param>
        /// <returns>Value of implicit restriction for given point.</returns>

        public override double CalculateValue(params double[] coordinates)
        {
            return 3 - coordinates[0] - coordinates[1];
        }

        /// <summary>
        /// Checks if implicit restriction is met for given point.
        /// </summary>
        /// <param name="coordinates">Coordinates of point.</param>
        /// <returns>True if the implicit restriction is met, otherwise returns false.</returns>

        public override bool CheckIfMet(params double[] coordinates)
        {
            return 3 - coordinates[0] - coordinates[1] >= 0;
        }
    }

    public class ImplicitRestrictions4 : RestrictionExpression
    {
        public ImplicitRestrictions4()
        {
            SetIsEquationFlag(false);
        }

        /// <summary>
        /// Calculates value of implicit restriction for given point.
        /// </summary>
        /// <param name="coordinates">Coordinates of point.</param>
        /// <returns>Value of implicit restriction for given point.</returns>

        public override double CalculateValue(params double[] coordinates)
        {
            return 3 + 1.5 * coordinates[0] - coordinates[1];
        }

        /// <summary>
        /// Checks if implicit restriction is met for given point.
        /// </summary>
        /// <param name="coordinates">Coordinates of point.</param>
        /// <returns>True if the implicit restriction is met, otherwise returns false.</returns>

        public override bool CheckIfMet(params double[] coordinates)
        {
            return 3 + 1.5 * coordinates[0] - coordinates[1] >= 0;
        }
    }

    public class ImplicitRestrictions5 : RestrictionExpression
    {
        public ImplicitRestrictions5()
        {
            SetIsEquationFlag(true);
        }

        /// <summary>
        /// Calculates value of implicit restriction for given point.
        /// </summary>
        /// <param name="coordinates">Coordinates of point.</param>
        /// <returns>Value of implicit restriction for given point.</returns>

        public override double CalculateValue(params double[] coordinates)
        {
            return coordinates[1] - 1;
        }

        /// <summary>
        /// Checks if implicit restriction is met for given point.
        /// </summary>
        /// <param name="coordinates">Coordinates of point.</param>
        /// <returns>True if the implicit restriction is met, otherwise returns false.</returns>

        public override bool CheckIfMet(params double[] coordinates)
        {
            return coordinates[1] - 1 == 0;
        }
    }
}
