namespace MyClassLibrary
{
    public interface IMyList <T>
    {
        void Add(T element);
        void Remove(T element);
        void Remove(Node<T> element);
        Node<T> GetNode(T element);
        void PrintMyLinkedList();
    }
}