using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Entities
{
    public static class SalesOrderHeaderQueryExtensions
    {
        #region Filter Methods - can be combined with other filters - should extend the IQueryable<Entity> (and return same type)
        /// <summary>
        /// Filters by a type-safe ship method, but converting to int so that EF can pass the filter to SQL Server query
        /// </summary>
        /// <returns></returns>
        public static IQueryable<SalesOrderHeader> FilterByShipMethod(this IQueryable<SalesOrderHeader> orders, ShipMethodEnum shipMethod)
        {
            return orders.Where(x => x.ShipMethodId == shipMethod.Key);
        }

        /// <summary>
        /// Filters by OrderDate Fiscal Year, but converting year int into a date range so that EF can pass the filter to SQL Server query
        /// </summary>
        /// <returns></returns>
        public static IQueryable<SalesOrderHeader> FilterByFiscalYear(this IQueryable<SalesOrderHeader> orders, int year)
        {
            DateTime startDate = new DateTime(year, 1, 1);
            DateTime endDate = new DateTime(year + 1, 1, 1);
            return orders.Where(x => x.OrderDate >= startDate && x.OrderDate < endDate);
        }
        #endregion

        #region Find Methods - should extend the DbSet<Entity> (and return Entity) - return a single instance or null (use Single or SingleOrDefault accordingly)

        public static SalesOrderHeader FindByID(this DbSet<SalesOrderHeader> orders, int salesOrderId)
        {
            return orders.SingleOrDefault(x => x.SalesOrderId == salesOrderId);
        }
        #endregion

    }
}
