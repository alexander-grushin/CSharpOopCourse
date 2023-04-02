using System;
using System.Collections;
using System.Text;

namespace HashTableTask
{
    public class HashTable<T> : ICollection<T?>
    {
        private const int DefaultSize = 200;

        private List<T?>[] items;

        private int modCount;

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public HashTable()
        {
            items = new List<T?>[DefaultSize];

            Count = 0;
        }

        public HashTable(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"Size must be > 0. Current value = {size}", nameof(size));
            }

            items = new List<T?>[size];

            Count = size;
        }

        private int GetIndex(T? item)
        {
            if (item == null)
            {
                return 0;
            }

            return Math.Abs(item.GetHashCode() % items.Length);
        }

        public void Add(T? item)
        {
            int index = GetIndex(item);

            if (item == null)
            {
                return;
            }

            if (items[index] == null)
            {
                items[index] = new List<T?> { item };
                Count++;
            }
            else
            {
                items[index].Add(item);
                Count++;
            }

            modCount++;
        }

        public void Clear()
        {
            if (Count != 0)
            {
                Count = 0;
                Array.Clear(items);
            }
        }

        public bool Contains(T? item)
        {
            int index = GetIndex(item);

            if (items[index] == null || item == null)
            {
                return false;
            }

            return items[index].Contains(item);

        }

        public bool Remove(T? item)
        {
            int index = GetIndex(item);

            if (items[index] == null || item == null)
            {
                return false;
            }

            if (items[index].Count > 1)
            {
                items[index].Remove(item);
            }
            else
            {
                items[index] = new List<T?>();
            }

            Count--;
            modCount++;

            return true;
        }

        public void CopyTo(T?[] array, int arrayIndex)
        {

            //Array.Copy(items, 0, array, arrayIndex, Count);

        }

        public IEnumerator<T?> GetEnumerator() // TODO add modCount
        {
            int initialModCount = modCount;

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null)
                {
                    //yield return default;
                    continue;
                }

                foreach (T? item in items[i])
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            //StringBuilder stringBuilder = new StringBuilder("[");

            //stringBuilder.AppendJoin(", ", items.Where());

            //stringBuilder.Append(']');

            //return stringBuilder.ToString();

            return "";
        }
    }
}
