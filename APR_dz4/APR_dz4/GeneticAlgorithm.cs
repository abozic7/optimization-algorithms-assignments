using APR_dz1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APR_dz4
{
    public class GeneticAlgorithm
    {
        private static String algorithmName = "GA";
        private static Random r = new Random();
        private static int tournamentSize = 3;

        /// <summary>
        /// Finds minimum of given function using the 3-way tournament selection.
        /// </summary>
        /// <param name="f">Function used in algorithm.</param>
        /// <param name="explicitRestrictions">Array of explicit restrictions.</param>
        /// <param name="precision">Precision.</param>
        /// <param name="sizeOfPopulation">Size of population used in algorithm.</param>
        /// <param name="binaryRepresentation">Flag used for tracking whether or not user wants the individuals to be represented binary.</param>
        /// <param name="mutationProbability">Value indicating a probability that an individual will mutate.</param>
        /// <param name="noOfFunctionEvaluations">Maximum number of function evaluations.</param>
        /// <returns>Minimum of function.</returns>

        public static Individual FindMinimum(Function f, ExplicitRestriction[] explicitRestrictions, double precision, int sizeOfPopulation, bool binaryRepresentation, double mutationProbability, int noOfFunctionEvaluations)
        {
            //tournamentSize = sizeOfTournament;
            int[] lengths = CalculateCoordinateLengths(explicitRestrictions, precision);
            Individual result = null;
            Individual bestIndividual = null;
            List<Individual> population = InitializePopulation(sizeOfPopulation, explicitRestrictions, lengths);
            List<double> populationEvaluation = EvaluatePopulation(f, population);
            do
            {
                int[] indexes = GetSelectedIndividualsIndexes(population);
                List<Individual> selectedIndividuals = SelectIndividuals(population, indexes);
                int indexOfWorstIndividual = GetWorstSelectedIndividual(indexes, populationEvaluation);
                int indexInField = IndexOfWorstInChosenField(indexes, indexOfWorstIndividual);
                selectedIndividuals.RemoveAt(indexInField);
                RemoveWorstIndividualFromPopulation(population, populationEvaluation, indexOfWorstIndividual);
                Individual newIndividual = new Individual();
                if (binaryRepresentation == true)
                {
                    //for (int i = 0; i < selectedIndividuals.Count - 1; i++)
                    //{
                    //    //List<Individual> selectedTwo = new List<Individual>();
                    //    //if(i == 0)
                    //    //{
                    //    //    selectedTwo.Insert(0, selectedIndividuals[0]);
                    //    //    selectedTwo.Insert(1, selectedIndividuals[1]);
                    //    //}
                    //    //else
                    //    //{
                    //    //    selectedTwo.Insert(0, selectedIndividuals[i + 1]);
                    //    //    selectedTwo.Insert(1, newIndividual);
                    //    //}
                    //    newIndividual = OnePointCrossoverBinary(selectedIndividuals, lengths, explicitRestrictions);
                    //}
                    newIndividual = OnePointCrossoverBinary(selectedIndividuals, lengths, explicitRestrictions);
                    MutationBinary(newIndividual, mutationProbability, lengths, explicitRestrictions);
                }
                else
                {
                    //for (int i = 0; i < selectedIndividuals.Count - 1; i++)
                    //{
                    //    List<Individual> selectedTwo = new List<Individual>();
                    //    if (i == 0)
                    //    {
                    //        selectedTwo.Insert(0, selectedIndividuals[0]);
                    //        selectedTwo.Insert(1, selectedIndividuals[1]);
                    //    }
                    //    else
                    //    {
                    //        selectedTwo.Insert(0, selectedIndividuals[i + 1]);
                    //        selectedTwo.Insert(1, newIndividual);
                    //    }
                    //    newIndividual = ParentRangeCrossover(selectedIndividuals, lengths, explicitRestrictions);
                    //}
                    newIndividual = ParentRangeCrossover(selectedIndividuals, lengths, explicitRestrictions);
                    MutationFloatingPoint(newIndividual, mutationProbability, lengths, explicitRestrictions);
                }
                
                double individualEvaluation = EvaluateIndividual(f, newIndividual);
                AddIndividualToPopulation(population, newIndividual, populationEvaluation, individualEvaluation);

                bestIndividual = population.ElementAt(populationEvaluation.IndexOf(populationEvaluation.Min()));
                Console.WriteLine("The best individual:");
                bestIndividual.DecimalValuePoint.WriteMatrixInConsole();
                Console.WriteLine("f(x) = " + bestIndividual.FunctionValue);
                Console.WriteLine();
                if (f.GetCounterValue(algorithmName) % 3 == 0)
                {
                    Console.WriteLine("Number of evaluations: " + f.GetCounterValue(algorithmName));
                }
                Console.WriteLine();

                if (individualEvaluation < Math.Pow(10, -6))
                {
                    result = newIndividual;
                    break;
                }
            } while (f.GetCounterValue(algorithmName) < noOfFunctionEvaluations);

            if (result == null)
            {
                result = population.ElementAt(populationEvaluation.IndexOf(populationEvaluation.Min()));
            }
            return result;
        }

        /// <summary>
        /// Finds the index of the worst individual in selected individuals array.
        /// </summary>
        /// <param name="indexes">Array of indexes of selected individuals from population.</param>
        /// <param name="indexOfWorstIndividual">The worst individual's index in population.</param>
        /// <returns>Index of the worst individual in selected individuals array.</returns>

        public static int IndexOfWorstInChosenField(int[] indexes, int indexOfWorstIndividual)
        {
            int result = 0;
            for (int i = 0; i < indexes.Length; i++)
            {
                if (indexes[i] == indexOfWorstIndividual)
                {
                    result = i;
                }
            }

            return result;
        }

        /// <summary>
        /// Calculates maximum number of bits needed to represent each coordinate.
        /// </summary>
        /// <param name="explicitRestrictions">Array of explicit restrictions.</param>
        /// <param name="precision">Precision.</param>
        /// <returns>Array of maximum binary representation lengths.</returns>

        public static int[] CalculateCoordinateLengths(ExplicitRestriction[] explicitRestrictions, double precision)
        {
            int[] values = new int[explicitRestrictions.Length];
            for (int i = 0; i < explicitRestrictions.Length; i++)
            {
                values[i] = Convert.ToInt32((explicitRestrictions[i].Maximum - explicitRestrictions[i].Minimum) * Math.Pow(10, precision));
            }

            int[] result = new int[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                result[i] = Individual.BitsToExpressNumber(values[i]);
            }

            return result;
        }

        /// <summary>
        /// Initializes population of genetic algorithm.
        /// </summary>
        /// <param name="sizeOfPopulation">Number of individuals in population.</param>
        /// <param name="explicitRestrictions">Array of explicit restrictions.</param>
        /// <param name="lengths">Array containing maximum number of bits needed to represent each coordinate.</param>
        /// <returns>List of individuals in population.</returns>

        public static List<Individual> InitializePopulation(int sizeOfPopulation, ExplicitRestriction[] explicitRestrictions, int[] lengths)
        {
            List<Individual> population = new List<Individual>();
            
            for (int i = 0; i < sizeOfPopulation; i++)
            {
                Individual individual = new Individual(GenerateValuesForIndividual(explicitRestrictions), lengths, explicitRestrictions);
                population.Insert(i, individual);
            }

            return population;
        }

        /// <summary>
        /// Generates random coordinates for individual using explicit restrictions.
        /// </summary>
        /// <param name="explicitRestrictions">Array of explicit restrictions.</param>
        /// <returns>Coordinates of individual.</returns>

        public static Matrica GenerateValuesForIndividual(ExplicitRestriction[] explicitRestrictions)
        {
            double[] vector = new double[explicitRestrictions.Length];

            for (int i = 0; i < explicitRestrictions.Length; i++)
            {
                vector[i] = r.NextDouble() * (explicitRestrictions[i].Maximum - explicitRestrictions[i].Minimum) 
                    + explicitRestrictions[i].Minimum;
            }

            return Matrica.ArrayToVector(vector);
        }

        /// <summary>
        /// Evaluates function for each individual in population.
        /// </summary>
        /// <param name="f">Function to be evaluated.</param>
        /// <param name="population">List of individuals.</param>
        /// <returns>List of function evaluation results for each individual.</returns>

        public static List<double> EvaluatePopulation(Function f, List<Individual> population)
        {
            List<double> populationEvaluation = new List<double>();
            for (int i = 0; i < population.Count; i++)
            {
                populationEvaluation.Insert(i, EvaluateIndividual(f, population.ElementAt(i)));
            }

            return populationEvaluation;
        }

        /// <summary>
        /// Evaluates function for given individual.
        /// </summary>
        /// <param name="f">Function to be evaluated.</param>
        /// <param name="individual">Individual used for evaluating function.</param>
        /// <returns>Result of function evaluation for given individual.</returns>

        public static double EvaluateIndividual(Function f, Individual individual)
        {
            double result = f.CalculateValue(individual.DecimalValuePoint.VectorToArray());
            f.IncreaseCounterValue(algorithmName);
            individual.FunctionValue = result;
            return result;
        }

        /// <summary>
        /// Randomly selects indexes
        /// </summary>
        /// <param name="population"></param>
        /// <returns></returns>

        public static int[] GetSelectedIndividualsIndexes(List<Individual> population)
        {
            int[] indexes = new int[tournamentSize];
            int index;

            for (int i = 0; i < tournamentSize; i++)
            {
                index = r.Next(0, population.Count - 1);
                if (!indexes.Contains(index))
                {
                    indexes[i] = index;
                }
                else
                {
                    i--;
                }
            }

            return indexes;
        }

        public static List<Individual> SelectIndividuals(List<Individual> population, int[] indexes)
        {
            List<Individual> individuals = new List<Individual>();
            

            for (int i = 0; i < indexes.Length; i++)
            {
                individuals.Insert(i, population.ElementAt(indexes[i]));
            }

            return individuals;
        }

        /// <summary>
        /// Finds the worst individual from selected individuals.
        /// </summary>
        /// <param name="indexes">Array of indexes of selected individuals from population.</param>
        /// <param name="populationEvaluation">List of function evaluations of individuals in population.</param>
        /// <returns>The worst individual's index in population.</returns>

        public static int GetWorstSelectedIndividual(int[] indexes, List<double> populationEvaluation)
        {
            List<double> individualEvaluations = new List<double>();
            for (int i = 0; i < tournamentSize; i++)
            {
                individualEvaluations.Insert(i, populationEvaluation.ElementAt(indexes[i]));
            }

            return indexes.ElementAt(individualEvaluations.IndexOf(individualEvaluations.Max()));
        }

        public static void RemoveWorstIndividualFromPopulation(List<Individual> population, List<double> populationEvaluation, int index)
        {
            population.RemoveAt(index);
            populationEvaluation.RemoveAt(index);
        }

        public static Individual OnePointCrossoverBinary(List<Individual> selectedIndividuals, int[] lengths, ExplicitRestriction[] explicitRestrictions)
        {
            int index = r.Next(0, selectedIndividuals.ElementAt(0).OneLineBinary.Length - 1);
            bool[] resultBinary = new bool[selectedIndividuals.ElementAt(0).OneLineBinary.Length];
            for (int i = 0; i < resultBinary.Length; i++)
            {
                if (i <= index)
                {
                    resultBinary[i] = selectedIndividuals[0].OneLineBinary[i];
                }
                else
                {
                    resultBinary[i] = selectedIndividuals[1].OneLineBinary[i];
                }
            }
            return new Individual(resultBinary, lengths, explicitRestrictions);
        }

        public static Individual UniformCrossover(List<Individual> selectedIndividuals, int[] lengths, ExplicitRestriction[] explicitRestrictions)
        {
            bool[] resultBinary = new bool[selectedIndividuals.ElementAt(0).OneLineBinary.Length];

            for (int i = 0; i < resultBinary.Length; i++)
            {
                if(r.NextDouble() < 0.5)
                {
                    resultBinary[i] = selectedIndividuals[0].OneLineBinary[i];
                }
                else
                {
                    resultBinary[i] = selectedIndividuals[1].OneLineBinary[i];
                }
            }

            return new Individual(resultBinary, lengths, explicitRestrictions);
        }

        public static Individual ParentRangeCrossover(List<Individual> selectedIndividuals, int[] lengths, ExplicitRestriction[] explicitRestrictions)
        {
            double[] values = new double[explicitRestrictions.Length];
            for (int i = 0; i < values.Length; i++)
            {
                if (selectedIndividuals[0].DecimalValuePoint.LoadedMatrix[i][0] >= selectedIndividuals[1].DecimalValuePoint.LoadedMatrix[i][0])
                {
                    values[i] = r.NextDouble() * (selectedIndividuals[0].DecimalValuePoint.LoadedMatrix[i][0]
                        - selectedIndividuals[1].DecimalValuePoint.LoadedMatrix[i][0])
                        + selectedIndividuals[1].DecimalValuePoint.LoadedMatrix[i][0];
                }
                else
                {
                    values[i] = r.NextDouble() * (selectedIndividuals[1].DecimalValuePoint.LoadedMatrix[i][0]
                        - selectedIndividuals[0].DecimalValuePoint.LoadedMatrix[i][0])
                        + selectedIndividuals[0].DecimalValuePoint.LoadedMatrix[i][0];

                }
            }
            return new Individual(Matrica.ArrayToVector(values), lengths, explicitRestrictions);
        }

        public static Individual OnePointCrossoverFloatingPoint(List<Individual> selectedIndividuals, int[] lengths, ExplicitRestriction[] explicitRestrictions)
        {
            int index = r.Next(0, explicitRestrictions.Length - 1);
            double[] values = new double[explicitRestrictions.Length];

            for (int i = 0; i < values.Length; i++)
            {
                if (i <= index)
                {
                    values[i] = selectedIndividuals[0].DecimalValuePoint.LoadedMatrix[i][0];
                }
                else
                {
                    values[i] = selectedIndividuals[1].DecimalValuePoint.LoadedMatrix[i][0];

                }
            }
            return new Individual(Matrica.ArrayToVector(values), lengths, explicitRestrictions);
        }

        public static void MutationBinary(Individual individual, double mutationProbability, int[] lengths, ExplicitRestriction[] explicitRestrictions)
        {
            for (int i = 0; i < individual.OneLineBinary.Length; i++)
            {
                if(r.NextDouble() < mutationProbability)
                {
                    individual.OneLineBinary[i] = !individual.OneLineBinary[i];
                }
            }

            individual.ChangeIndividualBinary(lengths, explicitRestrictions);
        }

        public static void MutationFloatingPoint(Individual individual, double mutationProbability, int[] lengths, ExplicitRestriction[] explicitRestrictions)
        {
            for (int i = 0; i < individual.DecimalValuePoint.NoOfRows; i++)
            {
                if (r.NextDouble() < mutationProbability)
                {
                    individual.DecimalValuePoint.LoadedMatrix[i][0] = r.NextDouble() 
                        * (explicitRestrictions[i].Maximum - explicitRestrictions[i].Minimum) 
                        + explicitRestrictions[i].Minimum;
                }
            }

            individual.ChangeIndividualFloatingPoint(lengths, explicitRestrictions);
        }

        public static void AddIndividualToPopulation(List<Individual> population, Individual individual, List<double> populationEvaluation, double individualEvaluation)
        {
            population.Insert(population.Count, individual);
            populationEvaluation.Insert(populationEvaluation.Count, individualEvaluation);
        }
    }
}
