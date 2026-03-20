using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctaPro.Utils
{
    public static class ObjectExtensions
    {
        public static bool IsEmpty(this object value)
            {
                if (value == null) return true;

                switch (value)
                {
                    case string str:
                        return string.IsNullOrWhiteSpace(str);

                    case int i:
                        return i == 0;

                    case long l:
                        return l == 0;

                    case double d:
                        return d == 0.0;

                    case float f:
                        return f == 0.0f;

                    case decimal m:
                        return m == 0.0m;

                    case bool b:
                        return b == false;

                    case IEnumerable enumerable:
                        return !enumerable.Cast<object>().Any();

                    default:
                        return false;
                }
            }
    }
}