using MyClassLibrary.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
   public  class MyHashTable<T,U> : IMyHashTable<T,U> where T : IComparable<T>
    {

        //Taille par défault du tableau 
        private const int DEFAULT_ARR_SIZE = 15;

        //Valeur Max d'un tableau
        private const int MAX_ARRAY_LENGTH = 0X7FEFFFFF;

        //Seuil de redimmensionnement 
        private const double MAX_LOAD_FACTOR = 0.45;

        //Nombre d'élements ajoutés au HashTable
        private int count;

        //Taille de mon tableau de LinkedList
        private int _size { get; set; }
        public int Count { get { return count; } private set { count = value; } }

        
        //Tableau de linkedList pour gérer les collision 
        private LinkedList<MyHashTableObject<T, U>>[] arr;
         

        public MyHashTable() : this(DEFAULT_ARR_SIZE)
        {
        }
        public MyHashTable(int input_size)
        {
            arr = new LinkedList<MyHashTableObject<T, U>>[input_size];
            _size = 0;
            count = 0;

        }

        //Ajout d'une clé valeur
        public void Add(T key, U value)
        {
            int index = CustomGetHashCode(key);
            LinkedList<MyHashTableObject<T, U>> items = arr[index];

            if (items == null)
            {
                items = new LinkedList<MyHashTableObject<T, U>>();

                MyHashTableObject<T, U> item = new MyHashTableObject<T, U>();
                item.Key = key;
                item.Value = value;

                items.AddLast(item);

                if (_size >= arr.Length * MAX_LOAD_FACTOR)
                {
                    ExpandArrayCapacity(arr.Length + 1);
                }
                else
                {
                   
                }
                arr[index] = items;
                _size++;
                
            }
            else
            {

                foreach (var itemT in items)
                {
                    if (itemT.Key.Equals(key))
                    {
                        itemT.Value = value;
                        return;
                    }
                }


                MyHashTableObject<T, U> item = new MyHashTableObject<T, U>();
                item.Key = key;
                item.Value = value;

                items.AddLast(item);
            }

            count++;
        }

        //AUgmentation de la taille du tableau 
        private void ExpandArrayCapacity(int minCapacity)
        {
            int newCapacity = (arr.Length == 0 ? DEFAULT_ARR_SIZE : arr.Length * 2);

            // Handle overflow
            if (newCapacity >= MAX_ARRAY_LENGTH)
                newCapacity = MAX_ARRAY_LENGTH;
            else if (newCapacity < minCapacity)
                newCapacity = minCapacity;


            


            var oldSize = _size;
            var oldCollection = this.arr;

            try
            {
                this.arr = new LinkedList<MyHashTableObject<T, U>>[newCapacity];

                // Reset size
                _size = 0;

                for (int i = 0; i < oldCollection.Length; ++i)
                {
                    if (oldCollection[i] != null)
                    {

                        arr[i] = oldCollection[i];
                        _size++;
                        //Recopier l'ancien  tableau dans un nouveau tableau  
                    }
                }
            }
            catch (OutOfMemoryException ex)
            {
                arr = oldCollection;
                _size = oldSize;

                throw ex.InnerException;
            }
        }

        //Récupérer un Objet (clé, valeur) de mon tableau avec sa clé 
        private MyHashTableObject<T, U> GetObject(T key)
        {
            if (key == null)
                return null;

            int index = CustomGetHashCode(key);
            LinkedList<MyHashTableObject<T, U>> items = arr[index];

            if (items == null)
                return null;

           
            foreach (var item in items)
            {
                if (item.Key.Equals(key))
                    return item;
            }

            return null;
        }

        //Retourne une valeur en fonction de la clé entrée
        public U GetValue(T key)
        {
            MyHashTableObject<T, U> item = GetObject(key);

            if (item == null)
                return default(U);
            else
                return item.Value;
        }

        //Supprimer une clé valeur 
        public void Delete(T key)
        {
            int index = CustomGetHashCode(key);
            LinkedList<MyHashTableObject<T, U>> items = arr[index];

            if (items == null)
                return;


            foreach (var item in items)
            {
                if (item.Key.Equals(key))
                {
                    items.Remove(item);
                    count--;
                    return;
                }
            }

        }

        //My Custom Hash Func 
        private int CustomGetHashCode(T key)
        {

            return key.GetHashCode()% DEFAULT_ARR_SIZE;
        }
        }
}
