using APR_dz1;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz3
{
    public class OptimizationUtils
    {
        /// <summary>
        /// Checks if two points (old and new) are similar.
        /// </summary>
        /// <param name="xNew">New point.</param>
        /// <param name="xOld">Old point.</param>
        /// <param name="e">Precision.</param>
        /// <returns>True if they are similar, otherwise returns false.</returns>
        
        public static bool CheckIfPointsAreSimilar(Matrica xNew, Matrica xOld, double e)
        {
            Matrica xResult = xNew.SubtractMatrices(xOld);

            for (int i = 0; i < xResult.NoOfRows; i++)
            {
                if (Math.Abs(xResult.LoadedMatrix[i][0]) > e)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if explicit restrictions are met.
        /// </summary>
        /// <param name="explicitRestriction">List of explicit restrictions.</param>
        /// <param name="point">Point for which the explicit restriction are checked.</param>
        /// <returns>True if the explicit restrictions are met, otherwise returns false.</returns>

        public static bool CheckIfExplicitConstraintsAreMet(ExplicitRestriction explicitRestriction, Matrica point)
        {
            return explicitRestriction.IsExplicitRestrictionMet(point);
        }

        /// <summary>
        /// Checks if implicit restrictions are met.
        /// </summary>
        /// <param name="implicitRestrictions">List of implicit restrictions.</param>
        /// <param name="point">Point for which the implicit restriction are checked.</param>
        /// <returns>True if the implicit restrictions are met, otherwise returns false.</returns>

        public static bool CheckIfImplicitConstraintsAreMet(List<RestrictionExpression> implicitRestrictions, Matrica point)
        {
            bool result;
            double[] coordinates = point.VectorToArray();
            foreach (var ir in implicitRestrictions)
            {
                if (result = ir.CheckIfMet(coordinates) == false)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Reads double value from file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <returns>Value read from file.</returns>

        public static double ReadValueFromFile(String path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(File.Open(path, FileMode.Open)))
                {
                    string line;
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        line.Trim();
                    }
                    else
                    {
                        throw new ArgumentException("File is empty!");
                    }

                    return Double.Parse(line, CultureInfo.InvariantCulture);
                }
            }
            catch (IOException)
            {
                throw new ArgumentException("An error occurred: the file you want to read from does not exist!");
            }
        }
    }
}
