using APR_dz1;
using System;
using System.Collections.Generic;

namespace APR_dz3
{
    public abstract class Function
    {
        protected Dictionary<String, int> counterValue = new Dictionary<string, int>();
        protected Dictionary<String, int> counterGradientValue = new Dictionary<string, int>();
        protected Dictionary<String, int> counterHessian = new Dictionary<string, int>();
        protected FunctionOptimization.Expression[] parameters;
        protected double gradientNorm;

        /// <summary>
        /// Calculates value of function for given point.
        /// </summary>
        /// <param name="coordinates">Point for which we want to calculate function value.</param>
        /// <returns>Value of function.</returns>

        public abstract double CalculateValue(params double[] coordinates);

        /// <summary>
        /// Calculates value of gradient for given point.
        /// </summary>
        /// <param name="coordinates">Point for which we want to calculate gradient value.</param>
        /// <returns>Gradient of function.</returns>

        public abstract Matrica CalculateGradientValue(params double[] coordinates);

        /// <summary>
        /// Calculates value of Hessian matrix for given point.
        /// </summary>
        /// <param name="coordinates">Point for which we want to calculate Hessian matrix.</param>
        /// <returns>Hessian matrix of function.</returns>

        public abstract Matrica CalculateHessianMatrix(params double[] coordinates);

        /// <summary>
        /// Gets gradient norm.
        /// </summary>
        /// <returns>Gradient norm.</returns>

        public double GetGradientNorm()
        {
            return gradientNorm;
        }

        /// <summary>
        /// Sets gradient norm.
        /// </summary>
        /// <param name="norm">Gradient norm.</param>

        public void SetGradientNorm(double norm)
        {
            gradientNorm = norm;
        }

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
        /// Increases the counter used for tracking how many times gradient is calculated for given function.
        /// </summary>
        /// <param name="key">Name of the algorithm during which this function is called.</param>

        public void IncreaseCounterGradientValue(String key)
        {
            if (counterGradientValue.ContainsKey(key))
            {
                counterGradientValue[key]++;
            }
            else
            {
                counterGradientValue.Add(key, 1);
            }
        }

        /// <summary>
        /// Increases the counter used for tracking how many times Hessian matrix is calculated for given function.
        /// </summary>
        /// <param name="key">Name of the algorithm during which this function is called.</param>

        public void IncreaseCounterHessian(String key)
        {
            if (counterHessian.ContainsKey(key))
            {
                counterHessian[key]++;
            }
            else
            {
                counterHessian.Add(key, 1);
            }
        }

        /// <summary>
        /// Gets counter value of function by given key.
        /// </summary>
        /// <param name="key">Name of algorithm.</param>
        /// <returns>Value of counter for specific algorithm.</returns>

        public int GetCounterValue(String key)
        {
            if (!counterValue.ContainsKey(key)) return 0;
            return counterValue[key];
        }

        /// <summary>
        /// Gets the counter used for tracking how many times gradient is calculated for given function by given key.
        /// </summary>
        /// <param name="key">Algorithm name.</param>
        /// <returns>Value of gradient counter for specific algorithm.</returns>

        public int GetCounterGradientValue(String key)
        {
            if (!counterGradientValue.ContainsKey(key)) return 0;
            return counterGradientValue[key];
        }

        /// <summary>
        /// Gets the counter used for tracking how many times Hessian matrix is calculated for given function by given key.
        /// </summary>
        /// <param name="key">Algorithm name.</param>
        /// <returns>Value of Hessian matrix for specific algorithm.</returns>

        public int GetCounterHessian(String key)
        {
            if (!counterHessian.ContainsKey(key)) return 0;
            return counterHessian[key];
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
        /// Gets the counter used for tracking how many times gradient is calculated for given function for every algorithm.
        /// </summary>
        /// <returns>Values of gradient counter for every algorithm.</returns>

        public Dictionary<String, int> GetFunctionCounterGradientValue()
        {
            return counterGradientValue;
        }

        /// <summary>
        /// Gets the counter used for tracking how many times Hessian matrix is calculated for given function for every algorithm.
        /// </summary>
        /// <returns>Values of Hessian counter for every algorithm.</returns>

        public Dictionary<String, int> GetFunctionCounterHessian()
        {
            return counterHessian;
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
        /// Sets the value of counter used for tracking how many times gradient is calculated for given function by given key.
        /// </summary>
        /// <param name="key">Algorithm name.</param>
        /// <param name="value">Counter value.</param>

        public void SetCounterGradientValue(String key, int value)
        {
            if (counterGradientValue.ContainsKey(key))
            {
                counterGradientValue[key] = value;
            }
            else
            {
                counterGradientValue.Add(key, value);
            }
        }

        /// <summary>
        /// Sets the value of counter used for tracking how many times Hessian matrix is calculated for given function by given key.
        /// </summary>
        /// <param name="key">Algorithm name.</param>
        /// <param name="value">Counter value.</param>

        public void SetCounterHessian(String key, int value)
        {
            if (counterHessian.ContainsKey(key))
            {
                counterHessian[key] = value;
            }
            else
            {
                counterHessian.Add(key, value);
            }
        }

        /// <summary>
        /// Resets function value counter.
        /// </summary>

        public void ResetCounterValue()
        {
            counterValue = new Dictionary<string, int>();
        }

        /// <summary>
        /// Resets gradient counter.
        /// </summary>

        public void ResetCounterGradientValue()
        {
            counterGradientValue = new Dictionary<string, int>();
        }

        /// <summary>
        /// Resets Hessian counter.
        /// </summary>

        public void ResetCounterHessian()
        {
            counterHessian = new Dictionary<string, int>();
        }
    }
}
