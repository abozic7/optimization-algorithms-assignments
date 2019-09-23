using APR_dz1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz4
{
    public class Individual
    {
        public Matrica DecimalValuePoint { get; set; }
        public bool[][] BinaryValuePoint { get; set; }
        public bool[] OneLineBinary { get; set; }
        public double FunctionValue { get; set; }

        public Individual()
        {

        }

        public Individual(Matrica point, int[] lengths, ExplicitRestriction[] explicitRestrictions)
        {
            DecimalValuePoint = point;
            BinaryValuePoint = CreateBinary2DArray(DecimalValuePoint, lengths, explicitRestrictions);
            OneLineBinary = GetOneLineBinary(BinaryValuePoint);
        }

        public Individual(bool[] binaryArray, int[] lengths, ExplicitRestriction[] explicitRestrictions)
        {
            OneLineBinary = binaryArray;
            BinaryValuePoint = GetBinaryValuePoint(binaryArray, lengths);

            int[] intValues = new int[BinaryValuePoint.Length];
            for (int i = 0; i < BinaryValuePoint.Length; i++)
            {
                intValues[i] = BinaryToDecimal(BinaryValuePoint[i]);
            }

            int n = 0;
            for (int i = 0; i < lengths.Length; i++)
            {
                n += lengths[i];
            }

            double[] doubleValues = new double[intValues.Length];
            for (int i = 0; i < intValues.Length; i++)
            {
                doubleValues[i] = IntToDoubleValue(intValues[i], explicitRestrictions[i], lengths[i]);
            }

            DecimalValuePoint = Matrica.ArrayToVector(doubleValues);
        }

        public static bool[][] GetBinaryValuePoint(bool[] binaryArray, int[] lengths)
        {
            bool[][] result = new bool[lengths.Length][];
            int k = 0;
            for (int i = 0; i < lengths.Length; i++)
            {
                bool[] binaryValue = new bool[lengths[i]];
                for (int j = 0; j < lengths[i]; j++)
                {
                    binaryValue[j] = binaryArray[k];
                    k++;
                }
                result[i] = binaryValue;
            }

            return result;
        }

        public static bool[] GetOneLineBinary(bool[][] binaryValuePoint)
        {
            int length = 0;
            for (int i = 0; i < binaryValuePoint.Length; i++)
            {
                length += binaryValuePoint[i].Length;
            }

            bool[] result = new bool[length];
            int index = 0;
            for (int i = 0; i < binaryValuePoint.Length; i++)
            {
                binaryValuePoint[i].CopyTo(result, index);
                index += binaryValuePoint[i].Length;
            }

            return result;
        }

        public static double IntToDoubleValue(int value, ExplicitRestriction explicitRestriction, int n)
        {
            return ((value * (explicitRestriction.Maximum - explicitRestriction.Minimum)) / (Math.Pow(2, n) - 1)) + explicitRestriction.Minimum;
        }

        public static int DoubleToIntValue(double value, int n, ExplicitRestriction explicitRestriction)
        {
            return (int)Math.Round(((value - explicitRestriction.Minimum)
                / (explicitRestriction.Maximum - explicitRestriction.Minimum)) * (Math.Pow(2, n) - 1),
                MidpointRounding.AwayFromZero);
        }

        public static int[] DoubleToIntArray(double[] values, int[] lengths, ExplicitRestriction[] explicitRestrictions)
        {
            int[] result = new int[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                result[i] = DoubleToIntValue(values[i], lengths[i], explicitRestrictions[i]);
            }

            return result;
        }

        public static bool[][] CreateBinary2DArray(Matrica decimalValuePoint, int[] lengths, ExplicitRestriction[] explicitRestrictions)
        {
            int n = 0;
            for (int i = 0; i < lengths.Length; i++)
            {
                n += lengths[i];
            }
            int[] decimalValues = DoubleToIntArray(decimalValuePoint.VectorToArray(), lengths, explicitRestrictions);
            bool[][] result = new bool[decimalValues.Length][];

            for (int i = 0; i < decimalValues.Length; i++)
            {
                bool[] binaryValue = DecimalToBinary(decimalValues[i], lengths[i]);
                result[i] = binaryValue;
            }

            return result;
        }

        public static bool[] DecimalToBinary(int value, int noOfBits)
        {
            bool[] bits = new bool[noOfBits];

            for (int i = noOfBits - 1; i >= 0; i--)
            {
                if (value % 2 == 1)
                {
                    bits[i] = true;
                }
                value /= 2;
            }

            return bits;
        }

        public static int BinaryToDecimal(bool[] bits)
        {
            double number = 0;
            for (int i = bits.Length - 1, j = 0; i >= 0; i--, j++)
            {
                if (bits[i] == true)
                {
                    number += Math.Pow(2, j);
                }
            }
            return (int)number;
        }

        public static int BitsToExpressNumber(int biggestNumber)
        {
            for (int i = 1; ; i++)
            {
                if (Math.Pow(2, i) > biggestNumber)
                {
                    return i;
                }
            }
        }

        public void ChangeIndividualBinary(int[] lengths, ExplicitRestriction[] explicitRestrictions)
        {
            BinaryValuePoint = GetBinaryValuePoint(this.OneLineBinary, lengths);

            int[] intValues = new int[BinaryValuePoint.Length];
            for (int i = 0; i < BinaryValuePoint.Length; i++)
            {
                intValues[i] = BinaryToDecimal(BinaryValuePoint[i]);
            }

            int n = 0;
            for (int i = 0; i < lengths.Length; i++)
            {
                n += lengths[i];
            }

            double[] doubleValues = new double[intValues.Length];
            for (int i = 0; i < intValues.Length; i++)
            {
                doubleValues[i] = IntToDoubleValue(intValues[i], explicitRestrictions[i], lengths[i]);
            }

            DecimalValuePoint = Matrica.ArrayToVector(doubleValues);
        }

        public void ChangeIndividualFloatingPoint(int[] lengths, ExplicitRestriction[] explicitRestrictions)
        {
            BinaryValuePoint = CreateBinary2DArray(DecimalValuePoint, lengths, explicitRestrictions);
            OneLineBinary = GetOneLineBinary(BinaryValuePoint);
        }
    }
}
