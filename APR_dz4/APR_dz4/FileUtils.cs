using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz4
{
    public class FileUtils
    {
        /// <summary>
        /// Converts the string representation of a number to double-precision floating-point number.
        /// </summary>
        /// <param name="line">A string which contains a number.</param>
        /// <returns>Double-precision number converted from string.</returns>

        public static Double StringToDouble(String line)
        {
            if (line != null)
            {
                line.Trim();
            }
            else
            {
                throw new ArgumentException("Line is empty - data is missing!");
            }

            return Double.Parse(line, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the string representation of a number to 32-bit signed integer.
        /// </summary>
        /// <param name="line">A string which contains a number.</param>
        /// <returns>32-bit signed integer converted from string.</returns>

        public static Int32 StringToInteger(String line)
        {
            if (line != null)
            {
                line.Trim();
            }
            else
            {
                throw new ArgumentException("Line is empty - data is missing!");
            }

            return Int32.Parse(line);
        }

        /// <summary>
        /// Converts the string representation of a logical value to boolean.
        /// </summary>
        /// <param name="line">A string which contains a logical value.</param>
        /// <returns>True if string is equal to "true", false if string is equal to "false".</returns>

        public static Boolean StringToBoolean(String line)
        {
            if (line != null)
            {
                line.Trim();
            }
            else
            {
                throw new ArgumentException("Line is empty - data is missing!");
            }

            return Boolean.Parse(line);
        }
    }
}
