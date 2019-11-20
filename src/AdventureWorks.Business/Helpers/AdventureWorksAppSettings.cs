using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business
{
    /// <summary>
    /// AppSettings for AdventureWorks.Business
    /// </summary>
    // Injected like https://dev.to/justinjstark/injecting-configuration-variables-into-components-4knh
    // Another alternative would be using each variable in a primitive - https://lucax88x.github.io/2016/11/21/2016-11-21-primitive-obsession/
    public class AdventureWorksAppSettings
    {
        #region Members
        public string DBConnectionString { get; set; }
        #endregion
        public AdventureWorksAppSettings(string dbConnectionString)
        {
            this.DBConnectionString = dbConnectionString;
        }
    }
}
