using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Lab05_01_02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //for (int a = 100000; a <= 1000000; a += 100000)
            //{
            //    int[] m = new int[a];
            //    //Console.WriteLine($"Lenght is a: {m.Length}");
                
            //    Stopwatch sw = new Stopwatch();

            //    for (int i = 0; i < m.Length; i++)
            //    {
            //        m[i] = i;
            //    }
            //    RandomizeArr(m, 0);
            //    sw.Start();
            //    //Heapsort(m);
            //    MergeSort(m);
            //    sw.Stop();
            //    Console.WriteLine(Math.Round(sw.Elapsed.TotalMilliseconds, 3));
                
            //}
            int[] m = new int[100000];
            Console.WriteLine($"Lenght is a: {m.Length}");
            for (int k = 0; k <= 100; k += 10)
            {
                Stopwatch sw = new Stopwatch();

                for (int i = 0; i < m.Length; i++)
                {
                    m[i] = i;
                }
                RandomizeArr(m, k);
                sw.Start();
                //Heapsort(m);
                MergeSort(m);
                sw.Stop();
                Console.WriteLine(Math.Round(sw.Elapsed.TotalMilliseconds, 3));
            }
        }
        static void RandomizeArr(int[] m, int percent)
        {
            Random r = new Random();
            List<int> d = new List<int>();
            for (int i = 0; i < m.Length; i++)
            {
                d.Add(i);
            }
            int RealPercent = percent * m.Length / 200;
            for (int i = 0; i < RealPercent; i++)
            {

                int tmp = r.Next(d.Count);
                int Ind1 = d[tmp];
                d.RemoveAt(tmp);
                tmp = r.Next(d.Count);
                int Ind2 = d[tmp];
                d.RemoveAt(tmp);
                (m[Ind1], m[Ind2]) = (m[Ind2], m[Ind1]);
            }
        }
        //static int[] RandomizeArr(int Lenght, int percent)
        //{
        //    int[] arr = new int[Lenght];



        //    return arr;
        //}
        static void Heapify(int[] m, int i, int size)
        {

            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int max = i;
            if (left <= size && m[left] > m[max])
                max = left;
            if (right <= size && m[right] > m[max])
                max = right;
            if (max != i)
            {
                (m[i], m[max]) = (m[max], m[i]);
                Heapify(m, max, size);
            }
        }
        //
        static void BuildHeap(int[] m)
        {
            int size = m.Length - 1;
            for (int i = m.Length / 2 - 1; i >= 0; i--)
            {
                Heapify(m, i, size);
            }
        }
        static void Heapsort(int[] m)
        {
            BuildHeap(m);
            int size = m.Length - 1;
            for (int i = size; i > 0; i--)
            {
                (m[0], m[i]) = (m[i], m[0]);
                size--;
                Heapify(m, 0, size);
            }
        }
        static int[] Merge(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];
            int i = 0, j = 0, k = 0;
            while (left.Length > i & right.Length > j)
                if (left[i] <= right[j])
                    result[k++] = left[i++];
                else result[k++] = right[j++];
            while (left.Length > i)
                result[k++] = left[i++];
            while (right.Length > j)
                result[k++] = right[j++];
            return result;
        }
        static int[] MergeSort(int[] m)
        {
            if (m.Length <= 1) return m;
            else
            {
                int middle = m.Length / 2;
                int[] left = new int[middle];
                int[] right = new int[m.Length - middle];
                for (int i = 0; i < middle; i++)
                    left[i] = m[i];
                for (int i = middle; i < m.Length; i++)
                    right[i - middle] = m[i];
                left = MergeSort(left);
                right = MergeSort(right);
                int[] result = Merge(left, right);
                return result;
            }
        }
    }
}