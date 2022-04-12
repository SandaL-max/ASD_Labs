using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace Lab03
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[,] A = { { 1, 2 }, { 3, 4 } };

            //int[,] B = { { 1, 2 }, { 3, 4 } };

            //int[,] C = Shtrassen2x2Matrix(A, B);
            //for (int i = 0; i < 2; i++)
            //{
            //    for (int j = 0; j < 2; j++)
            //    {
            //        Console.Write(C[i, j].ToString() + " ");
            //    }
            //    Console.WriteLine();
            //}

            //int[,] A = { { 2 }, { 1 }, { 2 }, { 3 }, { 4 }, { 1 } };
            //int[,] B = { { 5, 3, 7, 4, 1, 2, 6, 1, 3 } };
            int[] A = { 1, 2, 3, 4, 5};
            int[] B = { 1, 2, 3, 4, 5};
            int[,] M = new int[A.Length, B.Length];
            int BlockLength = 2, BlockHeight = 2;
            for (int ii = 0; ii < A.Length; ii += BlockHeight)
            {
                for (int jj = 0; jj < B.Length; jj += BlockLength)
                {
                    for (int i = ii; i < ii + BlockHeight; i++)
                    {
                        for (int j = jj; j < jj + BlockLength; j++)
                        {
                            if (i >= A.Length || j >= B.Length) 
                                continue;
                            M[i, j] = A[i] * B[j];
                        }
                    }
                }
            }

            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < B.Length; j++)
                {
                    
                    Console.Write($"{M[i, j].ToString().PadLeft(3)} ");
                }
                Console.WriteLine();
            }
        }

        static int[,] Shtrassen2x2Matrix(int[,] A, int[,] B)
        {
            int x1 = (A[0, 0] + A[1, 1]) * (B[0, 0] + B[1, 1]);
            int x2 = (A[1, 0] + A[1, 1]) * B[0, 0];
            int x3 = A[0, 0] * (B[0, 1] - B[1, 1]);
            int x4 = A[1, 1] * (B[1, 0] - B[0, 0]);
            int x5 = (A[0, 0] + A[0, 1]) * B[1, 1];
            int x6 = (A[1, 0] - A[0, 0]) * (B[0, 0] + B[0, 1]);
            int x7 = (A[0, 1] - A[1, 1]) * (B[1, 0] + B[1, 1]);
            int[,] C = new int[2, 2];
            C[0, 0] = x1 + x4 - x5 + x7;
            C[0, 1] = x3 + x5;
            C[1, 0] = x2 + x4;
            C[1, 1] = x1 - x2 + x3 + x6;
            return C;
        }
        static int[] RandomArr(int Lenght, int from, int to)
        {
            Random r = new Random();
            int[] arr = new int[Lenght];
            to++;
            for (int i = 0; i < Lenght; i++)
            {
                arr[i] = r.Next(from, to);
            }
            return arr;
        }
        static int[,] Random2dArr(int m, int n, int from, int to)
        {
            Random r = new Random();
            int[,] arr = new int[m, n];
            to++;
            for (int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    arr[i, j] = r.Next(from, to);
                }
            }
            return arr;
        }
    }
}
