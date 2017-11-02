using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary.Interfaces
{
  public  interface IMyHashTable<T, U> where T : IComparable<T>
    {
         void Delete(T key);
        U GetValue(T key);
        void Add(T key, U value);
    }
}
