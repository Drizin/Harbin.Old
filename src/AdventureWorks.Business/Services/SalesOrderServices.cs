using AdventureWorks.Business.Entities;
using Harbin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Services
{
    public class SalesOrderServices : BaseService
    {
        #region Dependencies
        #endregion

        public SalesOrderServices(IAdventureWorksDB adventureWorksDb, AdventureWorksAppSettings appSettings) : base(adventureWorksDb, appSettings) { }

        #region Methods

        #region LaunchTenant
        public enum CreateSalesOrderResultCodeEnum
        {
            SUCCESS,
            OUT_OF_STOCK,
            OTHER_ERROR
        }

        public MethodResult<CreateSalesOrderResultCodeEnum, SalesOrderHeader> CreateSalesOrder(SalesOrderHeader order)
        {

            if (order.DueDate.Day == 3)
                return MethodResult<CreateSalesOrderResultCodeEnum, SalesOrderHeader>.CreateError(CreateSalesOrderResultCodeEnum.OUT_OF_STOCK, "[[[OUT_OF_STOCK]]]"); ;

            this.AdventureWorksDb.SalesOrderHeaders.Add(order);
            try
            {
                this.AdventureWorksDb.SaveChanges();
                return MethodResult<CreateSalesOrderResultCodeEnum, SalesOrderHeader>.CreateSuccess(CreateSalesOrderResultCodeEnum.SUCCESS, order);
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Save SalesOrder", ex);
            }
        }
        #endregion


        #endregion

    }
}
