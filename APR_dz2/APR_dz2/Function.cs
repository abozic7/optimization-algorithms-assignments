using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz2
{
    public abstract class Function
    {
        protected Dictionary<String, int> counter = new Dictionary<string, int>();
        protected SearchByCoordinateAxes.Expression[] parameters;

        /// <summary>
        /// Calculates value of function for given point.
        /// </summary>
        /// <param name="coordinates">Point for which we want to calculate function value.</param>
        /// <returns>Value of function.</returns>

        public abstract double CalculateValue(params double[] coordinates);

        /// <summary>
        /// Sets size of parameters field.
        /// </summary>
        /// <param name="size">Size of parameters field</param>

        public void SetParametersSize(int size)
        {
            parameters = new SearchByCoordinateAxes.Expression[size];
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

        public void SetParameters(int index, SearchByCoordinateAxes.Expression expression)
        {
            parameters[index] = expression;
        }

        /// <summary>
        /// Increases call counter.
        /// </summary>
        /// <param name="key">Name of optimization algorithm.</param>

        public void IncreaseCounter(String key)
        {
            if(counter.ContainsKey(key))
            {
                counter[key]++;
            }
            else
            {
                counter.Add(key, 1);
            }
        }

        /// <summary>
        /// Gets counter value of function by given key.
        /// </summary>
        /// <param name="key">Name of algorithm.</param>
        /// <returns>Value of counter for algorithm.</returns>

        public int GetCounterValue(String key)
        {
            if (!counter.ContainsKey(key)) return 0;
            return counter[key];
        }

        /// <summary>
        /// Gets counter of function.
        /// </summary>
        /// <returns>Counter of function.</returns>

        public Dictionary<String, int> GetFunctionCounter()
        {
            return counter;
        }

        /// <summary>
        /// Sets value of counter for certain algorithm and function.
        /// </summary>
        /// <param name="key">Name of algorithm.</param>
        /// <param name="value">New value of counter.</param>

        public void SetCounterValue(String key, int value)
        {
            if(counter.ContainsKey(key))
            {
                counter[key] = value;
            }
            else
            {
                counter.Add(key, value);
            }
        }
    }
}
