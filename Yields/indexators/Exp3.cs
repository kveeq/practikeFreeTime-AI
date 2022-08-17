using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields.indexators
{
    public class GenericArray<T>
    {
        public List<T> array;

        public GenericArray(List<T> array)
        {
            this.array = array;
        }

        public void AddToArr(T item)
        {
            array.Add(item);
        }

        public void DeleteArr(T item)
        {
            array.Remove(item);
        }

        public int GetLength()
        {
            return array.Count;
        }

        public T this[int index]
        {
            get
            {
                if(index >= 0 && index < array.Count)
                    return array[index];
                return default(T);
            }
        }
    }
}
