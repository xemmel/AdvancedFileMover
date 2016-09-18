using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedFileMover.Helpers
{
    public static class Extensions
    {
        public static void RemoveLast<T>(this List<T> list)
        {
            if ((list != null) && (list.Count > 0))
            {
                int lastIndex = list.Count - 1;
                list.RemoveAt(lastIndex);
            }

        }
    }
}
