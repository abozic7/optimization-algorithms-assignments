using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz4
{
    public class ExplicitRestriction
    {
        public double Minimum { get; set; }
        public double Maximum { get; set; }

        public ExplicitRestriction(double minimum, double maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }
    }
}
