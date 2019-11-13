using System;
using System.Collections.Generic;
using System.Text;

namespace Harbin.Common.General
{
    public class ReflectionHelper
    {
        /// <summary>
        /// Checks if type "toCheck" is subclass of generic type "generic".
        /// E.g. IsSubclassOfRawGeneric(typeof(List{}), typeof(List{int}))
        /// </summary>
        /// <param name="generic"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool IsSubclassOfGeneric(Type generic, Type toCheck)
        {
            // From https://stackoverflow.com/a/457708/3606250
            while (toCheck != null && toCheck != typeof(object))
            {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur)
                {
                    return true;
                }
                toCheck = toCheck.BaseType;
            }
            return false;
        }
    }
}
