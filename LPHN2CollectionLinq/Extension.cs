using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPHN2CollectionLinq
{
    public static class Extension
    {
        public static List<T> Where<T>(this Collection<T> collection, Func<T, bool> condition) where T:class,IComparable<T>
        {
            //return (myList.Where(condition)).ToList<T>();
            return (collection.GetList.Values.Where(condition)).ToList<T>();
        }
    }
}
