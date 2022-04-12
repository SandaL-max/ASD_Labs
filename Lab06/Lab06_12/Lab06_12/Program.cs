using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;


namespace Lab06_12
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int N = 1000000;
            int MaxDifference = 1000000;                       
            int[] arr = new int[N];
            Random random = new Random();
            for (int i = 0; i < N; i++)
            {
                arr[i] = random.Next(MaxDifference);
            }
            Stopwatch sw = new Stopwatch();
            List<int> list = arr.ToList();
            sw.Start();
            //CountingSort(arr);
            uint p = 0x800000;
            RadixSort(list, p);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds);
        }
        public static int[] GenerateArray(int N, int MaxMinDiff)
        {
            int[] arr = new int[N];
            Dictionary<int, int> Counts = new Dictionary<int, int>();
            for (int i = 0; i < MaxMinDiff; i++)
            {
                Counts.Add(i, N / MaxMinDiff);
            }
            Random r = new Random();
            for (int i = 0; i < N; i++)
            {
                int NewVal = r.Next(0, MaxMinDiff);
                while (Counts[NewVal] == 0)
                {
                    NewVal = r.Next(0, MaxMinDiff);
                }
                Counts[NewVal]--;
                arr[i] = NewVal;
            }
            return arr;
        }
        public static void CountingSort(int[] m)
        {
            int max = m.Max();
            int min = m.Min();
            int k = max - min + 1;
            int[] Len = new[] { k };
            int[] minInd = new[] { min };

            var counter = Array.CreateInstance(typeof(int), Len, minInd);
            for (int i = 0; i < m.Length; i++)
            {
                int v = (int)counter.GetValue(m[i]);
                counter.SetValue(v + 1, m[i]);
            }
            int p = 0;
            for (int item = min; item <= max; item++)
            {
                int e = (int)counter.GetValue(item);
                for (int j = 0; j < e; j++)
                {
                    m[p++] = item;
                }
            }
        }

        public static void RadixSort(List<int> m, uint p)
        {
            if (m.Count <= 1 || p == 0) return;
            List<int> a = new List<int>();
            List<int> b = new List<int>();
            foreach (int e in m)
                if ((e & p) == 0) a.Add(e);
                else b.Add(e);
            p >>= 1;
            RadixSort(a, p);
            RadixSort(b, p);
            for (int k = 0; k < a.Count; k++)
                m[k] = a[k];
            int l = 0;
            for (int k = a.Count; k < a.Count + b.Count; k++)
                m[k] = b[l++];

        }
    }
}