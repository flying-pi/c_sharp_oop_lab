using System;
using System.Collections.Generic;

namespace class_diagram_lab.containers
{
    public interface IList<T> :IEnumerable<T> where T : IProduct
    {
        int Count { get; }
        void Add(T novel);
        void Remove(T item);
        void Remove(string productName);
        void Remove(int itemPosition);
        T this[int i] { get; }
        T this[string name] { get; }
        void Sort();
    }

    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException() : base("Can not found item")
        {
        }

        public ItemNotFoundException(string message) : base(message)
        {
        }

        public ItemNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}