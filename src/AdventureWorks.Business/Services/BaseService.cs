using AdventureWorks.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Services
{
    public abstract class BaseService
    {
        #region Dependencies (Constructor-Injected Properties are mandatory dependencies)
        protected IAdventureWorksDB AdventureWorksDb { get; set; }
        protected AdventureWorksAppSettings AppSettings { get; set; }
        #endregion
        public BaseService(IAdventureWorksDB adventureWorksDb, AdventureWorksAppSettings appSettings)
        {
            this.AdventureWorksDb = adventureWorksDb;
            this.AppSettings = appSettings;
        }

    }
}
