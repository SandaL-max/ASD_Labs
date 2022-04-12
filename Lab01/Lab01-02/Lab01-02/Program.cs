using System;
using System.Diagnostics;

namespace Lab01_02
{
    class Program
    {
        static void Main()
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            H(30, "A", "B", "C");
            st.Stop();
            Console.WriteLine(st.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
        static void H(int n, string x, string y, string z)
        {
            if (n == 0) return; // дно рекурсии
                H(n - 1, x, z, y); // перенос n-1 дисков с x на y, z – вспомогат.
            //Console.WriteLine($"диск {n}: {x} –> {z}"); // один диск x -> z
            H(n - 1, y, x, z); // перенос n-1 дисков с y на z, x – вспомогат.
        }
    }
}
