using APR_dz1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz5
{
    public class RungeKutta
    {
        public static Matrica SolveEquation(Matrica A, Matrica B, Matrica x0, Interval interval, double T, int loggingStep, string destPath)
        {
            Matrica result = new Matrica();
            result.Equals(x0);
            List<string> lines = new List<string>();
            int linesIndex = 0;
            string line = "";

            int noOfIterations = (int)(Math.Round(interval.Maximum - interval.Minimum) / T);

            line += "t      ";
            for (int i = 0; i < x0.NoOfRows; i++)
            {
                line += "  x" + (i + 1) + "      ";
            }
            Console.WriteLine(line);
            lines.Insert(linesIndex++, line);
            line = "";

            line += String.Format("{0:0.00000}", interval.Minimum);
            for (int j = 0; j < result.NoOfRows; j++)
            {
                line += String.Format("  {0:0.00000}", result.LoadedMatrix[j][0]);
            }
            Console.WriteLine(line);
            lines.Insert(linesIndex++, line);
            line = "";

            for (int i = 0; i < noOfIterations; i++)
            {
                Matrica m1 = A.MultiplyMatrices(result).AddMatrices(B);
                Matrica m2 = A.MultiplyMatrices(result.AddMatrices(m1.MultiplyByScalar2(T / 2))).AddMatrices(B);
                Matrica m3 = A.MultiplyMatrices(result.AddMatrices(m2.MultiplyByScalar2(T / 2))).AddMatrices(B);
                Matrica m4 = A.MultiplyMatrices(result.AddMatrices(m3.MultiplyByScalar2(T))).AddMatrices(B);

                result = result.AddMatrices((
                    m1.AddMatrices(m2.MultiplyByScalar2(2)).AddMatrices(m3.MultiplyByScalar2(2)).AddMatrices(m4)
                    ).MultiplyByScalar2(T / 6));

                if (i % loggingStep == 0)
                {
                    line += String.Format("{0:0.00000}", interval.Minimum + T * (i + 1));
                    for (int j = 0; j < result.NoOfRows; j++)
                    {
                        line += String.Format("  {0:0.00000}", result.LoadedMatrix[j][0]);
                    }
                    Console.WriteLine(line);
                    lines.Insert(linesIndex++, line);
                    line = "";
                }
            }

            System.IO.File.WriteAllLines(destPath, lines.ToArray());

            return result;
        }
    }
}
