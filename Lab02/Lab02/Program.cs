using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace Lab02
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = { 1, 1, 1, 1, 1, -1, -1, -1, -1 };
            //int[] arr = { 4, 4, 4, 4, -4, -4, -4, -4, -4 };
            //int[] arr = { 1, 1, 1, 1, 1, 0, 0, 0, 0 };
            //int[] arr = { 1, 1, 1, 1, 1, 2, 2, 2, 2 };
            //int[] arr = { 1, 1, 2, 2, 3, 3, 3, 4, 4, 4, 4 };
            //List<int> arr = new List<int>() { 1, 1, 2, 2, 3, 3, 3, 4, 4, 4, 4 };

            List<int> arr = new List<int>();

            StreamReader sr = new StreamReader("testArray.txt");
            Console.WriteLine("Start reading array");
            for (int i = 0; i < 100000000; i++)
            {
                arr.Add(Convert.ToInt32(sr.ReadLine()));
            }
            Console.WriteLine("End reading array");

            Stopwatch sw = new Stopwatch();
            sw.Start();
            int N = arr.Count();
            int K = 18;
            if (K >= Math.Log(N))
            {
                arr.Sort();
                for (int i = N - K; i < N; i++) Console.WriteLine(arr[i]);
            }
            else
            {
                List<int> outArr = new List<int>();
                int Ind = arr.IndexOf(arr.Max());
                outArr.Add(arr[Ind]);
                for (int i = 0; i < K - 1; i++)
                {
                    int P = Int32.MinValue;
                    int Pos = 0;
                    for (int j = 0; j < N; j++)
                    {
                        if (arr[j] > P && arr[j] < arr[Ind])
                        {
                            P = arr[j];
                            Pos = j;
                        }
                        else if (arr[j] == arr[Ind] && j > Ind)
                        {
                            P = arr[j];
                            Pos = j;
                            break;
                        }
                    }
                    Ind = Pos;
                    outArr.Add(P);
                }
                Console.WriteLine(String.Join(", ", outArr));
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds);

            static int MostCommonA(int[] arr) => (-1 & (arr.Sum() >> 31)) | 0b1;
            static int MostCommonB(int[] arr) => ((-1 & (arr.Sum() >> 31)) | 0b1) << 2;
            static int MostCommonC(int[] arr) => ((-1 & (((arr.Length >> 1) - arr.Sum()) >> 31)) | ~0b1) + 2;
            static int MostCommonD(int[] arr) => (int)Math.Round(arr.Average());
            static int MostCommonE(int[] arr)
            {
                int[] Count = new int[5];

                for (int i = 0; i < arr.Length; i++)
                {
                    Count[arr[i]]++;
                }
                return Array.IndexOf(Count, Count.Max());
            }

            static int BinarySearch(int[] arr, int n)
            {
                int r = arr.Length - 1;
                int l = 0;
                int curr = 0;
                while (l <= r)
                {
                    curr = (r + l) >> 1;
                    if (arr[curr] == n)
                        return curr;
                    if (n > arr[curr])
                    {
                        l = curr + 1;
                    }
                    else if (n < arr[curr])
                    {
                        r = curr - 1;
                    }
                }
                return -1;
            }
        }
    }
}