using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class MyHashTableObject <TKey, TValue> where TKey : IComparable<TKey>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public MyHashTableObject() : this(default(TKey), default(TValue)) { }

        public MyHashTableObject(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        
    }
}
