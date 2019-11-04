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

    // SalesPerson
        ///<summary>
        /// Sales representative current information.
        ///</summary>
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class SalesPerson : BusinessEntity
    {

        ///<summary>
        /// Territory currently assigned to. Foreign key to SalesTerritory.SalesTerritoryID.
        ///</summary>
        public int? TerritoryId { get; set; } // TerritoryID

        ///<summary>
        /// Projected yearly sales.
        ///</summary>
        public decimal? SalesQuota { get; set; } // SalesQuota

        ///<summary>
        /// Bonus due if quota is met.
        ///</summary>
        public decimal Bonus { get; set; } // Bonus

        ///<summary>
        /// Commision percent received per sale.
        ///</summary>
        public decimal CommissionPct { get; set; } // CommissionPct

        ///<summary>
        /// Sales total year to date.
        ///</summary>
        public decimal SalesYtd { get; set; } // SalesYTD

        ///<summary>
        /// Sales total of previous year.
        ///</summary>
        public decimal SalesLastYear { get; set; } // SalesLastYear

        ///<summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        ///</summary>
        public System.Guid Rowguid { get; set; } // rowguid

        ///<summary>
        /// Date and time the record was last updated.
        ///</summary>
        public System.DateTime ModifiedDate { get; set; } // ModifiedDate

        // Reverse navigation

        /// <summary>
        /// Child SalesOrderHeaders where [SalesOrderHeader].[SalesPersonID] point to this entity (FK_SalesOrderHeader_SalesPerson_SalesPersonID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } // SalesOrderHeader.FK_SalesOrderHeader_SalesPerson_SalesPersonID

        /// <summary>
        /// Child SalesPersonQuotaHistories where [SalesPersonQuotaHistory].[BusinessEntityID] point to this entity (FK_SalesPersonQuotaHistory_SalesPerson_BusinessEntityID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<SalesPersonQuotaHistory> SalesPersonQuotaHistories { get; set; } // SalesPersonQuotaHistory.FK_SalesPersonQuotaHistory_SalesPerson_BusinessEntityID

        /// <summary>
        /// Child SalesTerritoryHistories where [SalesTerritoryHistory].[BusinessEntityID] point to this entity (FK_SalesTerritoryHistory_SalesPerson_BusinessEntityID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<SalesTerritoryHistory> SalesTerritoryHistories { get; set; } // SalesTerritoryHistory.FK_SalesTerritoryHistory_SalesPerson_BusinessEntityID

        /// <summary>
        /// Child Stores where [Store].[SalesPersonID] point to this entity (FK_Store_SalesPerson_SalesPersonID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Store> Stores { get; set; } // Store.FK_Store_SalesPerson_SalesPersonID


        // Foreign keys

        /// <summary>
        /// Parent SalesTerritory pointed by [SalesPerson].([TerritoryId]) (FK_SalesPerson_SalesTerritory_TerritoryID)
        /// </summary>
        public virtual SalesTerritory SalesTerritory { get; set; } // FK_SalesPerson_SalesTerritory_TerritoryID

        public SalesPerson()
        {
            Bonus = 0.00m;
            CommissionPct = 0.00m;
            SalesYtd = 0.00m;
            SalesLastYear = 0.00m;
            Rowguid = System.Guid.NewGuid();
            ModifiedDate = System.DateTime.Now;
            SalesOrderHeaders = new System.Collections.Generic.List<SalesOrderHeader>();
            SalesPersonQuotaHistories = new System.Collections.Generic.List<SalesPersonQuotaHistory>();
            SalesTerritoryHistories = new System.Collections.Generic.List<SalesTerritoryHistory>();
            Stores = new System.Collections.Generic.List<Store>();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
