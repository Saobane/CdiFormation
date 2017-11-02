using System.Collections;

namespace MyClassLibrary
{
    public interface ICustomList <T> : IEnumerable
    {
        void Add(T element);
        void Remove(T element);
        
        
    }
}