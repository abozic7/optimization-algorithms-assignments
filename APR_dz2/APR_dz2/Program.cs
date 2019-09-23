using System;
using System.Collections.Generic;

namespace APR_dz2
{
    class Program
    {
        static void Main(string[] args)
        {
            ////zadatak 1
            try
            {
                Function f1 = new GoalFunctionZad1();
                FunctionOptimization.GoldenSectionOptimization(f1);
                FunctionOptimization.CoordinateDescentOptimization(f1);
                FunctionOptimization.NelderMeadOptimization(f1);
                FunctionOptimization.HookeJeevesOptimization(f1);
                WriteCounterInConsole(f1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            ////zadatak 2
            //try
            //{
            //    Function f1 = new GoalFunction1();
            //    FunctionOptimization.CoordinateDescentOptimization(f1);
            //    FunctionOptimization.NelderMeadOptimization(f1);
            //    FunctionOptimization.HookeJeevesOptimization(f1);
            //    WriteCounterInConsole(f1);

            //    Function f2 = new GoalFunction2();
            //    FunctionOptimization.CoordinateDescentOptimization(f2);
            //    FunctionOptimization.NelderMeadOptimization(f2);
            //    FunctionOptimization.HookeJeevesOptimization(f2);
            //    WriteCounterInConsole(f2);

            //    Function f3 = new GoalFunction3();
            //    FunctionOptimization.CoordinateDescentOptimization(f3);
            //    FunctionOptimization.NelderMeadOptimization(f3);
            //    FunctionOptimization.HookeJeevesOptimization(f3);
            //    WriteCounterInConsole(f3);

            //    Function f4 = new GoalFunction4();
            //    FunctionOptimization.CoordinateDescentOptimization(f4);
            //    FunctionOptimization.NelderMeadOptimization(f4);
            //    FunctionOptimization.HookeJeevesOptimization(f4);
            //    WriteCounterInConsole(f4);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            ////zadatak 3
            //try
            //{
            //    Function f4 = new GoalFunction4();
            //    FunctionOptimization.NelderMeadOptimization(f4);
            //    FunctionOptimization.HookeJeevesOptimization(f4);
            //    WriteCounterInConsole(f4);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            ////zadatak 4
            //try
            //{
            //    Function f1 = new GoalFunction1();
            //    FunctionOptimization.NelderMeadOptimization(f1);
            //    WriteCounterInConsole(f1);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            ////zadatak5
            //Console.WriteLine("Upišite putanju do datoteke u koju želite spremiti nasumično generiranu početnu točku:");
            //string path = Console.ReadLine();
            //try
            //{
            //    Random random = new Random();
            //    double point;

            //    using (StreamWriter sw = new StreamWriter(File.Open(path, FileMode.OpenOrCreate)))
            //    {
            //        for (int i = 0; i < 2; i++)
            //        {
            //            point = -50 + random.NextDouble() * (50 + 50 + 1);
            //            sw.WriteLine(point.ToString(System.Globalization.CultureInfo.InvariantCulture));
            //        }
            //    }

            //    Function f6 = new GoalFunction6();
            //    Matrica startingPoint = new Matrica(path);
            //    Console.WriteLine("Upišite putanju do datoteke s vektorom granične preciznosti e:");
            //    string path2 = Console.ReadLine();
            //    Matrica e = new Matrica(path2);
            //    Console.WriteLine("Upišite putanju do datoteke s vektorom pomaka:");
            //    string path3 = Console.ReadLine();
            //    Matrica dx = new Matrica(path3);
            //    Matrica result = HookeJeevesMethod.FindMinimum(startingPoint, f6, e, dx);
            //    Console.WriteLine("\nRješenje:");
            //    Console.WriteLine("============");
            //    result.WriteMatrixInConsole();
            //    WriteCounterInConsole(f6);
            //}
            //catch (IOException)
            //{
            //    throw new ArgumentException("Došlo je do greške: putanja koju ste predali ne postoji!");
            //}

        }

        public static void WriteCounterInConsole(Function function)
        {
            Console.WriteLine("Broj evaluacija:");
            Console.WriteLine("===================");
            Dictionary<String, int> counter = function.GetFunctionCounter();
            foreach (var key in counter.Keys)
            {
                Console.WriteLine(key + ": " + counter[key]);
            }
            Console.WriteLine();
        }
    }
}
