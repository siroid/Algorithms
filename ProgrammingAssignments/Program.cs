using System;

namespace ProgrammingAssignments
{
    class Program
    {
        static void Main(string[] args)
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