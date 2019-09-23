using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz1
{
    public class Matrica
    {
        public int NoOfRows { get; set; }
        public int NoOfColumns { get; set; }
        public SortedDictionary<int, List<double>> LoadedMatrix { get; set; }

        /// <summary>
        /// A constructor used to generate a new matrix.
        /// </summary>

        public Matrica()
        {
            LoadedMatrix = new SortedDictionary<int, List<double>>();
        }

        /// <summary>
        /// A constructor used to generate a new matrix from a file.
        /// </summary>
        /// <param name="path">Path to the file containing matrix.</param>

        public Matrica(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(File.Open(path, FileMode.Open)))
                {
                    LoadedMatrix = new SortedDictionary<int, List<double>>();
                    string line;
                    int i = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        line.Trim();
                        string[] elements = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                        List<double> row = new List<double>();
                        for (int j = 0; j < elements.Length; j++)
                        {
                            row.Insert(j, Double.Parse(elements[j], CultureInfo.InvariantCulture));
                        }
                        LoadedMatrix.Add(i, row);
                        i++;
                    }

                    NoOfRows = LoadedMatrix.Count;
                    NoOfColumns = LoadedMatrix[0].Count;
                }
            }
            catch (IOException)
            {
                throw new ArgumentException("Došlo je do greške: datoteka iz koje želite čitati ne postoji!");
            }

        }

        /// <summary>
        /// Checks if two matrices are equal.
        /// </summary>
        /// <param name="matrix">One of the matrices used in comparing.</param>

        public void Equals(Matrica matrix)
        {
            this.LoadedMatrix = new SortedDictionary<int, List<double>>();
            this.NoOfRows = matrix.NoOfRows;
            this.NoOfColumns = matrix.NoOfColumns;
            for (int i = 0; i < this.NoOfRows; i++)
            {
                List<double> row = new List<double>();
                for (int j = 0; j < this.NoOfColumns; j++)
                {
                    row.Insert(j, matrix.LoadedMatrix[i][j]);
                }
                this.LoadedMatrix.Add(i, row);
            }
        }

        public double[] VectorToArray()
        {
            if(this.NoOfColumns != 1)
            {
                throw new ArgumentException("Matrica koju ste poslali nije vektor!!");
            }

            double[] result = new double[this.NoOfRows];
            for (int i = 0; i < this.NoOfRows; i++)
            {
                result[i] = this.LoadedMatrix[i][0];
            }

            return result;
        }

        public static Matrica ArrayToVector(double[] array)
        {
            Matrica result = new Matrica();
            result.NoOfRows = array.Length;
            result.NoOfColumns = 1;

            for (int i = 0; i < array.Length; i++)
            {
                List<double> row = new List<double>();
                row.Insert(0, array[i]);
                result.LoadedMatrix.Add(i, row);
            }

            return result;
        }

        /// <summary>
        /// Writes a matrix in file.
        /// </summary>
        /// <param name="path">Path name to file.</param>

        public void WriteMatrixInFile(string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(File.Open(path, FileMode.OpenOrCreate)))
                {
                    foreach (var key in this.LoadedMatrix.Keys)
                    {
                        string row = "";
                        foreach (var value in this.LoadedMatrix[key])
                        {
                            row += value + " ";
                        }
                        row.Trim();
                        sw.WriteLine(row);
                    }
                }
            }
            catch (IOException)
            {
                throw new ArgumentException("Došlo je do greške: putanja koju ste predali ne postoji!");
            }
        }

        /// <summary>
        /// Writes a matrix in console.
        /// </summary>

        public void WriteMatrixInConsole()
        {
            foreach (var key in this.LoadedMatrix.Keys)
            {
                string row = "";
                foreach (var value in this.LoadedMatrix[key])
                {
                    row += value + " ";
                }
                row.Trim();
                Console.WriteLine(row);
            }
        }

        /// <summary>
        /// Gets the element in given row and column in the matrix.
        /// </summary>
        /// <param name="row">Row of the wanted element.</param>
        /// <param name="column">Column of the wanted element.</param>
        /// <returns>Returns the element.</returns>

        public double GetElementOfMatrix(int row, int column)
        {
            if (row < NoOfRows && column < NoOfColumns)
            {
                return this.LoadedMatrix[row][column];
            }
            else
            {
                throw new ArgumentException("Došlo je do greške: redak ili stupac kojeg ste zadali ne postoji! Provjerite podatke i pokušajte ponovno.");
            }
        }

        /// <summary>
        /// Sets element in given row and column in the matrix.
        /// </summary>
        /// <param name="row">Row of the element.</param>
        /// <param name="column">Column of the element.</param>
        /// <param name="newValue">New value that is being set.</param>

        public void SetElementOfMatrix(int row, int column, double newValue)
        {
            if (row < NoOfRows && column < NoOfColumns)
            {
                this.LoadedMatrix[row][column] = newValue;
            }
            else
            {
                throw new ArgumentException("Došlo je do greške: redak ili stupac kojeg ste zadali ne postoji! Provjerite podatke i pokušajte ponovno.");
            }
        }

        /// <summary>
        /// Adds two matrices.
        /// </summary>
        /// <param name="matrix">A matrix being added to another matrix.</param>
        /// <returns>Result of addition of matrices.</returns>

        public Matrica AddMatrices(Matrica matrix)
        {
            Matrica result = new Matrica();

            if (this.NoOfRows != matrix.NoOfRows || this.NoOfColumns != matrix.NoOfColumns)
            {
                throw new ArgumentException("Matrice koje želite zbrojiti nisu odgovarajućih dimenzija za ovu operaciju!");
            }

            result.NoOfRows = this.NoOfRows;
            result.NoOfColumns = this.NoOfColumns;

            for (int i = 0; i < this.NoOfRows; i++)
            {
                List<double> row = new List<double>();
                for (int j = 0; j < this.NoOfColumns; j++)
                {
                    row.Insert(j, this.LoadedMatrix[i][j] + matrix.LoadedMatrix[i][j]);
                }
                result.LoadedMatrix.Add(i, row);
            }

            return result;
        }

        /// <summary>
        /// Subtracts two matrices.
        /// </summary>
        /// <param name="matrix">A matrix being subtracted from another matrix.</param>
        /// <returns>Result of subtraction of matrices.</returns>

        public Matrica SubtractMatrices(Matrica matrix)
        {
            Matrica result = new Matrica();

            if (this.NoOfRows != matrix.NoOfRows || this.NoOfColumns != matrix.NoOfColumns)
            {
                throw new ArgumentException("Matrice koje želite oduzeti nisu odgovarajućih dimenzija za ovu operaciju!");
            }

            result.NoOfRows = this.NoOfRows;
            result.NoOfColumns = this.NoOfColumns;

            for (int i = 0; i < this.NoOfRows; i++)
            {
                List<double> row = new List<double>();
                for (int j = 0; j < this.NoOfColumns; j++)
                {
                    row.Insert(j, this.LoadedMatrix[i][j] - matrix.LoadedMatrix[i][j]);
                }
                result.LoadedMatrix.Add(i, row);
            }

            return result;
        }

        /// <summary>
        /// Multiplies two matrices.
        /// </summary>
        /// <param name="matrix">A matrix being multiplied with another matrix.</param>
        /// <returns>Result of multiplications of matrices.</returns>

        public Matrica MultiplyMatrices(Matrica matrix)
        {
            Matrica result = new Matrica();

            if (this.NoOfColumns != matrix.NoOfRows)
            {
                throw new ArgumentException("Matrice koje želite pomnožiti nisu odgovarajućih dimenzija za ovu operaciju!");
            }

            result.NoOfRows = this.NoOfRows;
            result.NoOfColumns = matrix.NoOfColumns;

            for (int i = 0; i < this.NoOfRows; i++)
            {
                List<double> row = new List<double>();
                for (int j = 0; j < matrix.NoOfColumns; j++)
                {
                    double element = 0;
                    for (int k = 0; k < this.NoOfColumns; k++)
                    {
                        element += this.LoadedMatrix[i][k] * matrix.LoadedMatrix[k][j];
                    }
                    row.Insert(j, element);
                }
                result.LoadedMatrix.Add(i, row);
            }

            return result;
        }

        /// <summary>
        /// Transposes the matrix.
        /// </summary>
        /// <returns>Transposed matrix.</returns>

        public Matrica TransposeMatrix()
        {
            Matrica result = new Matrica();

            result.NoOfRows = this.NoOfColumns;
            result.NoOfColumns = this.NoOfRows;

            for (int i = 0; i < this.NoOfColumns; i++)
            {
                List<double> row = new List<double>();
                for (int j = 0; j < this.NoOfRows; j++)
                {
                    row.Insert(j, this.LoadedMatrix[j][i]);
                }
                result.LoadedMatrix.Add(i, row);
            }

            return result;
        }

        /// <summary>
        /// Adds matrix B to matrix A and saves value to matrix A.
        /// </summary>
        /// <param name="matrix">Matrix being added to another matrix.</param>

        public void AddValue(Matrica matrix)
        {
            if (this.NoOfRows != matrix.NoOfRows || this.NoOfColumns != matrix.NoOfColumns)
            {
                throw new ArgumentException("Matrice koje želite zbrojiti nisu odgovarajućih dimenzija za ovu operaciju!");
            }

            for (int i = 0; i < this.NoOfRows; i++)
            {
                for (int j = 0; j < this.NoOfColumns; j++)
                {
                    this.LoadedMatrix[i][j] += matrix.LoadedMatrix[i][j];
                }
            }
        }

        /// <summary>
        /// Subtracts matrix B to matrix A and saves value to matrix A.
        /// </summary>
        /// <param name="matrix">Matrix being subtracted from another matrix.</param>

        public void SubtractValue(Matrica matrix)
        {
            if (this.NoOfRows != matrix.NoOfRows || this.NoOfColumns != matrix.NoOfColumns)
            {
                throw new ArgumentException("Matrice koje želite oduzeti nisu odgovarajućih dimenzija za ovu operaciju!");
            }

            for (int i = 0; i < this.NoOfRows; i++)
            {
                for (int j = 0; j < this.NoOfColumns; j++)
                {
                    this.LoadedMatrix[i][j] -= matrix.LoadedMatrix[i][j];
                }
            }
        }

        /// <summary>
        /// Multiplies a matrix by scalar.
        /// </summary>
        /// <param name="scalar">Scalar used in multiplying.</param>

        public void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < this.NoOfRows; i++)
            {
                for (int j = 0; j < this.NoOfColumns; j++)
                {
                    this.LoadedMatrix[i][j] *= scalar;
                }
            }
        }

        public bool IsLessThanOrEqual(Matrica epsilon)
        {
            for (int i = 0; i < this.NoOfRows; i++)
            {
                if (Math.Abs(this.LoadedMatrix[i][0]) > epsilon.LoadedMatrix[i][0]) return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if two matrices are equal.
        /// </summary>
        /// <param name="matrix">Matrix used in comparing.</param>
        /// <param name="epsilon">Constant used in comparing two values.</param>
        /// <returns>Returns true if equal, false if not equal.</returns>

        public bool IsEqual(Matrica matrix, double epsilon)
        {
            if (this.NoOfRows != matrix.NoOfRows || this.NoOfColumns != matrix.NoOfColumns)
            {
                return false;
            }

            for (int i = 0; i < this.NoOfRows; i++)
            {
                for (int j = 0; j < this.NoOfColumns; j++)
                {
                    if (Math.Abs(this.LoadedMatrix[i][j] - matrix.LoadedMatrix[i][j]) > epsilon)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Solves forward substitution.
        /// </summary>
        /// <param name="LU">Matrix containing both L and U matrices obtained from decomposition.</param>
        /// <param name="b">Vector containing values from the right side of system of linear equations.</param>
        /// <returns>Vector y.</returns>

        public static Matrica ForwardSubstitution(Matrica LU, Matrica b)
        {
            if (LU.NoOfRows != LU.NoOfColumns || LU.NoOfRows != b.NoOfRows)
            {
                throw new ArgumentException("Dimenzije matrica nisu odgovarajuće! Provjerite i pokušajte ponovno.");
            }

            for (int i = 0; i < b.NoOfRows - 1; i++)
            {
                for (int j = i + 1; j < b.NoOfRows; j++)
                {
                    b.LoadedMatrix[j][0] -= LU.LoadedMatrix[j][i] * b.LoadedMatrix[i][0];
                }
            }

            return b;
        }

        /// <summary>
        /// Solves backward substitution.
        /// </summary>
        /// <param name="LU">Matrix containing both L and U matrices obtained from decomposition.</param>
        /// <param name="b">Vector containing values from the right side of system of linear equations.</param>
        /// <param name="epsilon">Constant used for checking if we are dividing value by zero.</param>
        /// <returns>Vector x (result of solving system of linear equations).</returns>

        public static Matrica BackwardSubstitution(Matrica LU, Matrica b, double epsilon)
        {
            if (LU.NoOfRows != LU.NoOfColumns || LU.NoOfRows != b.NoOfRows)
            {
                throw new ArgumentException("Dimenzije matrica nisu odgovarajuće! Provjerite i pokušajte ponovno.");
            }

            for (int i = b.NoOfRows - 1; i >= 0; i--)
            {
                if (Math.Abs(LU.LoadedMatrix[i][i]) <= epsilon)
                {
                    throw new DivideByZeroException("Nije moguće dijeliti s nulom!!");
                } 
                b.LoadedMatrix[i][0] /= LU.LoadedMatrix[i][i];
                for (int j = 0; j <= i - 1; j++)
                {
                    b.LoadedMatrix[j][0] -= LU.LoadedMatrix[j][i] * b.LoadedMatrix[i][0];
                }
            }

            return b;
        }

        /// <summary>
        /// Executes LU decomposition.
        /// </summary>
        /// <param name="epsilon">Constant used for checking if the pivot element is equal to zero.</param>

        public void LUDecomposition(double epsilon)
        {
            if (this.NoOfRows != this.NoOfColumns)
            {
                throw new ArgumentException("Ne možete izvršiti LU dekompoziciju nad matricom koja nije kvadratna!");
            }

            for (int i = 0; i < this.NoOfRows - 1; i++)
            {
                for (int j = i + 1; j < this.NoOfColumns; j++)
                {
                    if (Math.Abs(this.LoadedMatrix[i][i]) <= epsilon)
                    {
                        throw new DivideByZeroException("Stožerni element je manji od ili jednak vrijednosti " + epsilon + ". Riješite sustav pomoću LUP dekompozicije.");
                    }
                    this.LoadedMatrix[j][i] /= this.LoadedMatrix[i][i];

                    for (int k = i + 1; k < this.NoOfRows; k++)
                    {
                        this.LoadedMatrix[j][k] -= this.LoadedMatrix[j][i] * this.LoadedMatrix[i][k];
                    }
                }
            }
        }

        /// <summary>
        /// Gets L matrix from L/U matrix.
        /// </summary>
        /// <returns>Matrix L.</returns>

        public Matrica GetLMatrixFromLU()
        {
            Matrica matrixL = new Matrica();
            matrixL.NoOfRows = this.NoOfRows;
            matrixL.NoOfColumns = this.NoOfColumns;

            for (int i = 0; i < this.NoOfRows; i++)
            {
                List<double> row = new List<double>();
                for (int j = 0; j < this.NoOfColumns; j++)
                {
                    if (j < i)
                    {
                        row.Insert(j, this.LoadedMatrix[i][j]);
                    }
                    else if (j == i)
                    {
                        row.Insert(i, 1);
                    }
                    else
                    {
                        row.Insert(j, 0);
                    }
                }
                matrixL.LoadedMatrix.Add(i, row);
            }

            return matrixL;
        }

        /// <summary>
        /// Gets U matrix from L/U matrix.
        /// </summary>
        /// <returns>Matrix U.</returns>

        public Matrica GetUMatrixFromLU()
        {
            Matrica matrixU = new Matrica();
            matrixU.NoOfRows = this.NoOfRows;
            matrixU.NoOfColumns = this.NoOfColumns;

            for (int i = 0; i < this.NoOfRows; i++)
            {
                List<double> row = new List<double>();
                for (int j = 0; j < this.NoOfColumns; j++)
                {
                    if (j < i)
                    {
                        row.Insert(j, 0);
                    }
                    else
                    {
                        row.Insert(j, this.LoadedMatrix[i][j]);
                    }
                }
                matrixU.LoadedMatrix.Add(i, row);
            }

            return matrixU;
        }

        /// <summary>
        /// Generates an identity matrix.
        /// </summary>
        /// <param name="noOfRows">Number of rows/columns in identity matrix.</param>
        /// <returns>Identity matrix.</returns>

        public static Matrica GenerateIdentityMatrix(int noOfRows)
        {
            Matrica identityMatrix = new Matrica();
            identityMatrix.NoOfRows = noOfRows;
            identityMatrix.NoOfColumns = noOfRows;

            for (int i = 0; i < noOfRows; i++)
            {
                List<double> row = new List<double>();
                for (int j = 0; j < noOfRows; j++)
                {
                    if (i == j)
                    {
                        row.Insert(j, 1);
                    }
                    else
                    {
                        row.Insert(j, 0);
                    }
                }
                identityMatrix.LoadedMatrix.Add(i, row);
            }

            return identityMatrix;
        }

        /// <summary>
        /// Copies values from a given row to a list.
        /// </summary>
        /// <param name="row">Row given to copy values.</param>
        /// <returns>List of copied values.</returns>

        public static List<double> CopyValuesFromRow(List<double> row)
        {
            List<double> result = new List<double>();

            for (int i = 0; i < row.Count; i++)
            {
                result.Insert(i, row[i]);
            }

            return result;
        }

        /// <summary>
        /// Switches two rows in a matrix.
        /// </summary>
        /// <param name="row1">Index of first row to be switched.</param>
        /// <param name="row2">Index of second row to be switched.</param>

        public void SwitchRows(int row1, int row2)
        {
            if (row1 >= this.NoOfRows || row2 >= this.NoOfRows)
            {
                throw new ArgumentException("Red(ovi) koje želite zamijeniti ne postoje u Vašoj matrici.");
            }

            if (row1 == row2)
            {
                return;
            }

            List<double> rowValues1 = CopyValuesFromRow(this.LoadedMatrix[row1]);
            List<double> rowValues2 = CopyValuesFromRow(this.LoadedMatrix[row2]);
            this.LoadedMatrix.Remove(row1);
            this.LoadedMatrix.Remove(row2);
            this.LoadedMatrix.Add(row1, rowValues2);
            this.LoadedMatrix.Add(row2, rowValues1);
        }

        /// <summary>
        /// Chooses pivot element in a column from the original pivot element to the end of the column.
        /// </summary>
        /// <param name="row">Row of the original pivot element.</param>
        /// <param name="column">Column of the original pivot element.</param>
        /// <returns>Row of the new pivot element.</returns>

        public int ChoosePivotElement(int row, int column)
        {
            int pivotElementRow = row;

            for (int i = row + 1; i < this.NoOfRows; i++)
            {
                if (Math.Abs(this.LoadedMatrix[i][column]) > Math.Abs(this.LoadedMatrix[pivotElementRow][column]))
                {
                    pivotElementRow = i;
                }
            }

            return pivotElementRow;
        }

        /// <summary>
        /// Executes LUP decomposition.
        /// </summary>
        /// <param name="epsilon">Constant used for checking if the pivot element is equal to zero.</param>
        /// <param name="b">Vector containing values from the right side of system of linear equations.</param>
        /// <returns>Permutated identity matrix P.</returns>

        public Matrica LUPDecomposition(double epsilon, Matrica b)
        {
            if (this.NoOfRows != this.NoOfColumns)
            {
                throw new ArgumentException("Ne možete izvršiti LU dekompoziciju nad matricom koja nije kvadratna!");
            }

            Matrica identityMatrixP = GenerateIdentityMatrix(this.NoOfRows);
            int pivotElementRow;

            for (int i = 0; i < this.NoOfColumns - 1; i++)
            {
                pivotElementRow = this.ChoosePivotElement(i, i);
                if (Math.Abs(this.LoadedMatrix[pivotElementRow][i]) <= epsilon)
                {
                    throw new DivideByZeroException("Stožerni element je manji od ili jednak vrijednosti " + epsilon + ". Nije moguće riješiti ovaj sustav pomoću LUP dekompozicije.");
                }
                identityMatrixP.SwitchRows(i, pivotElementRow);
                this.SwitchRows(i, pivotElementRow);
                b.SwitchRows(i, pivotElementRow);

                for (int j = i + 1; j < this.NoOfRows; j++)
                {
                    if (Math.Abs(this.LoadedMatrix[i][i]) <= epsilon)
                    {
                        throw new DivideByZeroException("Nije moguće dijeliti s nulom!!");
                    }
                    this.LoadedMatrix[j][i] /= this.LoadedMatrix[i][i];
                    for (int k = i + 1; k < this.NoOfColumns; k++)
                    {
                        this.LoadedMatrix[j][k] -= this.LoadedMatrix[j][i] * this.LoadedMatrix[i][k];
                    }
                }
            }

            return identityMatrixP;
        }

        /// <summary>
        /// Solves system of linear equations using LU/LUP decomposition, forward and backward substitution.
        /// </summary>
        /// <param name="A">Values on the left side of system of linear equations which are multiplied by unknown vector x.</param>
        /// <param name="b">Vector containing values from the right side of system of linear equations.</param>
        /// <param name="epsilon">Constant used for checking if we are dividing value by zero.</param>
        /// <returns>Vector x (result of solving system of linear equations).</returns>

        public static Matrica SolveSystemOfLinearEquations(Matrica A, Matrica b, double epsilon)
        {
            Console.WriteLine("Matrica A:");
            Console.WriteLine("============");
            A.WriteMatrixInConsole();
            Console.WriteLine();

            Console.WriteLine("Vektor b:");
            Console.WriteLine("===========");
            b.WriteMatrixInConsole();
            Console.WriteLine();

            Matrica copyOfA = new Matrica();
            copyOfA.Equals(A);
            Matrica copyOfb = new Matrica();
            copyOfb.Equals(b);

            try
            {
                A.LUDecomposition(epsilon);

                Console.WriteLine("Matrica L:");
                Console.WriteLine("============");
                Matrica L = A.GetLMatrixFromLU();
                L.WriteMatrixInConsole();
                Console.WriteLine();

                Console.WriteLine("Matrica U:");
                Console.WriteLine("============");
                Matrica U = A.GetUMatrixFromLU();
                U.WriteMatrixInConsole();
                Console.WriteLine();

                Matrica y = ForwardSubstitution(A, b);

                Console.WriteLine("Vektor y:");
                Console.WriteLine("===========");
                y.WriteMatrixInConsole();
                Console.WriteLine();

                Matrica x = BackwardSubstitution(A, y, epsilon);

                Console.WriteLine("Vektor x:");
                Console.WriteLine("===========");
                x.WriteMatrixInConsole();
                Console.WriteLine();

                return x;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Nije moguće riješiti ovaj sustav LU dekompozicijom. Izvođenje LUP dekompozicije...");
                A = copyOfA;
                b = copyOfb;
                Matrica P = A.LUPDecomposition(epsilon, b);
                Console.WriteLine("Matrica P:");
                Console.WriteLine("============");
                P.WriteMatrixInConsole();
                Console.WriteLine();

                Console.WriteLine("Matrica L:");
                Console.WriteLine("============");
                Matrica L = A.GetLMatrixFromLU();
                L.WriteMatrixInConsole();
                Console.WriteLine();

                Console.WriteLine("Matrica U:");
                Console.WriteLine("============");
                Matrica U = A.GetUMatrixFromLU();
                U.WriteMatrixInConsole();
                Console.WriteLine();

                Matrica y = ForwardSubstitution(A, b);

                Console.WriteLine("Vektor y:");
                Console.WriteLine("===========");
                y.WriteMatrixInConsole();
                Console.WriteLine();

                Matrica x = BackwardSubstitution(A, y, epsilon);

                Console.WriteLine("Vektor x:");
                Console.WriteLine("===========");
                x.WriteMatrixInConsole();
                Console.WriteLine();

                return x;
            }
        }
    }
}
