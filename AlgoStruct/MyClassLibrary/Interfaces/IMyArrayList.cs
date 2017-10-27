using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary.Interfaces
{
    public interface IMyArrayList<T> : ICustomList<T>
    {

        void AddAt(int index, T element);
        T get(int index);
    }
}
