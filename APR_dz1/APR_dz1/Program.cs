using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz1
{
    public class Program
    {
        public static readonly double epsilon = Math.Pow(10, -9);
        public static readonly double comparingValue = Math.Pow(10, -6);

        public static void Main(string[] args)
        {
            try
            {
                //zad1

                //Console.WriteLine("Enter path to file with matrix:");
                //string path1 = Console.ReadLine();
                //Matrica A = new Matrica(path1);
                //Matrica B = new Matrica();
                //B.Equals(A);
                //A.MultiplyByScalar(3);
                //A.MultiplyByScalar(1.0 / 3);
                //B.WriteMatrixInConsole();
                //Console.WriteLine();
                //A.WriteMatrixInConsole();
                //Console.WriteLine("Matrices " + (B.IsEqual(A, comparingValue) ? "are" : "are not") + " equal.");

                //zad2

                //Console.WriteLine("Enter path to file with matrix A:");
                //string path1 = Console.ReadLine();
                //Matrica A = new Matrica(path1);
                //Console.WriteLine("Enter path to file with vector b:");
                //string path2 = Console.ReadLine();
                //Matrica b = new Matrica(path2);
                //Matrica.SolveSystemOfLinearEquations(A, b, epsilon);

                //zad3

                //Console.WriteLine("Enter path to file with matrix A:");
                //string path1 = Console.ReadLine();
                //Matrica A = new Matrica(path1);
                //Console.WriteLine("Enter path to file with vector b:");
                //string path2 = Console.ReadLine();
                //Matrica b = new Matrica(path2);
                //Matrica.SolveSystemOfLinearEquations(A, b, epsilon);

                //zad4

                //Console.WriteLine("Enter path to file with matrix A:");
                //string path1 = Console.ReadLine();
                //Matrica A = new Matrica(path1);
                //Console.WriteLine("Enter path to file with vector b:");
                //string path2 = Console.ReadLine();
                //Matrica b = new Matrica(path2);
                //Matrica.SolveSystemOfLinearEquations(A, b, epsilon);
                ////A.LUPDecomposition(epsilon, b);
                ////Matrica y = Matrica.ForwardSubstitution(A, b);
                ////Matrica x = Matrica.BackwardSubstitution(A, y, epsilon);
                ////x.WriteMatrixInConsole();

                //zad5

                //Console.WriteLine("Enter path to file with matrix A:");
                //string path1 = Console.ReadLine();
                //Matrica A = new Matrica(path1);
                //Console.WriteLine("Enter path to file with vector b:");
                //string path2 = Console.ReadLine();
                //Matrica b = new Matrica(path2);
                //Matrica.SolveSystemOfLinearEquations(A, b, epsilon);

                //zad6

                //Console.WriteLine("Enter path to file with matrix A:");
                //string path1 = Console.ReadLine();
                //Matrica A = new Matrica(path1);
                //Console.WriteLine("Enter path to file with vector b:");
                //string path2 = Console.ReadLine();
                //Matrica b = new Matrica(path2);
                //Matrica.SolveSystemOfLinearEquations(A, b, comparingValue);
                //A.LUPDecomposition(comparingValue, b);
                //Matrica y = Matrica.ForwardSubstitution(A, b);
                //Matrica x = Matrica.BackwardSubstitution(A, y, epsilon);
                //x.WriteMatrixInConsole();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
