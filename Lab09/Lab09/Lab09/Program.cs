using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;

namespace Lab09;

class Program
{
    static void Main(string[] args)
    {
        for (int k  = 1; k <= 10; k++)
        {
            int[] arr = new int[1000000 * k];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
            }
            List<int> list = new List<int>(arr);
            LinkedList<int> list2 = new LinkedList<int>(arr);
            GC.Collect();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            list.Contains(list.Count + 1);
            sw.Stop();
            Console.Write(sw.Elapsed.TotalMilliseconds);
            sw = Stopwatch.StartNew();
            list2.Contains(list2.Count + 1);
            sw.Stop();
            Console.Write(" " + sw.Elapsed.TotalMilliseconds + "\n");
        }
    }
}