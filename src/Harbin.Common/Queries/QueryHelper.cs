using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Harbin.Common.Queries
{
    /// <summary>
    /// LINQ Expressions that can be directly translated to Entity Framework
    /// </summary>
    public class QueryHelper
    {
        //TODO: cache these expressions? (are they expensive?)
        #region Expressions
        /// <summary>
        /// Generates a NOT IN (!list.Contains(value)) Expression, which translates into SQL for Entity Framework
        /// </summary>
        public static Expression<Func<E, bool>> CreateNotInExpression<E, U>(PropertyInfo property, ICollection<U> values)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(E));
            return Expression.Lambda<Func<E, bool>>(
                Expression.Not(
                    Expression.Call(
                        Expression.Constant(values),
                        typeof(ICollection<U>).GetMethod("Contains"),
                        Expression.Property(parameter, property)
                    )),
                parameter);
        }
        /// <summary>
        /// Generates a NOT IN (!list.Contains(value)) Expression, which translates into SQL for Entity Framework
        /// </summary>
        public static Expression<Func<E, bool>> CreateNotInExpression<E, U>(Expression<Func<E, U>> propertySelector, ICollection<U> values)
        {
            PropertyInfo property = (PropertyInfo)((MemberExpression)propertySelector.Body).Member;
            return CreateNotInExpression<E, U>(property, values);
        }
        /// <summary>
        /// Generates a IN (list.Contains(value)) Expression, which translates into SQL for Entity Framework
        /// </summary>
        public static Expression<Func<E, bool>> CreateInExpression<E, U>(PropertyInfo property, ICollection<U> values)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(E));
            return Expression.Lambda<Func<E, bool>>(
                Expression.Call(
                    Expression.Constant(values),
                    typeof(ICollection<U>).GetMethod("Contains"),
                    Expression.Property(parameter, property)
                ),
                parameter);
        }
        /// <summary>
        /// Generates a IN (list.Contains(value)) Expression, which translates into SQL for Entity Framework
        /// </summary>
        public static Expression<Func<E, bool>> CreateInExpression<E, U>(Expression<Func<E, U>> propertySelector, ICollection<U> values)
        {
            PropertyInfo property = (PropertyInfo)((MemberExpression)propertySelector.Body).Member;
            return CreateInExpression<E, U>(property, values);
        }

        #endregion

    }
}
