using System;

namespace Lab05_03
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[100];
            int k = 5;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
            }
            Pyramid pyr = new Pyramid(arr[0..k]);
            pyr.BuildHeap();
            
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > pyr.Arr[0])
                {
                    pyr.Arr[0] = arr[i];
                    pyr.Heapify(0, pyr.Arr.Length - 1);
                }
            }

            for (int i = 0; i < pyr.Arr.Length; i++)
            {
                Console.WriteLine(pyr.Arr[i]);
            }
        }
    }

    public class Pyramid
    {
        private int[] arr;
        public int[] Arr
        {
            get { return arr; }
            set
            {
                arr = value;
            }
        }
        public Pyramid(int[] m)
        {
            Arr = m;
        }
        public void Heapify(int i, int size)
        {

            int left = 2 * i + 1 >= size ? size : i * 2 + 1;
            int right = left + 1 >= size ? size : left + 1;
            int max = i;
            if (left <= size && arr[left] < arr[max])
                max = left;
            if (right <= size && arr[right] < arr[max])
                max = right;
            if (max != i)
            {
                (arr[i], arr[max]) = (arr[max], arr[i]);
                Heapify(max, size);
            }
        }
        public void BuildHeap()
        {
            int size = arr.Length - 1;
            for (int i = arr.Length / 2 - 1; i >= 0; i--)
            {
                Heapify(i, size);
            }
        }
    }
}
