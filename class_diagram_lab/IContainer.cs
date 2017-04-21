namespace class_diagram_lab
{
    public interface IContainer
    {
        Product this[string key] { get; }
        Product this[int index] { get; set; }

        int Count { get; }

        void Add(Product p);
        void Add(params Product[] items);
        bool Contain(Product product);
        void Remove(string name);
        void Remove(Product product);
        void Remove(int itemIndex);
        void Sort();
    }
}