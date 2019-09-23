using APR_dz1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz5
{
    public class TrapezoidalMethod
    {
        public static Matrica SolveEquation(Matrica A, Matrica B, Matrica x0, Interval interval, double T, int loggingStep, string destPath)
        {
            Matrica result = new Matrica();
            result.Equals(x0);
            List<string> lines = new List<string>();
            int linesIndex = 0;
            string line = "";

            Matrica U = Matrica.GenerateIdentityMatrix(A.NoOfRows);
            Matrica AT = A.MultiplyByScalar2(T / 2);
            Matrica R = new Matrica();
            Matrica S = new Matrica();

            try
            {
                R = (U.SubtractMatrices(AT)).FindInverse().MultiplyMatrices(U.AddMatrices(AT));
                S = (U.SubtractMatrices(AT)).FindInverse().MultiplyByScalar2(T / 2).MultiplyMatrices(B);
            }
            catch (OperationCanceledException e)
            {
                throw new ArgumentException("Nije moguće naći inverz matrice jer je matrica singularna!");
            }

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
                result = R.MultiplyMatrices(result).AddMatrices(S);

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
