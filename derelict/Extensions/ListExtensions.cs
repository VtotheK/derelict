using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derelict.Extensions
{
    public static class ListExtensions
    {
        public static void CreateIfNull<T>(this List<T> l) { if (l == null) { l = new List<T>(); } }
    }
}
