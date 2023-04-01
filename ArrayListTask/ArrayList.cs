using System.Collections;
using System.Text;

namespace ArrayListTask
{
    class ArrayList<T> : IList<T?>
    {
        private const int DefaultCapacity = 10;

        private T?[] items;

        private int modCount;

        public int Capacity
        {
            get
            {
                return items.Length;
            }
            set
            {
                if (value < Count)
                {
                    throw new ArgumentOutOfRangeException($"Capacity must be greater than or equal to Count of the arrayLists (Count = {Count})." +
                        $" Current value = {value}", nameof(value));
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

        public T? this[int index]
        {
            get
            {
                if (index >= Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException($"Index must be within the bounds of the arrayList (Count = {Count}). Current value = {index}", nameof(index));
                }

                return items[index];
            }
            set
            {
                if (index >= Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException($"Index must be within the bounds of the arrayList (Count = {Count}). Current value = {index}", nameof(index));
                }

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
                throw new ArgumentOutOfRangeException($"Capacity must be >= 0. Current value = {capacity}", nameof(capacity));
            }

            items = new T[capacity];
        }

        public void Add(T? item)
        {
            if (Capacity == 0)
            {
                Capacity = DefaultCapacity;
            }

            if (Count >= items.Length)
            {
                IncreaseCapacity();
            }

            items[Count] = item;
            Count++;
            modCount++;
        }

        private void IncreaseCapacity()
        {
            Array.Resize(ref items, items.Length * 2);
        }

        public void TrimExcess()
        {
            int limit = (int)(items.Length * 0.9);

            if (Count < limit)
            {
                Capacity = Count;
            }
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
            return IndexOf(item) >= 0;
        }

        public void CopyTo(T?[] array, int arrayIndex)
        {
            Array.Copy(items, 0, array, arrayIndex, Count);
        }

        public void CopyTo(T[] array)
        {
            CopyTo(array, 0);
        }

        public IEnumerator<T?> GetEnumerator()
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

        public int IndexOf(T? item)
        {
            return Array.IndexOf(items, item, 0, Count);
        }

        public int LastIndexOf(T? item)
        {
            return Array.LastIndexOf(items, item, Count - 1, Count);
        }

        public void Insert(int index, T? item)
        {
            if (index > Count || index < 0)
            {
                throw new ArgumentOutOfRangeException($"Index must be within the bounds of the arrayList (Count = {Count}). Current value = {index}", nameof(index));
            }

            if (Capacity == 0)
            {
                Capacity = DefaultCapacity;
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

        public bool Remove(T? item)
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
            if (index >= Count || index < 0)
            {
                throw new ArgumentOutOfRangeException($"Index must be within the bounds of the arrayList (Count = {Count}). Current value = {index}", nameof(index));
            }

            if (index < Count - 1)
            {
                Array.Copy(items, index + 1, items, index, Count - index - 1);
            }

            items[Count - 1] = default;
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

            if (obj is ArrayList<T> arrayList)
            {
                if (Count != arrayList.Count || Capacity != arrayList.Capacity)
                {
                    return false;
                }

                for (int i = 0; i < Count; i++)
                {
                    if (!items[i].Equals(arrayList[i]))
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            const int prime = 37;
            int hash = 1;

            hash = prime * hash + Count;
            hash = prime * hash + Capacity;

            for (int i = 0; i < Count; i++)
            {
                hash = prime * hash + (items[i] != null ? items[i].GetHashCode() : 0);
            }

            return hash;
        }
    }
}