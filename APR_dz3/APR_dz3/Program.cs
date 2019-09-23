using APR_dz1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // zad1

                //Console.WriteLine("Enter path to file with starting point:");
                //string path1 = Console.ReadLine();
                //Matrica startingPoint = new Matrica(path1);
                //Console.WriteLine("Enter path to file with precision e:");
                //string path2 = Console.ReadLine();
                //double e = OptimizationUtils.ReadValueFromFile(path2);
                //Function f = new CostFunction3();
                //Matrica res1 = GradientDescent.FindMinimum(f, e, startingPoint, true);
                //res1.WriteMatrixInConsole();
                //WriteCounterValueInConsole(f);
                //WriteCounterGradientValueInConsole(f);
                //f.ResetCounterValue();
                //f.ResetCounterGradientValue();
                //Matrica res2 = GradientDescent.FindMinimum(f, e, startingPoint, false);
                //res2.WriteMatrixInConsole();
                //Console.WriteLine("f(Xmin) = " + f.CalculateValue(res2.VectorToArray()));
                //Console.WriteLine();
                //WriteCounterValueInConsole(f);
                //WriteCounterGradientValueInConsole(f);

                // zad2

                //Console.WriteLine("Enter path to file with starting point:");
                //string path1 = Console.ReadLine();
                //Matrica startingPoint1 = new Matrica(path1);
                //Function f1 = new CostFunction1();
                //Console.WriteLine("Enter path to file with precision e:");
                //string path2 = Console.ReadLine();
                //double e = OptimizationUtils.ReadValueFromFile(path2);
                //Matrica res1 = GradientDescent.FindMinimum(f1, e, startingPoint1, true);
                //res1.WriteMatrixInConsole();
                //Console.WriteLine("f(Xmin) = " + f1.CalculateValue(res1.VectorToArray()));
                //Console.WriteLine();
                //Matrica res2 = NewtonRaphsonMethod.FindMinimum(f1, e, startingPoint1, true);
                //res2.WriteMatrixInConsole();
                //Console.WriteLine("f(Xmin) = " + f1.CalculateValue(res2.VectorToArray()));
                //Console.WriteLine();
                //WriteCounterValueInConsole(f1);
                //WriteCounterGradientValueInConsole(f1);
                //WriteCounterHessianInConsole(f1);

                //Console.WriteLine("Enter path to file with starting point:");
                //string path3 = Console.ReadLine();
                //Matrica startingPoint2 = new Matrica(path3);
                //Function f2 = new CostFunction2();
                //Matrica res3 = GradientDescent.FindMinimum(f2, e, startingPoint2, true);
                //res3.WriteMatrixInConsole();
                //Console.WriteLine("f(Xmin) = " + f2.CalculateValue(res3.VectorToArray()));
                //Console.WriteLine();
                //Matrica res4 = NewtonRaphsonMethod.FindMinimum(f2, e, startingPoint2, true);
                //res4.WriteMatrixInConsole();
                //Console.WriteLine("f(Xmin) = " + f2.CalculateValue(res4.VectorToArray()));
                //Console.WriteLine();
                //WriteCounterValueInConsole(f2);
                //WriteCounterGradientValueInConsole(f2);
                //WriteCounterHessianInConsole(f2);

                //zad3

                //Console.WriteLine("Enter path to file with starting point:");
                //string path1 = Console.ReadLine();
                //Matrica startingPoint1 = new Matrica(path1);
                //Console.WriteLine("Upišite putanju do datoteke s alfa:");
                //string path2 = Console.ReadLine();
                //double alfa = OptimizationUtils.ReadValueFromFile(path2);
                //Function f1 = new CostFunction1();
                //List<RestrictionExpression> ir = new List<RestrictionExpression>();
                //ImplicitRestrictions1 ir1 = new ImplicitRestrictions1();
                //ImplicitRestrictions2 ir2 = new ImplicitRestrictions2();
                //ir.Add(ir1);
                //ir.Add(ir2);
                //ExplicitRestriction er = new ExplicitRestriction();
                //er.SetExplicitRestriction(-100, 100);
                //Matrica res1 = BoxMethod.FindMinimum(f1, ir, er, startingPoint1, alfa, 5000);
                //res1.WriteMatrixInConsole();
                //Console.WriteLine("f(Xmin) = " + f1.CalculateValue(res1.VectorToArray()));
                //Console.WriteLine();
                //WriteCounterValueInConsole(f1);

                //Console.WriteLine("Enter path to file with starting point:");
                //string path3 = Console.ReadLine();
                //Matrica startingPoint2 = new Matrica(path3);
                //Function f2 = new CostFunction2();
                //Matrica res2 = BoxMethod.FindMinimum(f2, ir, er, startingPoint2, alfa, 5000);
                //res2.WriteMatrixInConsole();
                //Console.WriteLine("f(Xmin) = " + f2.CalculateValue(res2.VectorToArray()));
                //Console.WriteLine();
                //WriteCounterValueInConsole(f2);

                //zad4

                //Console.WriteLine("Enter path to file with starting point:");
                //string path1 = Console.ReadLine();
                //Matrica startingPoint1 = new Matrica(path1);
                //Console.WriteLine("Enter path to file with Hooke-Jeeves precision epsilon:");
                //string path2 = Console.ReadLine();
                //Matrica epsilon = new Matrica(path2);
                //Console.WriteLine("Enter path to file with Hooke-Jeeves step delta x:");
                //string path3 = Console.ReadLine();
                //Matrica deltaX = new Matrica(path3);
                //Console.WriteLine("Enter path to file with precision e:");
                //string path4 = Console.ReadLine();
                //double e = OptimizationUtils.ReadValueFromFile(path4);
                //Console.WriteLine("Enter path to file with parameter of transformation t:");
                //string path5 = Console.ReadLine();
                //double t = OptimizationUtils.ReadValueFromFile(path5);

                //Function f1 = new CostFunction1();
                //List<RestrictionExpression> ir = new List<RestrictionExpression>();
                //ImplicitRestrictions1 ir1 = new ImplicitRestrictions1();
                //ImplicitRestrictions2 ir2 = new ImplicitRestrictions2();

                //ir.Add(ir1);
                //ir.Add(ir2);
                //Matrica res1 = TransformFunctionMethod.FindMinimum(ir, f1, t, e, startingPoint1, epsilon, deltaX, 5000);
                //res1.WriteMatrixInConsole();
                //Console.WriteLine("f(Xmin) = " + f1.CalculateValue(res1.VectorToArray()));
                //Console.WriteLine();
                //WriteCounterValueInConsole(f1);

                //Console.WriteLine("Enter path to file with starting point:");
                //string path6 = Console.ReadLine();
                //Matrica startingPoint2 = new Matrica(path6);
                //Function f2 = new CostFunction2();
                //Matrica res2 = TransformFunctionMethod.FindMinimum(ir, f2, t, e, startingPoint2, epsilon, deltaX, 5000);
                //res2.WriteMatrixInConsole();
                //Console.WriteLine("f(Xmin) = " + f2.CalculateValue(res2.VectorToArray()));
                //Console.WriteLine();
                //WriteCounterValueInConsole(f2);

                //zad5

                //Console.WriteLine("Enter path to file with starting point:");
                //string path1 = Console.ReadLine();
                //Matrica startingPoint = new Matrica(path1);
                //Console.WriteLine("Enter path to file with Hooke-Jeeves precision epsilon:");
                //string path2 = Console.ReadLine();
                //Matrica epsilon = new Matrica(path2);
                //Console.WriteLine("Enter path to file with Hooke-Jeeves step delta x:");
                //string path3 = Console.ReadLine();
                //Matrica deltaX = new Matrica(path3);
                //Console.WriteLine("Enter path to file with precision e:");
                //string path4 = Console.ReadLine();
                //double e = OptimizationUtils.ReadValueFromFile(path4);
                //Console.WriteLine("Enter path to file with parameter of transformation t:");
                //string path5 = Console.ReadLine();
                //double t = OptimizationUtils.ReadValueFromFile(path5);

                //Function f = new CostFunction4();
                //List<RestrictionExpression> ir = new List<RestrictionExpression>();
                //ImplicitRestrictions3 ir3 = new ImplicitRestrictions3();
                //ImplicitRestrictions4 ir4 = new ImplicitRestrictions4();
                //ImplicitRestrictions5 ir5 = new ImplicitRestrictions5();

                //ir.Add(ir3);
                //ir.Add(ir4);
                //ir.Add(ir5);
                //Matrica res = TransformFunctionMethod.FindMinimum(ir, f, t, e, startingPoint, epsilon, deltaX, 5000);
                //res.WriteMatrixInConsole();
                //Console.WriteLine("f(Xmin) = " + f.CalculateValue(res.VectorToArray()));
                //Console.WriteLine();
                //WriteCounterValueInConsole(f);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void WriteCounterValueInConsole(Function function)
        {
            Console.WriteLine("Number of function evaluations:");
            Console.WriteLine("===================");
            Dictionary<String, int> counter = function.GetFunctionCounterValue();
            foreach (var key in counter.Keys)
            {
                Console.WriteLine(key + ": " + counter[key]);
            }
            Console.WriteLine();
        }

        public static void WriteCounterGradientValueInConsole(Function function)
        {
            Console.WriteLine("Number of gradient calculation calls:");
            Console.WriteLine("===================");
            Dictionary<String, int> counter = function.GetFunctionCounterGradientValue();
            foreach (var key in counter.Keys)
            {
                Console.WriteLine(key + ": " + counter[key]);
            }
            Console.WriteLine();
        }

        public static void WriteCounterHessianInConsole(Function function)
        {
            Console.WriteLine("Number of Hessian matrix calculation calls:");
            Console.WriteLine("===================");
            Dictionary<String, int> counter = function.GetFunctionCounterHessian();
            foreach (var key in counter.Keys)
            {
                Console.WriteLine(key + ": " + counter[key]);
            }
            Console.WriteLine();
        }
    }
}
