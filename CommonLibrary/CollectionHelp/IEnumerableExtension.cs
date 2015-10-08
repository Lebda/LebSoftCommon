using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonLibrary.CollectionHelp
{
    static public class IEnumerableExtension
    {
        static public ICollection<T> ToCollection<T>(this IEnumerable<T> items)
        {
            ICollection<T> retVal = new List<T>();
            foreach (var item in items)
            {
                retVal.Add(item);
            }
            return retVal;
        }
    }
}
