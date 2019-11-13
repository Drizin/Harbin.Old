using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Harbin.Common.TypeSafeEnums
{
    public class TypeSafeEnumsQueryHelper
    {
        #region Expressions (Helpers)
        /// <summary>
        /// Generates a IN (list.Contains(value)) Expression, which translates into SQL for Entity Framework
        /// </summary>
        public static Expression<Func<E, bool>> CreateInExpression<E, TSE, U>(Expression<Func<E, TSE>> propertySelector, ICollection<TSE> values)
            where E : class //IEntity?
            where TSE : TypeSafeEnum<TSE, U>
        {
            //var entityUnderlyingPropertyName = TypeSafeEnum<S, U>.UnderlyingPropertyName<E>(propertySelector);
            //var entityUnderlyingProperty = typeof(E).GetProperties().Where(x => x.Name == entityUnderlyingPropertyName).SingleOrDefault();
            var entityUnderlyingProperty = TypeSafeEnum<TSE, U>.UnderlyingProperty<E>(propertySelector);
            var propertyType = ((System.Reflection.PropertyInfo)((MemberExpression)propertySelector.Body).Member).PropertyType;
            if (propertyType != typeof(TSE))
                throw new Exception(string.Format("Expecting values of type {0}", propertyType.FullName));
            var keys = values.Select(x => x.Key).ToArray();
            var expression = Queries.QueryHelper.CreateInExpression<E, U>(entityUnderlyingProperty, keys);
            return expression;
        }
        /// <summary>
        /// Generates a NOT IN (!list.Contains(value)) Expression, which translates into SQL for Entity Framework
        /// </summary>
        public static Expression<Func<E, bool>> CreateNotInExpression<E, TSE, U>(Expression<Func<E, TSE>> propertySelector, ICollection<TSE> values)
            where E : class //IEntity?
            where TSE : TypeSafeEnum<TSE, U>
        {
            var entityUnderlyingProperty = TypeSafeEnum<TSE, U>.UnderlyingProperty<E>(propertySelector);
            var propertyType = ((System.Reflection.PropertyInfo)((MemberExpression)propertySelector.Body).Member).PropertyType;
            if (propertyType != typeof(TSE))
                throw new Exception(string.Format("Expecting values of type {0}", propertyType.FullName));
            var keys = values.Select(x => x.Key).ToArray();
            var expression = Queries.QueryHelper.CreateNotInExpression<E, U>(entityUnderlyingProperty, keys);
            return expression;
        }

        /// <summary>
        /// Generates a IN (list.Contains(value)) Expression based on the predicate, which translates into SQL for Entity Framework
        /// </summary>
        public static Expression<Func<E, bool>> CreateExpression<E, TSE, U>(Expression<Func<E, TSE>> propertySelector, Func<TSE, bool> predicate)
            where E : class //IEntity?
            where TSE : TypeSafeEnum<TSE, U>
        {
            var entityUnderlyingProperty = TypeSafeEnum<TSE, U>.UnderlyingProperty<E>(propertySelector);
            var propertyType = ((System.Reflection.PropertyInfo)((MemberExpression)propertySelector.Body).Member).PropertyType;
            if (propertyType != typeof(TSE))
                throw new Exception(string.Format("Expecting values of type {0}", propertyType.FullName));
            var allEnumValues = TypeSafeEnum<TSE, U>.GetEnumValues();
            IEnumerable<TSE> values = allEnumValues.Where(x => predicate(x)); // matching enum values
            var keys = values.Select(x => x.Key).ToArray();
            var expression = Queries.QueryHelper.CreateInExpression<E, U>(entityUnderlyingProperty, keys);
            return expression;
        }

        /// <summary>
        /// Converts a selector from Entity E to TypeSafeEnum{TSE, U} to a selector from Entity E to TSE.
        /// E.g. from "((BusinessEntityContact)e) => e.ContactTypeEnum", 
        /// </summary>
        /// <typeparam name="E">Entity type</typeparam>
        /// <typeparam name="TSE">Type-Safe Enum class</typeparam>
        /// <typeparam name="U">Type-Safe Enum Underlying Key</typeparam>
        public static Expression<Func<E, TSE>> Unwrap<E, TSE, U>(Expression<Func<E, TypeSafeEnum<TSE, U>>> propertySelector)
            where E : class //IEntity?
            where TSE : TypeSafeEnum<TSE, U>
        {
            // Converting (E => TypeSafeEnum<TSE,U>) to (E => TSE). //http://stackoverflow.com/a/27463773/3606250
            var memberName = ((MemberExpression)propertySelector.Body).Member.Name;
            var param = Expression.Parameter(typeof(E));
            var field = Expression.Property(param, memberName);
            var selector2 = Expression.Lambda<Func<E, TSE>>(field, param);
            return selector2;
        }



        #endregion

    }
}
