using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Harbin.Common.TypeSafeEnums
{
    /// <summary>
    /// Query Extensions for Entities that have Properties which implement TypeSafeEnum
    /// Extensions should extend the IQueryable{Entity} (and return same type) if they are FILTER methods that can be combined with other filters.
    /// Extensions should extend the DbSet{Entity} (and return Entity) if they are FIND methods that return a single instance or null (use Single or SingleOrDefault accordingly)
    /// </summary>
    public static class TypeSafeEnumsQueryExtensions
    {
        #region Filter Methods
        /// <summary>
        /// Filters by the Type-Safe Enum value. Filter records in which enum IS IN the given LIST
        /// </summary>
        /// <typeparam name="E">Entity being filtered</typeparam>
        /// <typeparam name="TSE">Type-Safe Enum class</typeparam>
        /// <typeparam name="U">Type-Safe Enum Underlying Key</typeparam>
        /// <param name="entities">Entities to filter. E.g. IQueryable{BusinessEntityContact}</param>
        /// <param name="entityPropertySelector">Should point from an entity to a TypeSafeEnum property. E.g. "c => ContactTypeEnum"</param>
        /// <param name="values">Should give the list of <typeparamref name="TSE"/> records for comparison. E.g. new ContactTypeEnum[] { ContactTypeEnum.ACCOUNTING_MANAGER, ContactTypeEnum.ASSISTANT_SALES_AGENT } </param>
        /// <returns></returns>
        public static IQueryable<E> WhereEnumIn<E, TSE, U>(this IQueryable<E> entities, Expression<Func<E, TSE>> entityPropertySelector, ICollection<TSE> values)
            where E : class //IEntity?
            where TSE : TypeSafeEnum<TSE, U>
            where U : IEquatable<U>, IComparable<U>
        {
            var expression = TypeSafeEnumsQueryHelper.CreateInExpression<E, TSE, U>(entityPropertySelector, values);
            return entities.Where(expression);
        }

        /// <summary>
        /// Filters by the Type-Safe Enum value. Filter records in which enum is NOT IN the given LIST
        /// </summary>
        /// <typeparam name="E">Entity type which being filtered</typeparam>
        /// <typeparam name="TSE">Type-Safe Enum class</typeparam>
        /// <typeparam name="U">Type-Safe Enum Underlying Key</typeparam>
        /// <param name="entities">Entities to filter. E.g. IQueryable{BusinessEntityContact}</param>
        /// <param name="entityPropertySelector">Should point from an entity to a TypeSafeEnum property. E.g. "c => ContactTypeEnum"</param>
        /// <param name="values">Should give the list of <typeparamref name="TSE"/> records for comparison. E.g. new ContactTypeEnum[] { ContactTypeEnum.ACCOUNTING_MANAGER, ContactTypeEnum.ASSISTANT_SALES_AGENT } </param>
        /// <returns></returns>
        public static IQueryable<E> WhereEnumNotIn<E, TSE, U>(this IQueryable<E> entities, Expression<Func<E, TSE>> entityPropertySelector, ICollection<TSE> values)
            where E : class //IEntity?
            where TSE : TypeSafeEnum<TSE, U>
            where U : IEquatable<U>, IComparable<U>
        {
            var expression = TypeSafeEnumsQueryHelper.CreateNotInExpression<E, TSE, U>(entityPropertySelector, values);
            return entities.Where(expression);
        }

        /// <summary>
        /// Filters by the Type-Safe Enum value. Filter according to any condition
        /// </summary>
        /// <typeparam name="E">Entity type which being filtered</typeparam>
        /// <typeparam name="TSE">Type-Safe Enum class</typeparam>
        /// <typeparam name="U">Type-Safe Enum Underlying Key</typeparam>
        /// <param name="entities">Entities to filter. E.g. IQueryable{BusinessEntityContact}</param>
        /// <param name="entityPropertySelector">Should point from an entity to a TypeSafeEnum property. E.g. "c => ContactTypeEnum"</param>
        /// <param name="predicate">Filter condition. E.g. "ct => ct.SomeProperty==true"</param>
        /// <returns></returns>
        public static IQueryable<E> WhereEnum<E, TSE, U>(this IQueryable<E> entities, Expression<Func<E, TypeSafeEnum<TSE, U>>> entityPropertySelector, Func<TSE, bool> predicate)
            where E : class //IEntity?
            where TSE : TypeSafeEnum<TSE, U>
            where U : IEquatable<U>, IComparable<U>
        {
            var entityPropertySelector2 = TypeSafeEnumsQueryHelper.Unwrap(entityPropertySelector);
            var expression = TypeSafeEnumsQueryHelper.CreateExpression<E, TSE, U>(entityPropertySelector2, predicate);
            return entities.Where(expression);
        }
        #endregion

        #region Find Methods
        #endregion

    }
}
