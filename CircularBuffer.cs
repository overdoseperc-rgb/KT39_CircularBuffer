using System.Collections;

namespace ConsoleApp1
{
    internal class CircularBuffer<T> : IEnumerable<T>
    {
        private readonly T[] items;
        private int start;
        private int count;

        public CircularBuffer(int capacity)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(capacity);
            items = new T[capacity];
        }

        public void Add(T item)
        {
            items[GetIndex(count)] = item;

            if (count == items.Length)
            {
                start = (start + 1) % items.Length;
            }
            else
            {
                count++;
            }
        }

        private int GetIndex(int offset)
        {
            return (int)(((long)start + offset) % items.Length);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[GetIndex(i)];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> Reverse()
        {
            for (int i = count - 1; i >= 0; i--)
            {
                yield return items[GetIndex(i)];
            }
        }
    }
}
