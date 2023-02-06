using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPHN2CollectionLinq
{
    public class Collection<T> : IEnumerable
        where T : class, IComparable<T>
    {
        private SortedList<string, T> myList = new SortedList<string, T>();
        public void AddElement(string key, T element) 
        {           
            myList.Add(key, element);           
        }
        //ajouter une proprietre pour acceder a la liste
        public SortedList<string, T> GetList => myList;

        public IEnumerator GetEnumerator()
        {
            foreach (T element in myList.Values)
            {
                yield return element;
            }
        }
        
        
    }
}
