using System.Collections;
using System.Text;

namespace HashTableTask
{
    public class HashTable<T> : ICollection<T>
    {
        private const int DefaultSize = 100;

        private readonly List<T>?[] lists;

        private int modCount;

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public HashTable()
        {
            lists = new List<T>[DefaultSize];
        }

        public HashTable(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"Size must be > 0. Current value = {size}", nameof(size));
            }

            lists = new List<T>[size];
        }

        private int GetIndex(T? item)
        {
            if (item == null)
            {
                return 0;
            }

            return Math.Abs(item.GetHashCode() % lists.Length);
        }

        public void Add(T item)
        {
            int index = GetIndex(item);

            if (lists[index] == null)
            {
                lists[index] = new List<T> { item };
            }
            else
            {
                lists[index]!.Add(item);
            }

            Count++;
            modCount++;
        }

        public void Clear()
        {
            if (Count != 0)
            {
                foreach (List<T>? item in lists)
                {
                    item?.Clear();
                }

                Count = 0;
                modCount++;
            }
        }

        public bool Contains(T item)
        {
            return lists[GetIndex(item)]!.Contains(item);
        }

        public bool Remove(T item)
        {
            int index = GetIndex(item);

            if (lists[index] == null)
            {
                return false;
            }

            if (!lists[index]!.Contains(item))
            {
                return false;
            }

            lists[index]!.Remove(item);

            Count--;
            modCount++;

            return true;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array cannot be null.");
            }

            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"Index must be within the bounds of the array.");
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException("Array was not long enough. Check the array index and length the array.", nameof(arrayIndex));
            }

            foreach (List<T>? list in lists)
            {
                if (list != null)
                {
                    list.CopyTo(0, array, arrayIndex, list.Count);

                    arrayIndex += list.Count;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int initialModCount = modCount;

            foreach (List<T>? list in lists)
            {
                if (list != null)
                {
                    foreach (T item in list)
                    {
                        if (initialModCount != modCount)
                        {
                            throw new InvalidOperationException("Items during the go-round added or removed in the HashTable.");
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

            foreach (List<T>? list in lists)
            {
                if (list != null)
                {
                    foreach (T item in list)
                    {
                        if (item == null)
                        {
                            stringBuilder.Append("null; ");
                        }
                        else
                        {
                            stringBuilder.Append($"{item}; ");
                        }
                    }
                }
            }

            if (Count > 0)
            {
                stringBuilder.Remove(stringBuilder.Length - 2, 2);
            }

            stringBuilder.Append(']');

            return stringBuilder.ToString();
        }
    }
}