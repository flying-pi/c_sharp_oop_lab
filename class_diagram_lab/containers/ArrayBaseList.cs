using System;
using System.Collections;
using System.Collections.Generic;

namespace class_diagram_lab.containers
{
    public class ArrayBaseList<T> : IList<T> where T : IProduct
    {
        private T[] _items;

        public int Count { get; private set; }

        protected T[] Items
        {
            get { return _items ?? (_items = new T[1]); }
            set { _items = value; }
        }

        public T this[int i]
        {
            get { return Items[i]; }
        }

        public T this[string name]
        {
            get
            {
                for (int i = 0; i < Count; i++)
                    if (Items[i].Name == name)
                        return Items[i];
                throw new ItemNotFoundException();
            }
        }


        public void Add(T novel)
        {
            Items[Count] = novel;
            Count++;
            if (Count < Items.Length)
                return;
            T[] newItems = new T[Count * 5 / 3 + 1];
            Array.Copy(Items, 0, newItems, 0, Count);
            Items = newItems;
        }

        public void Remove(T item)
        {
            T[] newArray = new T[Items.Length];
            int j = 0;
            for (int i = 0; i < Count; i++)
            {
                if (!Items[i].Equals(item) || i > j)
                    newArray[j++] = Items[i];
            }
            if (j == Count)
                throw new ItemNotFoundException();
            Items = newArray;
            Count--;
        }

        public void Remove(string productName)
        {
            Remove(this[productName]);
        }

        public void Remove(int itemPosition)
        {
            Remove(this[itemPosition]);
        }

        public void Sort()
        {
            for (int i = 0; i < Count - 1; i++)
            for (int j = i + 1; j < Count; j++)
                if (String.CompareOrdinal(Items[i].Name, Items[j].Name) > 0)
                {
                    T buf = Items[i];
                    Items[i] = Items[j];
                    Items[j] = buf;
                }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return $"@ArrayBaseList;Count:{Count}";
        }

        private class ListEnumerator: IEnumerator<T>
        {
            private readonly ArrayBaseList<T> _parent;
            private int _current = -1;

            public ListEnumerator(ArrayBaseList<T> parent)
            {
                _parent = parent;
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                _current++;
                return _current < _parent.Count;
            }

            public void Reset()
            {
                _current = -1;
            }

            public T Current => _parent[_current];

            object IEnumerator.Current => Current;
        }
    }
}