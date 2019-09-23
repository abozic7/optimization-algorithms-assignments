using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz4
{
    public abstract class Function
    {
        protected Dictionary<String, int> counterValue = new Dictionary<string, int>();
        protected FunctionOptimization.Expression[] parameters;

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
            parameters = new FunctionOptimization.Expression[size];
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

        public void SetParameters(int index, FunctionOptimization.Expression expression)
        {
            parameters[index] = expression;
        }

        /// <summary>
        /// Increases call counter.
        /// </summary>
        /// <param name="key">Name of optimization algorithm.</param>

        public void IncreaseCounterValue(String key)
        {
            if (counterValue.ContainsKey(key))
            {
                counterValue[key]++;
            }
            else
            {
                counterValue.Add(key, 1);
            }
        }
        
        /// <summary>
        /// Gets counter value of function by given key.
        /// </summary>
        /// <param name="key">Name of algorithm.</param>
        /// <returns>Value of counter for algorithm.</returns>

        public int GetCounterValue(String key)
        {
            if (!counterValue.ContainsKey(key)) return 0;
            return counterValue[key];
        }

        /// <summary>
        /// Gets counter of function.
        /// </summary>
        /// <returns>Counter of function.</returns>

        public Dictionary<String, int> GetFunctionCounterValue()
        {
            return counterValue;
        }
        
        /// <summary>
        /// Sets value of counter for certain algorithm and function.
        /// </summary>
        /// <param name="key">Name of algorithm.</param>
        /// <param name="value">New value of counter.</param>

        public void SetCounterValue(String key, int value)
        {
            if (counterValue.ContainsKey(key))
            {
                counterValue[key] = value;
            }
            else
            {
                counterValue.Add(key, value);
            }
        }

        /// <summary>
        /// Resets counter.
        /// </summary>

        public void ResetCounterValue()
        {
            counterValue = new Dictionary<string, int>();
        }
        
    }
}
