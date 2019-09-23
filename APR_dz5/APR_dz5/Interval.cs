using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz5
{
    public class Interval
    {
        public double Minimum { get; set; }
        public double Maximum { get; set; }

        public Interval(double minimum, double maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }
    }
}
