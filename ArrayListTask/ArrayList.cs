using System.Collections;
using System.Text;

namespace ArrayListTask
{
    class ArrayList<T> : IList<T>
    {
        private const int DefaultCapacity = 10;

        private T[] items;

        private int modCount;

        public int Capacity
        {
            get => items.Length;

            set
            {
                if (value < Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"Capacity must be >= Count (Count = {Count}). Current capacity = {value}");
                }

                if (value != items.Length)
                {
                    if (value == 0)
                    {
                        items = Array.Empty<T>();
                    }
                    else
                    {
                        Array.Resize(ref items, value);
                    }
                }
            }
        }

        public T this[int index]
        {
            get
            {
                CheckIndex(index);

                return items[index];
            }

            set
            {
                CheckIndex(index);

                items[index] = value;
                modCount++;
            }
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public ArrayList()
        {
            items = new T[DefaultCapacity];
        }

        public ArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), $"Capacity must be >= 0. Current capacity = {capacity}");
            }

            items = new T[capacity];
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Index must be >= 0 or < Count (Count = {Count}). Current index = {index}");
            }
        }

        public void Add(T item)
        {
            Insert(Count, item);
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Index must be >= 0 or <= Count (Count = {Count}). Current index = {index}");
            }

            if (Count == Capacity)
            {
                IncreaseCapacity();
            }

            Array.Copy(items, index, items, index + 1, Count - index);

            items[index] = item;
            Count++;
            modCount++;
        }

        private void IncreaseCapacity()
        {
            if (Capacity == 0)
            {
                Capacity = DefaultCapacity;
            }
            else
            {
                Capacity *= 2;
            }
        }

        public void TrimExcess()
        {
            if (Count < Capacity * 0.9)
            {
                Capacity = Count;
            }
        }

        public void Clear()
        {
            if (Count != 0)
            {
                Array.Clear(items, 0, Count);

                Count = 0;
                modCount++;
            }
        }

        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(items, 0, array, arrayIndex, Count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            int initialModCount = modCount;

            for (int i = 0; i < Count; i++)
            {
                if (initialModCount != modCount)
                {
                    throw new InvalidOperationException("Items during the go-round added or changed, or removed in the ArrayList.");
                }

                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(items, item, 0, Count);
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index < 0)
            {
                return false;
            }

            RemoveAt(index);

            return true;
        }

        public void RemoveAt(int index)
        {
            CheckIndex(index);

            if (index < Count - 1)
            {
                Array.Copy(items, index + 1, items, index, Count - index - 1);
            }

            items[Count - 1] = default!;
            Count--;

            modCount++;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("[");

            stringBuilder.AppendJoin(", ", items.Take(Count));

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

            ArrayList<T> arrayList = (ArrayList<T>)obj;

            if (Count != arrayList.Count)
            {
                return false;
            }

            for (int i = 0; i < Count; i++)
            {
                if (!Equals(items[i], arrayList[i]))
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

            for (int i = 0; i < Count; i++)
            {
                hash = prime * hash + (items[i]?.GetHashCode() ?? 0);
            }

            return hash;
        }
    }
}