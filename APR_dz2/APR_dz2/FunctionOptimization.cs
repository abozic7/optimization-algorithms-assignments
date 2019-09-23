using APR_dz1;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz2
{
    public class FunctionOptimization
    {
        public static String algorithmNameGS = "Golden Section";
        public static String algorithmNameCD = "Coordinate Descent";

        /// <summary>
        /// Executes Golden Section Optimization algorithm for given function.
        /// </summary>
        /// <param name="f">Function used in algorithm.</param>

        public static void GoldenSectionOptimization(Function f)
        {
            Console.WriteLine("ZLATNI REZ:");
            Console.WriteLine("============================================");
            Console.WriteLine("Unesite 1 ako želite predati početnu točku za koju će se izračunati unimodalni interval ili 2 ako unosite unimodalni interval iz datoteke sami.");
            string line = Console.ReadLine();
            int choice = Int32.Parse(line);

            if(choice == 1)
            {
                Console.WriteLine("Upišite putanju do datoteke s početnom točkom:");
                string path1 = Console.ReadLine();
                double startingPoint = ReadValueFromFile(path1);
                Console.WriteLine("Upišite putanju do datoteke s preciznosti e:");
                string path2 = Console.ReadLine();
                double e = ReadValueFromFile(path2);
                Console.WriteLine("Upišite putanju do datoteke s pomakom pretraživanja h:");
                string path3 = Console.ReadLine();
                double h = ReadValueFromFile(path3);
                UnimodalInterval interval = UnimodalInterval.FindUnimodalInterval(f, startingPoint, h);
                UnimodalInterval result = GoldenSection.FindMinimum(f, interval.Minimum, interval.Maximum, e);
                Console.WriteLine("\nRješenje:");
                Console.WriteLine("============");
                Console.WriteLine("[" + result.Minimum + ", " + result.Maximum + "]");
            }
            else if(choice == 2)
            {
                Console.WriteLine("Upišite putanju do datoteke s unimodalnim intervalom:");
                string path1 = Console.ReadLine();
                UnimodalInterval interval = GetUnimodalIntervalFromFile(path1);
                Console.WriteLine("Upišite putanju do datoteke s preciznosti e:");
                string path2 = Console.ReadLine();
                double e = ReadValueFromFile(path2);
                UnimodalInterval result = GoldenSection.FindMinimum(f, interval.Minimum, interval.Maximum, e);
                Console.WriteLine("\nRješenje:");
                Console.WriteLine("============");
                Console.WriteLine("[" + result.Minimum + ", " + result.Maximum + "]");
            }
            else
            {
                throw new ArgumentException("Niste odabrali ni 1 ni 2!");
            }
        }

        /// <summary>
        /// Executes Coordinate Descent Optimization algorithm for given function.
        /// </summary>
        /// <param name="f">Function used in algorithm.</param>

        public static void CoordinateDescentOptimization(Function f)
        {
            int gsCounterBefore = f.GetCounterValue(algorithmNameGS);
            Console.WriteLine("PRETRAŽIVANJE PO KOORDINATNIM OSIMA:");
            Console.WriteLine("============================================");
            Console.WriteLine("Upišite putanju do datoteke s početnom točkom:");
            string path1 = Console.ReadLine();
            Matrica startingPoint = new Matrica(path1);
            Console.WriteLine("Upišite putanju do datoteke s vektorom granične preciznosti e:");
            string path2 = Console.ReadLine();
            Matrica e = new Matrica(path2);
            Matrica result = SearchByCoordinateAxes.FindMinimum(startingPoint, e, f, 1);
            int gsCounterAfter = f.GetCounterValue(algorithmNameGS);
            f.SetCounterValue(algorithmNameCD, gsCounterAfter - gsCounterBefore);
            f.SetCounterValue(algorithmNameGS, gsCounterBefore);
            Console.WriteLine("\nRješenje:");
            Console.WriteLine("============");
            result.WriteMatrixInConsole();
        }

        /// <summary>
        /// Executes Nelder-Mead Simplex Optimization algorithm for given function.
        /// </summary>
        /// <param name="f">Function used in algorithm.</param>

        public static void NelderMeadOptimization(Function f)
        {
            Console.WriteLine("NELDER-MEAD SIMPLEX:");
            Console.WriteLine("============================================");
            Console.WriteLine("Upišite putanju do datoteke s početnom točkom:");
            string path1 = Console.ReadLine();
            Matrica startingPoint = new Matrica(path1);
            Console.WriteLine("Upišite putanju do datoteke s preciznosti e:");
            string path2 = Console.ReadLine();
            double e = ReadValueFromFile(path2);
            Console.WriteLine("Upišite putanju do datoteke s pomakom:");
            string path3 = Console.ReadLine();
            double shift = ReadValueFromFile(path3);
            Console.WriteLine("Upišite putanju do datoteke s alfom:");
            string path4 = Console.ReadLine();
            double alfa = ReadValueFromFile(path4);
            Console.WriteLine("Upišite putanju do datoteke s betom:");
            string path5 = Console.ReadLine();
            double beta = ReadValueFromFile(path5);
            Console.WriteLine("Upišite putanju do datoteke s gamom:");
            string path6 = Console.ReadLine();
            double gamma = ReadValueFromFile(path6);
            Console.WriteLine("Upišite putanju do datoteke sa sigmom:");
            string path7 = Console.ReadLine();
            double sigma = ReadValueFromFile(path7);
            Matrica result = NelderMeadSimplex.FindMinimum(startingPoint, shift, f, alfa, beta, gamma, e, sigma);
            Console.WriteLine("\nRješenje:");
            Console.WriteLine("============");
            result.WriteMatrixInConsole();
        }

        /// <summary>
        /// Executes Hooke-Jeeves Optimization algorithm for given function.
        /// </summary>
        /// <param name="f">Function used in algorithm.</param>

        public static void HookeJeevesOptimization(Function f)
        {
            Console.WriteLine("HOOKE-JEEVES METODA:");
            Console.WriteLine("============================================");
            Console.WriteLine("Upišite putanju do datoteke s početnom točkom:");
            string path1 = Console.ReadLine();
            Matrica startingPoint = new Matrica(path1);
            Console.WriteLine("Upišite putanju do datoteke s vektorom granične preciznosti e:");
            string path2 = Console.ReadLine();
            Matrica e = new Matrica(path2);
            Console.WriteLine("Upišite putanju do datoteke s vektorom pomaka:");
            string path3 = Console.ReadLine();
            Matrica dx = new Matrica(path3);
            Matrica result = HookeJeevesMethod.FindMinimum(startingPoint, f, e, dx);
            Console.WriteLine("\nRješenje:");
            Console.WriteLine("============");
            result.WriteMatrixInConsole();
        }

        /// <summary>
        /// Reads a value from file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <returns>Last value in file parsed to double.</returns>

        public static double ReadValueFromFile(String path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(File.Open(path, FileMode.Open)))
                {
                    string line;
                    line = sr.ReadLine();
                    if(line != null)
                    {
                        line.Trim();
                    }
                    else
                    {
                        throw new ArgumentException("Datoteka je prazna!");
                    }

                    return Double.Parse(line, CultureInfo.InvariantCulture);
                }
            }
            catch (IOException)
            {
                throw new ArgumentException("Došlo je do greške: datoteka iz koje želite čitati ne postoji!");
            }
        }

        public static UnimodalInterval GetUnimodalIntervalFromFile(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(File.Open(path, FileMode.Open)))
                {
                    string line;
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        line.Trim();
                    }
                    else
                    {
                        throw new ArgumentException("Datoteka je prazna!");
                    }
                    string[] values = line.Split(',');
                    foreach (var val in values)
                    {
                        val.Trim();
                    }
                    if(values.Length != 2)
                    {
                        throw new ArgumentException("Podaci ne odgovaraju za kreiranje unimodalnog intervala. Provjerite datoteku!");
                    }

                    return new UnimodalInterval(Double.Parse(values[0]), Double.Parse(values[1]));
                }
            }
            catch (IOException)
            {
                throw new ArgumentException("Došlo je do greške: datoteka iz koje želite čitati ne postoji!");
            }
        }
    }
}
