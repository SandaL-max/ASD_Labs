using System;

namespace Lab17;
class Program
{
    static void Main()
    {
        Console.WriteLine(RabinKarp("acracadabra", "bra"));
    }
    public static int RabinKarp(string text, string s)
    {
        int hp = s.GetHashCode();
        for (int i = 0; i <= text.Length - s.Length; i++)
        {
            int hs = text[i..(i + s.Length)].GetHashCode();
            if (hs == hp) return i;
        }
        return -1;
    }
    public static Dictionary<char, int> StopTable(in string s)
    {
        Dictionary<char, int> result = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            result[s[i]] = i;
        }
        for (int i = 0; i < 65553; i++)
        {
            if (result.ContainsKey((char)i) == false)
                result[(char)i] = -1;
        }
        return result;
    }
}