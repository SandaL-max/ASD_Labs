using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
    public class Fifteen
    {
        public int[] Map;

        public Fifteen(int len = 16)
        {
            if ((len % (int)Math.Sqrt(len)) == 0)
                Map = new int[len];
            else throw new ArgumentException("Len должно быть кратно 4");
        }
        public void GenerateMap()
        {
            do
            {
                var NotUsedNums = new List<int>();
                for (int i = 0; i < Map.Length; i++)
                {
                    NotUsedNums.Add(i);
                }
                var rand = new Random();
                for (int i = 0; i < Map.Length; i++)
                {
                    var randIndex = rand.Next(0, NotUsedNums.Count);
                    Map[i] = NotUsedNums[randIndex];
                    NotUsedNums.RemoveAt(randIndex);
                }
            } while (CheckMap() == false);
        }
        private bool CheckMap()
        {
            int EvenSums = 0;
            for (int i = 0; i < Map.Length; i += (Map.Length / (int)Math.Sqrt(Map.Length)))
            {
                for (int j = i; j < i + (Map.Length / (int)Math.Sqrt(Map.Length)); j++)
                {
                    if (Map[j] != 0)
                        EvenSums += GetEvenSum(j);
                    else
                        EvenSums += i;
                }
            }
            return (EvenSums & 1) == 0;
        }
        private int GetEvenSum(int index)
        {
            int EvenSum = 0;
            for(int i = index; i < Map.Length; i++)
            {
                if (Map[i] != 0 && Map[i] < Map[index])
                    EvenSum++;
            }
            return EvenSum;
        }
        public int GetHeuristics()
        {
            var heuristics = 0;
            for (int i = 0; i < Map.Length; i++)
            {
                var y1 = i % (Map.Length / (int)Math.Sqrt(Map.Length));
                var x1 = i / (Map.Length / (int)Math.Sqrt(Map.Length));

                var value = Map[x1 * y1] - 1;

                var y2 = value % (Map.Length / (int)Math.Sqrt(Map.Length));
                var x2 = value / (Map.Length / (int)Math.Sqrt(Map.Length));

                heuristics += Math.Abs(x1 - y1) + Math.Abs(x2 - y2);
            }
            return heuristics;
        }
    }
}
