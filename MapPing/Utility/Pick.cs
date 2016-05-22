using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MapPing.Utility
{
    public class Pick
    {
        /// <summary>
        /// Picks the first item that is not null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns>The first non-null item or null if they are all null</returns>
        public T First<T>(params T[] items)
        {
            return items.FirstOrDefault(x => x != null);
        }

        public string First(params string[] items)
        {
            return items.FirstOrDefault(x => !string.IsNullOrEmpty(x));
        }

    }
}