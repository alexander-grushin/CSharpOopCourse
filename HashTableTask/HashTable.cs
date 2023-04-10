using System.Collections;
using System.Text;

namespace HashTableTask
{
    public class HashTable<T> : ICollection<T>
    {
        private const int DefaultSize = 100;

        private readonly List<T>[] items;

        private int modCount;

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public HashTable()
        {
            items = new List<T>[DefaultSize];
        }

        public HashTable(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"Size must be > 0. Current value = {size}", nameof(size));
            }

            items = new List<T>[size];
        }

        private int GetIndex(T item)
        {
            if (item == null)
            {
                return 0;
            }

            return Math.Abs(item.GetHashCode() % items.Length);
        }

        public void Add(T item)
        {
            int index = GetIndex(item);

            if (items[index] == null)
            {
                items[index] = new List<T> { item };
            }
            else
            {
                items[index].Add(item);
            }

            Count++;
            modCount++;
        }

        public void Clear()
        {
            if (Count != 0)
            {
                foreach (List<T> item in items)
                {
                    item?.Clear();
                }

                Count = 0;
                modCount++;
            }
        }

        public bool Contains(T item)
        {
            int index = GetIndex(item);

            if (items[index] == null)
            {
                return false;
            }

            return items[index].Contains(item);

        }

        public bool Remove(T item)
        {
            int index = GetIndex(item);

            if (items[index] == null)
            {
                return false;
            }

            if (items[index].Count != 1)
            {
                items[index].Remove(item);
            }
            else
            {
                items[index] = new List<T>();
            }

            Count--;
            modCount++;

            return true;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException("Array was not long enough. Check the array index and length the array.", nameof(arrayIndex));
            }

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    items[i].CopyTo(0, array, arrayIndex, items[i].Count);

                    arrayIndex += items[i].Count;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int initialModCount = modCount;

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    foreach (T item in items[i])
                    {
                        if (initialModCount != modCount)
                        {
                            throw new InvalidOperationException("Items during the go-round added or or removed in the HashTable.");
                        }

                        yield return item;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("[");

            IEnumerator<T> iterator = GetEnumerator();

            int index = 0;

            while (iterator.MoveNext())
            {
                index++;

                stringBuilder.Append(iterator.Current + (index != Count ? "; " : ""));
            }

            stringBuilder.Append(']');

            return stringBuilder.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            HashTable<T> hashTable = (HashTable<T>)obj;

            if (Count != hashTable.Count)
            {
                return false;
            }

            IEnumerator<T> iterator1 = GetEnumerator();
            IEnumerator<T> iterator2 = hashTable.GetEnumerator();

            while (iterator1.MoveNext() && iterator2.MoveNext())
            {
                if (!Equals(iterator1.Current, iterator2.Current))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            const int prime = 37;
            int hash = 1;

            IEnumerator<T?> iterator = GetEnumerator();

            while (iterator.MoveNext())
            {
                hash = prime * hash + (iterator.Current != null ? iterator.Current.GetHashCode() : 0);
            }

            return hash;
        }
    }
}