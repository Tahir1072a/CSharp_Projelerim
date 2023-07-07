using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataStructures.MyArrayList
{
    public class MyList<T> : IEnumerable<T>, ICloneable
    {
        private T[] InnerList; // => refrans tipli bir değişken.
        public int Capacity => InnerList.Length;
        public int Count { get; private set; }
        public MyList()
        {
            InnerList = new T[4];
            Count = 0;
        }
        public MyList(params T[] initial)
        {
            InnerList = new T[initial.Length];
            Count = 0;
            foreach (var item in initial)
            {
                Add(item);
            }
        }
        //Listeyi initialize ederken bir koleksiyon tanımlamak istiyorsak o zaman, o zaman bu constructor yapısı çalışacaktır.
        public MyList(IEnumerable<T> collection)
        {
            InnerList = new T[collection.ToArray().Length];
            Count = 0;
            foreach (var item in collection)
                Add(item);
        }
        public T this[int index]
        {
            get => InnerList[index];
            set => InnerList[index] = value;
        }
        public void Add(T item)
        {
            if (Capacity == Count)
                DoubleList();
            InnerList[Count++] = item;
        }
        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }
        private void DoubleList()
        {
            var temp = new T[Capacity * 2];
            Array.Copy(InnerList, temp, Count);
            InnerList = temp;
        }
        public bool RemoveAll(T item)
        {
            if (Capacity / 4 == Count)
                HalfList();
            if (!(Count > 0))
            {
                Console.WriteLine("The list alredy empty!"); 
                return false;
            }

            InnerList = item != null ? InnerList.Take(Count).Where(x => !(item.Equals(x))).ToArray() : InnerList;
            Count = InnerList.Length;
            
            return true;
        }
        public void RemoveAt(int index)
        {
            //Buradaki algoritmayı kendin yazmayı dene!
        }
        private void HalfList()
        {
            var temp = new T[Capacity / 2];
            Array.Copy(InnerList, temp, Count);
            InnerList = temp;
        }

        public object Clone()
        {
            /* shallow copy
            #region
            //Burada aslında shallow copy var ancak bu nesne için deep copy yapıyor. Buradaki sorun bu nesne içindeki referans tipli değişkenlerin shallow copy ile kopyalanması.
            return this.MemberwiseClone();
            #endregion
            */

            //deep copy => Bu sayede refrans tipli değişkenlerin bile referansları değil kendileri kopyalanmış olur.
            #region
            var arr = new MyList<T>();
            foreach (var item in this)
            {
                arr.Add(item);
            }
            return arr;

            #endregion
        }

        public IEnumerator<T> GetEnumerator()
        {
            //Take() ifadesi count kadar elamnı numalandırarak dönmesini sağlar. Bu sayede foreach gibi bir döngü kullanılarak list içindeki elemanlara erişme fırsatına sahip oluruz.
            
            return InnerList.Take(Count).GetEnumerator();
        
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
