using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTemplateBrowser
{
    internal class TypeComparer : IComparer<Type>
    {
        public int Compare(Type? x, Type? y)
        {
            return string.Compare(x.GetType().Name, y.GetType().Name, StringComparison.OrdinalIgnoreCase);
        }
    }
}
