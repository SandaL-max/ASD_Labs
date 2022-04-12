using System;
using System.Diagnostics;

namespace Lab04
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] Arr = new int[1000000];
            Stopwatch sw = new Stopwatch();

            //int A = 10;

            for (int i = 0; i <= 10; i++)
            {
                //LightRandArr(i * 10, ref Arr);
                RandomizeArray(i * 10, ref Arr);
                sw.Start();
                Array.Sort(Arr);
                Console.WriteLine($"{sw.Elapsed.TotalMilliseconds}");
                sw.Reset();
            }
        }
        static void RandomizeArray(int percentOfRand, ref int[] Arr)
        {
            for (int i = 0; i < Arr.Length; i++)
            {
                Arr[i] = i;
            }

            int B = percentOfRand * Arr.Length / 200;

            Random r = new Random();
            for (int i = 0; i < B; i++)
            {
                int Ind1 = r.Next(Arr.Length);
                int Ind2 = r.Next(Arr.Length);

                (Arr[Ind1], Arr[Ind2]) = (Arr[Ind2], Arr[Ind1]);
            }
        }
    }
}
