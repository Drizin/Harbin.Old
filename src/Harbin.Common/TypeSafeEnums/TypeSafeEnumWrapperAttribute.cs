using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Harbin.Common.TypeSafeEnums
{
    #region TypeSafeEnumAttribute
    /// <summary>
    /// Apply this to TypeSafeEnums, pointing to the underlying property, so that EF Filter Extensions can filter by the Enum translating into a filter on the underlying property
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class TypeSafeEnumWrapperAttribute : Attribute
    {
        public string UnderlyingProperty { get; set; }
    }
    #endregion
}
