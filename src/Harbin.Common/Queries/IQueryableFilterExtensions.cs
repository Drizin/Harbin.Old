using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Harbin.Common.Queries
{
    /// <summary>
    /// Extensions that can be used to filter IQueryable{T} using Linq Expressions that can be translated into SQL.
    /// Should extend IQueryable{Entity} (and return same type), since they are FILTER methods that can be combined with other filters.
    /// </summary>
    public static class IQueryableFilterExtensions
    {

        #region Filter Methods
        //http://stackoverflow.com/questions/19052507/how-to-use-a-func-in-an-expression-with-linq-to-entity-framework

        /// <summary>
        /// Filters by the Property value. Filter records in which property IS IN the given LIST
        /// Sample usage: contacts.Contains(x => x.ContactTypeID, new List{int}() { 1, 2, 3 } )
        /// </summary>
        /// <typeparam name="E">Entity type which being filtered</typeparam>
        /// <typeparam name="U">Underlying type</typeparam>
        /// <param name="entities">Entities to filter</param>
        /// <param name="propertySelector">Property which value should be contained in list</param>
        /// <param name="values">List of possible values</param>
        /// <returns></returns>
        public static IQueryable<E> WherePropertyIn<E, U>(this IQueryable<E> entities, Expression<Func<E, U>> propertySelector, ICollection<U> values)
        {
            var property = (System.Reflection.PropertyInfo)((MemberExpression)propertySelector.Body).Member;
            var expression = EFExpressions.CreateInExpression<E, U>(property, values);
            return entities.Where(expression);
        }

        /// <summary>
        /// Filters by the Property value. Filter records in which property is NOT IN the given LIST
        /// Sample usage: contacts.Contains(x => x.ContactTypeID, new List{int}() { 1, 3 } )
        /// </summary>
        /// <typeparam name="E">Entity type which being filtered</typeparam>
        /// <typeparam name="U">Underlying type</typeparam>
        /// <param name="propertySelector">Property which value should be contained in list</param>
        /// <param name="values">List of possible values</param>
        /// <param name="entities">Entities to filter</param>
        /// <returns></returns>
        public static IQueryable<E> WherePropertyNotIn<E, U>(this IQueryable<E> entities, Expression<Func<E, U>> propertySelector, ICollection<U> values)
        {
            var property = (System.Reflection.PropertyInfo)((MemberExpression)propertySelector.Body).Member;
            var expression = EFExpressions.CreateNotInExpression<E, U>(property, values);
            return entities.Where(expression);
        }


        #endregion
    }
}
