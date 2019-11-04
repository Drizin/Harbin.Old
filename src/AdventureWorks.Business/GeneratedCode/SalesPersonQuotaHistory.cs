// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable EmptyNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.72
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace AdventureWorks.Business.Entities
{

    // SalesPersonQuotaHistory
        ///<summary>
        /// Sales performance tracking.
        ///</summary>
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class SalesPersonQuotaHistory
    {

        ///<summary>
        /// Sales person identification number. Foreign key to SalesPerson.BusinessEntityID.
        ///</summary>
        public int? BusinessEntityId { get; set; } // BusinessEntityID (Primary key)

        ///<summary>
        /// Sales quota date.
        ///</summary>
        public System.DateTime QuotaDate { get; set; } // QuotaDate (Primary key)

        ///<summary>
        /// Sales quota amount.
        ///</summary>
        public decimal SalesQuota { get; set; } // SalesQuota

        ///<summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        ///</summary>
        public System.Guid Rowguid { get; set; } // rowguid

        ///<summary>
        /// Date and time the record was last updated.
        ///</summary>
        public System.DateTime ModifiedDate { get; set; } // ModifiedDate

        // Foreign keys

        /// <summary>
        /// Parent SalesPerson pointed by [SalesPersonQuotaHistory].([BusinessEntityId]) (FK_SalesPersonQuotaHistory_SalesPerson_BusinessEntityID)
        /// </summary>
        public virtual SalesPerson SalesPerson { get; set; } // FK_SalesPersonQuotaHistory_SalesPerson_BusinessEntityID

        public SalesPersonQuotaHistory()
        {
            Rowguid = System.Guid.NewGuid();
            ModifiedDate = System.DateTime.Now;
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>