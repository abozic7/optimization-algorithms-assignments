using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz5
{
    public class FileUtils
    {
        public static Double ReadDoubleFromFile(String path)
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
                        return Double.Parse(line, CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        throw new ArgumentException("Redak je prazan - nedostaje podatak!");
                    }
                }
            }
            catch (IOException)
            {
                throw new ArgumentException("Došlo je do greške: datoteka iz koje želite čitati ne postoji!");
            }
        }

        public static Int32 ReadIntegerFromFile(String path)
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
                        return Int32.Parse(line);
                    }
                    else
                    {
                        throw new ArgumentException("Redak je prazan - nedostaje podatak!");
                    }
                }
            }
            catch (IOException)
            {
                throw new ArgumentException("Došlo je do greške: datoteka iz koje želite čitati ne postoji!");
            }
        }

        public static Interval GetIntervalFromFile(string path)
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
                    if (values.Length != 2)
                    {
                        throw new ArgumentException("Podaci ne odgovaraju za kreiranje unimodalnog intervala. Provjerite datoteku!");
                    }

                    return new Interval(Double.Parse(values[0]), Double.Parse(values[1]));
                }
            }
            catch (IOException)
            {
                throw new ArgumentException("Došlo je do greške: datoteka iz koje želite čitati ne postoji!");
            }
        }
    }
}
