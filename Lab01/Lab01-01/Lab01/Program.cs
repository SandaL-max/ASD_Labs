using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> w = new List<int>(); // исходный список
            List<int> p = new List<int>(); // список перестановок
            for (int i = 1; i <= 3; i++)
            {
                w.Add(i);
            }

            Stopwatch st = new Stopwatch();
            st.Start();
            Per(w, p, 2); // вызов рекурсивной функции
            st.Stop();

            Console.WriteLine(st.Elapsed.TotalMilliseconds);

            Console.ReadKey();
        }

        static void Per(List<int> w, List<int> p, int rank)
        {
            int realRank = w.Count + p.Count - rank;
            if (w.Count > realRank) // условие продолжения рекурсии
            {
                for (int i = 0; i < w.Count; i++)
                {
                    List<int> w1 = new List<int>(); // новый список w1
                    w1 = w.GetRange(0, w.Count); // копируем w  w1
                    int e = w1[i]; // получаем i-й элемент
                    w1.RemoveAt(i); // удаляем i-й элемент
                    List<int> p1 = new List<int>(); // новый список p1
                    p1 = p.GetRange(0, p.Count); // копируем p  p1
                    p1.Add(e); // добавляем элемент в p1
                    Per(w1, p1, rank); // рекурсивный вызов
                }
            }
            else // дно рекурсии
            {
                Console.WriteLine(string.Join(" ", p)); // одна перестановка
            }
        }
    }
}
