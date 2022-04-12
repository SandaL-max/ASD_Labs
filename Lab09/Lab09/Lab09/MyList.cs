using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab09
{
    public class MyList<T>
    {
        private int capacity;
        public int Capacity
        {
            get { return capacity; }
        }
        private int count;
        public int Count
        {
            get { return count; }
        }
        private T[] Arr;
        public MyList(int _capacity = 100)
        {
            capacity = _capacity;
            Arr = new T[capacity];
            count = 0;
        }
        public MyList(T[] values)
        {
            count = values.Length;
            if (count < 100)
                capacity = 100;
            else
                capacity = count + 1;
            Arr = new T[capacity];
            for (int i = 0; i < values.Length; i++)
            {
                Arr[i] = values[i];
            }
        }
        public T this[int i]
        {
            get { return Arr[i]; }
            set { Arr[i] = value; }
        }
        public void Add(T value)
        {
            if (count < capacity)
                Arr[count] = value;
            else
            {
                capacity += 4;
                Array.Resize(ref Arr, capacity);
                Arr[count] = value;
            }
            count++;
        }
        public void Insert(T value, int position)
        {
            if (position >= 0 && position <= count)
            {
                if (count >= capacity)
                {
                    capacity += 4;
                    Array.Resize(ref Arr, capacity);
                }
                if (position == count)
                {
                    Arr[count] = value;
                    count++;
                }
                else
                {
                    for (int i = count - 1; i >= position; i--)
                    {
                        Arr[i + 1] = Arr[i];
                    }
                    Arr[position] = value;
                    count++;
                }
            }
            else
            {
                throw new System.Exception("Выход индекса за границу массива: " + count);
            }
        }
        public T Cut(int position)
        {
            T result = Arr[position];
            if (position >= 0 && position <= count && count <= capacity)
            {
                for (int i = position; i < count - 1; i++)
                {
                    Arr[i] = Arr[i + 1];
                }
                count--;
            }
            else
            {
                throw new System.Exception("Выход индекса за границу массива: " + count);
            }
            return result;
        }

        public int Remove(T val)
        {
            for (int i = 0; i < count; i++)
            {
                if (val.Equals(Arr[i]))
                {
                    this.Cut(i);
                    return i;
                }
            }
            return -1;
        }
    }
}
