using System;
namespace Lab16;
class Program
{
    static void Main()
    {

    }
    public static ulong FNV(ulong[] words, ulong n, ulong m)
    {
        ulong P = 16777619;
        ulong h0 = 2166136261;
        if (m - 1 == 0) return (h0 * P) & n ^ words[m];
        return (FNV(words, n, m - 1) * P) & n ^ words[m];
    }
    public static int[] GetAlphabet(string text)
    {
        var Alphabet = new int[128];
        for(int i = 0; i < Alphabet.Length; i++)
            Alphabet[i] = 0;
        for (int i = 0; i < text.Length; i++)
        {
            Alphabet[text[i]]++;
        }
        return Alphabet;
    }
    public static bool CompareTexts(string text1, string text2)
    {
        var Alphabet = GetAlphabet(text1);
        for (int i = 0; i < text2.Length; i++)
        {
            if (Alphabet[text2[i]] - 1 < 0) return false;
            Alphabet[text2[i]]--;
        }
        return Alphabet.Sum() == 0;
    }
}