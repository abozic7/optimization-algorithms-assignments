using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz4
{
    class Program
    {
        static void Main(string[] args)
        {
            int population, noOfEvaluations;
            bool binaryRepresentation;
            double mutationProbability;

            Console.WriteLine("Upišite putanju do datoteke s vrijednostima:");
            string path1 = Console.ReadLine();
            try
            {
                using (StreamReader sr = new StreamReader(File.Open(path1, FileMode.Open)))
                {
                    string line;
                    line = sr.ReadLine();
                    population = FileUtils.ReadIntegerFromFile(line);
                    line = sr.ReadLine();
                    binaryRepresentation = FileUtils.ReadBooleanFromFile(line);
                    line = sr.ReadLine();
                    mutationProbability = FileUtils.ReadDoubleFromFile(line);
                    line = sr.ReadLine();
                    noOfEvaluations = FileUtils.ReadIntegerFromFile(line);
                }
            }
            catch (IOException)
            {
                throw new ArgumentException("Došlo je do greške: datoteka iz koje želite čitati ne postoji!");
            }

            //ZAD1

            //Function f = new CostFunction1();
            //ExplicitRestriction[] er = new ExplicitRestriction[2];
            //er[0] = new ExplicitRestriction(-50, 150);
            //er[1] = new ExplicitRestriction(-50, 150);

            //Individual res1 = GeneticAlgorithm.FindMinimum(f, er, 3, population, binaryRepresentation, mutationProbability, noOfEvaluations, 3);
            //res1.DecimalValuePoint.WriteMatrixInConsole();
            //Console.WriteLine("f(x) = " + res1.FunctionValue);
            //Console.WriteLine();

            //Console.WriteLine("Upišite putanju do datoteke s vrijednostima:");
            //string path2 = Console.ReadLine();
            //try
            //{
            //    using (StreamReader sr = new StreamReader(File.Open(path2, FileMode.Open)))
            //    {
            //        string line;
            //        line = sr.ReadLine();
            //        population = FileUtils.ReadIntegerFromFile(line);
            //        line = sr.ReadLine();
            //        binaryRepresentation = FileUtils.ReadBooleanFromFile(line);
            //        line = sr.ReadLine();
            //        mutationProbability = FileUtils.ReadDoubleFromFile(line);
            //        line = sr.ReadLine();
            //        noOfEvaluations = FileUtils.ReadIntegerFromFile(line);
            //    }
            //}
            //catch (IOException)
            //{
            //    throw new ArgumentException("Došlo je do greške: datoteka iz koje želite čitati ne postoji!");
            //}

            //Individual res2 = GeneticAlgorithm.FindMinimum(f, er, 3, population, binaryRepresentation, mutationProbability, noOfEvaluations, 3);
            //res2.DecimalValuePoint.WriteMatrixInConsole();
            //Console.WriteLine("f(x) = " + res2.FunctionValue);



            //Function f = new CostFunction3();
            //ExplicitRestriction[] er = new ExplicitRestriction[5];
            //er[0] = new ExplicitRestriction(-50, 150);
            //er[1] = new ExplicitRestriction(-50, 150);
            //er[2] = new ExplicitRestriction(-50, 150);
            //er[3] = new ExplicitRestriction(-50, 150);
            //er[4] = new ExplicitRestriction(-50, 150);

            //Individual res1 = GeneticAlgorithm.FindMinimum(f, er, 3, population, binaryRepresentation, mutationProbability, noOfEvaluations, 3);
            //res1.DecimalValuePoint.WriteMatrixInConsole();
            //Console.WriteLine("f(x) = " + res1.FunctionValue);
            //Console.WriteLine();

            //Console.WriteLine("Upišite putanju do datoteke s vrijednostima:");
            //string path2 = Console.ReadLine();
            //try
            //{
            //    using (StreamReader sr = new StreamReader(File.Open(path2, FileMode.Open)))
            //    {
            //        string line;
            //        line = sr.ReadLine();
            //        population = FileUtils.ReadIntegerFromFile(line);
            //        line = sr.ReadLine();
            //        binaryRepresentation = FileUtils.ReadBooleanFromFile(line);
            //        line = sr.ReadLine();
            //        mutationProbability = FileUtils.ReadDoubleFromFile(line);
            //        line = sr.ReadLine();
            //        noOfEvaluations = FileUtils.ReadIntegerFromFile(line);
            //    }
            //}
            //catch (IOException)
            //{
            //    throw new ArgumentException("Došlo je do greške: datoteka iz koje želite čitati ne postoji!");
            //}

            //Individual res2 = GeneticAlgorithm.FindMinimum(f, er, 3, population, binaryRepresentation, mutationProbability, noOfEvaluations, 3);
            //res2.DecimalValuePoint.WriteMatrixInConsole();
            //Console.WriteLine("f(x) = " + res2.FunctionValue);



            //Function f = new CostFunction6();
            //ExplicitRestriction[] er = new ExplicitRestriction[2];
            //er[0] = new ExplicitRestriction(-50, 150);
            //er[1] = new ExplicitRestriction(-50, 150);

            //Individual res1 = GeneticAlgorithm.FindMinimum(f, er, 3, population, binaryRepresentation, mutationProbability, noOfEvaluations, 3);
            //res1.DecimalValuePoint.WriteMatrixInConsole();
            //Console.WriteLine("f(x) = " + res1.FunctionValue);
            //Console.WriteLine();

            //Console.WriteLine("Upišite putanju do datoteke s vrijednostima:");
            //string path2 = Console.ReadLine();
            //try
            //{
            //    using (StreamReader sr = new StreamReader(File.Open(path2, FileMode.Open)))
            //    {
            //        string line;
            //        line = sr.ReadLine();
            //        population = FileUtils.ReadIntegerFromFile(line);
            //        line = sr.ReadLine();
            //        binaryRepresentation = FileUtils.ReadBooleanFromFile(line);
            //        line = sr.ReadLine();
            //        mutationProbability = FileUtils.ReadDoubleFromFile(line);
            //        line = sr.ReadLine();
            //        noOfEvaluations = FileUtils.ReadIntegerFromFile(line);
            //    }
            //}
            //catch (IOException)
            //{
            //    throw new ArgumentException("Došlo je do greške: datoteka iz koje želite čitati ne postoji!");
            //}

            //Individual res2 = GeneticAlgorithm.FindMinimum(f, er, 3, population, binaryRepresentation, mutationProbability, noOfEvaluations, 3);
            //res2.DecimalValuePoint.WriteMatrixInConsole();
            //Console.WriteLine("f(x) = " + res2.FunctionValue);



            //Function f = new CostFunction7();
            //ExplicitRestriction[] er = new ExplicitRestriction[2];
            //er[0] = new ExplicitRestriction(-50, 150);
            //er[1] = new ExplicitRestriction(-50, 150);

            //Individual res1 = GeneticAlgorithm.FindMinimum(f, er, 3, population, binaryRepresentation, mutationProbability, noOfEvaluations, 3);
            //res1.DecimalValuePoint.WriteMatrixInConsole();
            //Console.WriteLine("f(x) = " + res1.FunctionValue);
            //Console.WriteLine();

            //Console.WriteLine("Upišite putanju do datoteke s vrijednostima:");
            //string path2 = Console.ReadLine();
            //try
            //{
            //    using (StreamReader sr = new StreamReader(File.Open(path2, FileMode.Open)))
            //    {
            //        string line;
            //        line = sr.ReadLine();
            //        population = FileUtils.ReadIntegerFromFile(line);
            //        line = sr.ReadLine();
            //        binaryRepresentation = FileUtils.ReadBooleanFromFile(line);
            //        line = sr.ReadLine();
            //        mutationProbability = FileUtils.ReadDoubleFromFile(line);
            //        line = sr.ReadLine();
            //        noOfEvaluations = FileUtils.ReadIntegerFromFile(line);
            //    }
            //}
            //catch (IOException)
            //{
            //    throw new ArgumentException("Došlo je do greške: datoteka iz koje želite čitati ne postoji!");
            //}

            //Individual res2 = GeneticAlgorithm.FindMinimum(f, er, 3, population, binaryRepresentation, mutationProbability, noOfEvaluations, 3);
            //res2.DecimalValuePoint.WriteMatrixInConsole();
            //Console.WriteLine("f(x) = " + res2.FunctionValue);




            //ZAD2

            //Function f = new CostFunction6();
            //ExplicitRestriction[] er = new ExplicitRestriction[1];
            //er[0] = new ExplicitRestriction(-50, 150);

            //Individual res1 = GeneticAlgorithm.FindMinimum(f, er, 3, population, binaryRepresentation, mutationProbability, noOfEvaluations, 3);
            //res1.DecimalValuePoint.WriteMatrixInConsole();
            //Console.WriteLine("f(x) = " + res1.FunctionValue);
            //Console.WriteLine();

            //Function f = new CostFunction6();
            //ExplicitRestriction[] er = new ExplicitRestriction[3];
            //er[0] = new ExplicitRestriction(-50, 150);
            //er[1] = new ExplicitRestriction(-50, 150);
            //er[2] = new ExplicitRestriction(-50, 150);

            //Individual res1 = GeneticAlgorithm.FindMinimum(f, er, 3, population, binaryRepresentation, mutationProbability, noOfEvaluations, 3);
            //res1.DecimalValuePoint.WriteMatrixInConsole();
            //Console.WriteLine("f(x) = " + res1.FunctionValue);
            //Console.WriteLine();

            //Function f = new CostFunction6();
            //ExplicitRestriction[] er = new ExplicitRestriction[6];
            //er[0] = new ExplicitRestriction(-50, 150);
            //er[1] = new ExplicitRestriction(-50, 150);
            //er[2] = new ExplicitRestriction(-50, 150);
            //er[3] = new ExplicitRestriction(-50, 150);
            //er[4] = new ExplicitRestriction(-50, 150);
            //er[5] = new ExplicitRestriction(-50, 150);

            //Individual res1 = GeneticAlgorithm.FindMinimum(f, er, 3, population, binaryRepresentation, mutationProbability, noOfEvaluations, 3);
            //res1.DecimalValuePoint.WriteMatrixInConsole();
            //Console.WriteLine("f(x) = " + res1.FunctionValue);
            //Console.WriteLine();

            //Function f = new CostFunction6();
            //ExplicitRestriction[] er = new ExplicitRestriction[10];
            //er[0] = new ExplicitRestriction(-50, 150);
            //er[1] = new ExplicitRestriction(-50, 150);
            //er[2] = new ExplicitRestriction(-50, 150);
            //er[3] = new ExplicitRestriction(-50, 150);
            //er[4] = new ExplicitRestriction(-50, 150);
            //er[5] = new ExplicitRestriction(-50, 150);
            //er[6] = new ExplicitRestriction(-50, 150);
            //er[7] = new ExplicitRestriction(-50, 150);
            //er[8] = new ExplicitRestriction(-50, 150);
            //er[9] = new ExplicitRestriction(-50, 150);

            //Individual res1 = GeneticAlgorithm.FindMinimum(f, er, 3, population, binaryRepresentation, mutationProbability, noOfEvaluations, 3);
            //res1.DecimalValuePoint.WriteMatrixInConsole();
            //Console.WriteLine("f(x) = " + res1.FunctionValue);
            //Console.WriteLine();



            //Function f = new CostFunction7();
            //ExplicitRestriction[] er = new ExplicitRestriction[1];
            //er[0] = new ExplicitRestriction(-50, 150);

            //Individual res1 = GeneticAlgorithm.FindMinimum(f, er, 3, population, binaryRepresentation, mutationProbability, noOfEvaluations, 3);
            //res1.DecimalValuePoint.WriteMatrixInConsole();
            //Console.WriteLine("f(x) = " + res1.FunctionValue);
            //Console.WriteLine();

            //Function f = new CostFunction7();
            //ExplicitRestriction[] er = new ExplicitRestriction[3];
            //er[0] = new ExplicitRestriction(-50, 150);
            //er[1] = new ExplicitRestriction(-50, 150);
            //er[2] = new ExplicitRestriction(-50, 150);

            //Individual res1 = GeneticAlgorithm.FindMinimum(f, er, 3, population, binaryRepresentation, mutationProbability, noOfEvaluations, 3);
            //res1.DecimalValuePoint.WriteMatrixInConsole();
            //Console.WriteLine("f(x) = " + res1.FunctionValue);
            //Console.WriteLine();

            //Function f = new CostFunction7();
            //ExplicitRestriction[] er = new ExplicitRestriction[6];
            //er[0] = new ExplicitRestriction(-50, 150);
            //er[1] = new ExplicitRestriction(-50, 150);
            //er[2] = new ExplicitRestriction(-50, 150);
            //er[3] = new ExplicitRestriction(-50, 150);
            //er[4] = new ExplicitRestriction(-50, 150);
            //er[5] = new ExplicitRestriction(-50, 150);

            //Individual res1 = GeneticAlgorithm.FindMinimum(f, er, 3, population, binaryRepresentation, mutationProbability, noOfEvaluations, 3);
            //res1.DecimalValuePoint.WriteMatrixInConsole();
            //Console.WriteLine("f(x) = " + res1.FunctionValue);
            //Console.WriteLine();

            //Function f = new CostFunction7();
            //ExplicitRestriction[] er = new ExplicitRestriction[10];
            //er[0] = new ExplicitRestriction(-50, 150);
            //er[1] = new ExplicitRestriction(-50, 150);
            //er[2] = new ExplicitRestriction(-50, 150);
            //er[3] = new ExplicitRestriction(-50, 150);
            //er[4] = new ExplicitRestriction(-50, 150);
            //er[5] = new ExplicitRestriction(-50, 150);
            //er[6] = new ExplicitRestriction(-50, 150);
            //er[7] = new ExplicitRestriction(-50, 150);
            //er[8] = new ExplicitRestriction(-50, 150);
            //er[9] = new ExplicitRestriction(-50, 150);

            //Individual res1 = GeneticAlgorithm.FindMinimum(f, er, 3, population, binaryRepresentation, mutationProbability, noOfEvaluations, 3);
            //res1.DecimalValuePoint.WriteMatrixInConsole();
            //Console.WriteLine("f(x) = " + res1.FunctionValue);
            //Console.WriteLine();




            //ZAD3

            //Function f = new CostFunction6();
            //ExplicitRestriction[] er = new ExplicitRestriction[3];
            //er[0] = new ExplicitRestriction(-50, 150);
            //er[1] = new ExplicitRestriction(-50, 150);
            //er[2] = new ExplicitRestriction(-50, 150);

            //Individual res1 = GeneticAlgorithm.FindMinimum(f, er, 4, population, binaryRepresentation, mutationProbability, noOfEvaluations, 3);
            //res1.DecimalValuePoint.WriteMatrixInConsole();
            //Console.WriteLine("f(x) = " + res1.FunctionValue);
            //Console.WriteLine();

            //Console.WriteLine("Upišite putanju do datoteke s vrijednostima:");
            //string path2 = Console.ReadLine();
            //try
            //{
            //    using (StreamReader sr = new StreamReader(File.Open(path2, FileMode.Open)))
            //    {
            //        string line;
            //        line = sr.ReadLine();
            //        population = FileUtils.ReadIntegerFromFile(line);
            //        line = sr.ReadLine();
            //        binaryRepresentation = FileUtils.ReadBooleanFromFile(line);
            //        line = sr.ReadLine();
            //        mutationProbability = FileUtils.ReadDoubleFromFile(line);
            //        line = sr.ReadLine();
            //        noOfEvaluations = FileUtils.ReadIntegerFromFile(line);
            //    }
            //}
            //catch (IOException)
            //{
            //    throw new ArgumentException("Došlo je do greške: datoteka iz koje želite čitati ne postoji!");
            //}

            //Individual res2 = GeneticAlgorithm.FindMinimum(f, er, 4, population, binaryRepresentation, mutationProbability, noOfEvaluations, 3);
            //res2.DecimalValuePoint.WriteMatrixInConsole();
            //Console.WriteLine("f(x) = " + res2.FunctionValue);


            //Function f = new CostFunction6();
            //ExplicitRestriction[] er = new ExplicitRestriction[6];
            //er[0] = new ExplicitRestriction(-50, 150);
            //er[1] = new ExplicitRestriction(-50, 150);
            //er[2] = new ExplicitRestriction(-50, 150);
            //er[3] = new ExplicitRestriction(-50, 150);
            //er[4] = new ExplicitRestriction(-50, 150);
            //er[5] = new ExplicitRestriction(-50, 150);

            //Individual res1 = GeneticAlgorithm.FindMinimum(f, er, 4, population, binaryRepresentation, mutationProbability, noOfEvaluations, 3);
            //res1.DecimalValuePoint.WriteMatrixInConsole();
            //Console.WriteLine("f(x) = " + res1.FunctionValue);
            //Console.WriteLine();

            //Console.WriteLine("Upišite putanju do datoteke s vrijednostima:");
            //string path2 = Console.ReadLine();
            //try
            //{
            //    using (StreamReader sr = new StreamReader(File.Open(path2, FileMode.Open)))
            //    {
            //        string line;
            //        line = sr.ReadLine();
            //        population = FileUtils.ReadIntegerFromFile(line);
            //        line = sr.ReadLine();
            //        binaryRepresentation = FileUtils.ReadBooleanFromFile(line);
            //        line = sr.ReadLine();
            //        mutationProbability = FileUtils.ReadDoubleFromFile(line);
            //        line = sr.ReadLine();
            //        noOfEvaluations = FileUtils.ReadIntegerFromFile(line);
            //    }
            //}
            //catch (IOException)
            //{
            //    throw new ArgumentException("Došlo je do greške: datoteka iz koje želite čitati ne postoji!");
            //}

            //Individual res2 = GeneticAlgorithm.FindMinimum(f, er, 4, population, binaryRepresentation, mutationProbability, noOfEvaluations, 3);
            //res2.DecimalValuePoint.WriteMatrixInConsole();
            //Console.WriteLine("f(x) = " + res2.FunctionValue);



            //Function f = new CostFunction7();
            //ExplicitRestriction[] er = new ExplicitRestriction[3];
            //er[0] = new ExplicitRestriction(-50, 150);
            //er[1] = new ExplicitRestriction(-50, 150);
            //er[2] = new ExplicitRestriction(-50, 150);

            //Individual res1 = GeneticAlgorithm.FindMinimum(f, er, 4, population, binaryRepresentation, mutationProbability, noOfEvaluations, 3);
            //res1.DecimalValuePoint.WriteMatrixInConsole();
            //Console.WriteLine("f(x) = " + res1.FunctionValue);
            //Console.WriteLine();

            //Console.WriteLine("Upišite putanju do datoteke s vrijednostima:");
            //string path2 = Console.ReadLine();
            //try
            //{
            //    using (StreamReader sr = new StreamReader(File.Open(path2, FileMode.Open)))
            //    {
            //        string line;
            //        line = sr.ReadLine();
            //        population = FileUtils.ReadIntegerFromFile(line);
            //        line = sr.ReadLine();
            //        binaryRepresentation = FileUtils.ReadBooleanFromFile(line);
            //        line = sr.ReadLine();
            //        mutationProbability = FileUtils.ReadDoubleFromFile(line);
            //        line = sr.ReadLine();
            //        noOfEvaluations = FileUtils.ReadIntegerFromFile(line);
            //    }
            //}
            //catch (IOException)
            //{
            //    throw new ArgumentException("Došlo je do greške: datoteka iz koje želite čitati ne postoji!");
            //}

            //Individual res2 = GeneticAlgorithm.FindMinimum(f, er, 4, population, binaryRepresentation, mutationProbability, noOfEvaluations, 3);
            //res2.DecimalValuePoint.WriteMatrixInConsole();
            //Console.WriteLine("f(x) = " + res2.FunctionValue);


            //Function f = new CostFunction7();
            //ExplicitRestriction[] er = new ExplicitRestriction[6];
            //er[0] = new ExplicitRestriction(-50, 150);
            //er[1] = new ExplicitRestriction(-50, 150);
            //er[2] = new ExplicitRestriction(-50, 150);
            //er[3] = new ExplicitRestriction(-50, 150);
            //er[4] = new ExplicitRestriction(-50, 150);
            //er[5] = new ExplicitRestriction(-50, 150);

            //Individual res1 = GeneticAlgorithm.FindMinimum(f, er, 4, population, binaryRepresentation, mutationProbability, noOfEvaluations, 3);
            //res1.DecimalValuePoint.WriteMatrixInConsole();
            //Console.WriteLine("f(x) = " + res1.FunctionValue);
            //Console.WriteLine();

            //Console.WriteLine("Upišite putanju do datoteke s vrijednostima:");
            //string path2 = Console.ReadLine();
            //try
            //{
            //    using (StreamReader sr = new StreamReader(File.Open(path2, FileMode.Open)))
            //    {
            //        string line;
            //        line = sr.ReadLine();
            //        population = FileUtils.ReadIntegerFromFile(line);
            //        line = sr.ReadLine();
            //        binaryRepresentation = FileUtils.ReadBooleanFromFile(line);
            //        line = sr.ReadLine();
            //        mutationProbability = FileUtils.ReadDoubleFromFile(line);
            //        line = sr.ReadLine();
            //        noOfEvaluations = FileUtils.ReadIntegerFromFile(line);
            //    }
            //}
            //catch (IOException)
            //{
            //    throw new ArgumentException("Došlo je do greške: datoteka iz koje želite čitati ne postoji!");
            //}

            //Individual res2 = GeneticAlgorithm.FindMinimum(f, er, 4, population, binaryRepresentation, mutationProbability, noOfEvaluations, 3);
            //res2.DecimalValuePoint.WriteMatrixInConsole();
            //Console.WriteLine("f(x) = " + res2.FunctionValue);




            //ZAD4

            //Function f = new CostFunction6();
            //ExplicitRestriction[] er = new ExplicitRestriction[2];
            //er[0] = new ExplicitRestriction(-50, 150);
            //er[1] = new ExplicitRestriction(-50, 150);

            //Individual res1 = GeneticAlgorithm.FindMinimum(f, er, 3, population, binaryRepresentation, mutationProbability, noOfEvaluations, 3);
            //res1.DecimalValuePoint.WriteMatrixInConsole();
            //Console.WriteLine("f(x) = " + res1.FunctionValue);
            //Console.WriteLine();




            //ZAD5

            //Function f = new CostFunction6();
            //ExplicitRestriction[] er = new ExplicitRestriction[2];
            //er[0] = new ExplicitRestriction(-50, 150);
            //er[1] = new ExplicitRestriction(-50, 150);

            //Individual res1 = GeneticAlgorithm.FindMinimum(f, er, 3, population, binaryRepresentation, mutationProbability, noOfEvaluations, 5);
            //res1.DecimalValuePoint.WriteMatrixInConsole();
            //Console.WriteLine("f(x) = " + res1.FunctionValue);
            //Console.WriteLine();
        }
    }
}
