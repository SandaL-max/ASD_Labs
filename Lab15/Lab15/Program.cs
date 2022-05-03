using System;

namespace Lab15;
class Program
{
    static void Main()
    {
        int len = 16;
        Fifteen fifteen = new Fifteen(len);
        
        fifteen.GenerateMap();
        for (int i = 0; i < len; i += (len / (int)Math.Sqrt(len)))
        {
            for (int j = i; j < i + (len / (int)Math.Sqrt(len)); j++)
            {
                Console.Write(fifteen.Map[j].ToString().PadLeft(2, ' ') + "  ");
            }
            Console.WriteLine();
        }
        Console.WriteLine(fifteen.GetHeuristics());
    }
}