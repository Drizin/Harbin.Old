using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Harbin.Common.TypeSafeEnums
{
    public static class TypeSafeEnumHelper
    {
        /// <summary>
        /// If type is concrete implementation of TypeSafeEnum{TSE, U}, EVEN if it's a specialization (derived of another concrete implementation)
        /// </summary>
        /// <returns></returns>
        public static bool IsTypeSafeEnum(this Type type)
        {
            return (!type.IsInterface && !type.IsAbstract && General.ReflectionHelper.IsSubclassOfGeneric(typeof(TypeSafeEnum<,>), type));
        }

        /// <summary>
        /// If type is concrete implementation of TypeSafeEnum{TSE, U}, and is not derived from another concrete implementation
        /// This means that this TypeSafeEnum{TSE, U} is "top level" enum, responsible for tracking all possible values (enum members) of all instances of itself or of any child
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsTopLevelTypeSafeEnum(this Type type)
        {
            return IsTypeSafeEnum(type) && type.BaseType != null && !IsTypeSafeEnum(type.BaseType);
        }


        /// <summary>
        /// Returns all "Top-Level" Type-Safe-Enums of an assembly
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetTopLevelTypeSafeEnums(this Assembly assembly)
        {
            // non-abstract classes which implement TypeSafeEnum<TSE, U>, except their children (derived classes of another non-abstract classes which implement TypeSafeEnum<TSE, U>)
            var typeSafeEnums = assembly.GetTypes().Where(type => IsTopLevelTypeSafeEnum(type));
            return typeSafeEnums;
        }

    }
}
