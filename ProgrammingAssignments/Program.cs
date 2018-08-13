using System;
using System.Linq;

namespace ProgrammingAssignments
{
    class Program
    {
        static void Main(string[] args)
        {
            StressTest(5, 10);
        }

        static void Test()
        {
            //Console.Write("Enter dimension of array: ");
            int n = int.Parse(Console.ReadLine());
            long[] array = new long[n];

            //Console.Write("Enter elements of array: ");
            string[] strArray = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(strArray[i]);
            }

            long product = MaxPairwiseProductFast(array);
            Console.WriteLine(product);
        }

        static void StressTest(int topOfArrayDimension, int topOfArrayElement)
        {
            while (true)
            {
                int n = (new Random()).Next(2, topOfArrayDimension);
                long[] array = new long[n];

                for (int i = 0; i < n; i++)
                {
                    array[i] = (new Random()).Next(2, topOfArrayElement);
                }

                Console.WriteLine("Elems of array: {0}", string.Join(", ", array));
                long naiveResult = MaxPairwiseProductNaive(array);
                long fastResult = MaxPairwiseProductFast(array);

                if (naiveResult == fastResult)
                {
                    Console.WriteLine("OK");
                }
                else
                {
                    Console.WriteLine("Wrong answer: {0}, {1}", naiveResult, fastResult);
                    break;
                }
            }
        }

        static long MaxPairwiseProductNaive(long[] A)
        {
            int n = A.Length;
            long product = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    product = Math.Max(product, A[i] * A[j]);
                }
            }

            return product;
        }

        static long MaxPairwiseProductFast(long[] A)
        {
            int n = A.Length;
            int index1 = 0;

            for (int i = 1; i < n; i++)
            {
                if (A[i] > A[index1])
                {
                    index1 = i;
                }
            }
            int index2 = 0;

            if (index1 == 0)
            {
                index2 = 1;
            }

            for (int i = 1; i < n; i++)
            {
                if (A[i] != A[index1] & A[i] > A[index2])
                {
                    index2 = i;
                }
            }

            return A[index1] * A[index2];
        }
    }
}