using System.Collections;

namespace HashTableTask
{
    public class HashTable<T> : ICollection<T>
    {
        private List<T>[] items;

        public int Count { get; }

        public bool IsReadOnly => false; // ?

        public HashTable(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"Size must be > 0. Current value = {size}", nameof(size));
            }

            items = new List<T>[size];

            Count = size;
        }

        private int GetIndex(T item)
        {
            if (item == null)
            {
                return 0; // return -1; or null?
            }

            return Math.Abs(item.GetHashCode() % items.Length);
        }

        public void Add(T item)
        {
            int index = GetIndex(item);

            if (index == 0)
            {
                return;
            }

            if (items[index] == null)
            {
                items[index] = new List<T> { item };

                return;
            }

            if (true) // проверка что объект уже есть ?
            {

            }

            items[index].Add(item);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            //throw new NotImplementedException();
            //return items[1].GetEnumerator();

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null)
                {
                    //yield return null;
                    continue;
                }

                //yield return items[i];
                
                foreach (var item in items[i])
                {

                    yield return item;
                }
            }

        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
