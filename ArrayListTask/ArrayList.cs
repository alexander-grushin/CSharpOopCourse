using System.Collections;

namespace ArrayListTask
{
    class ArrayList<T> : IList<T>
    {
        private T[] items;

        private int count;

        private const int defaultCapasity = 10;

        public int Capacity
        {
            get
            {
                return items.Length;
            }
            set
            {
                if (value < count)
                {
                    throw new ArgumentOutOfRangeException($"Capacity must be greater than or equal to Count of the arrayLists (Count = {Count})." +
                        $" Current value = {value}", nameof(value));
                }

                if (value != items.Length)
                {
                    if (value == 0)
                    {
                        items = new T[0];
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
                if (index >= Count)
                {
                    throw new ArgumentOutOfRangeException($"Index must be within the bounds of the arrayList (Count = {Count}). Current value = {index}", nameof(index));
                }

                return items[index];
            }
            set
            {
                if (index >= Count)
                {
                    throw new ArgumentOutOfRangeException($"Index must be within the bounds of the arrayList (Count = {Count}). Current value = {index}", nameof(index));
                }

                items[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public bool IsReadOnly => false;

        public ArrayList()
        {
            items = new T[defaultCapasity];
        }

        public ArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException($"Capacity must be >= 0. Current value = {capacity}", nameof(capacity));
            }

            if (capacity == 0)
            {
                items = new T[0];
            }

            items = new T[capacity];
        }

        public void Add(T item)
        {
            if (count >= items.Length)
            {
                IncreaseCapacity();
            }

            items[Count] = item;
            count++;
        }

        private void IncreaseCapacity()
        {
            Array.Resize(ref items, items.Length * 2);
        }

        public void TrimExcess()
        {
            double limit = items.Length * 0.9;

            if (count < (int)limit)
            {
                Capacity = count;
            }
        }

        public void Clear()
        {
            items = new T[0];
            count = 0;
        }

        public bool Contains(T item)
        {
            return count > 0 && IndexOf(item) >= 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(items, 0, array, arrayIndex, count);
        }

        public void CopyTo(T[] array)
        {
            CopyTo(array, 0);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return items[i];
            }
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(items, item);
        }

        public int LastIndexOf(T item)
        {
            return Array.LastIndexOf(items, item);
        }

        public void Insert(int index, T item)
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException($"Index must be within the bounds of the arrayList (Count = {Count}). Current value = {index}", nameof(index));
            }

            if (Count == Capacity)
            {
                IncreaseCapacity();
            }

            Array.Copy(items, index, items, index + 1, Count - index);

            items[index] = item;
            count++;
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
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException($"Index must be within the bounds of the arrayList (Count = {Count}). Current value = {index}", nameof(index));
            }

            if (index < Count - 1)
            {
                Array.Copy(items, index + 1, items, index, Count - index - 1);
            }

            items[count - 1] = default;
            count--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}