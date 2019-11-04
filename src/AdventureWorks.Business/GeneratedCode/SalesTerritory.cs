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

    // SalesTerritory
        ///<summary>
        /// Sales territory lookup table.
        ///</summary>
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class SalesTerritory
    {

        ///<summary>
        /// Primary key for SalesTerritory records.
        ///</summary>
        public int? TerritoryId { get; set; } // TerritoryID (Primary key)

        ///<summary>
        /// Sales territory description
        ///</summary>
        public string Name { get; set; } // Name (length: 50)

        ///<summary>
        /// ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode.
        ///</summary>
        public string CountryRegionCode { get; set; } // CountryRegionCode (length: 3)

        ///<summary>
        /// Geographic area to which the sales territory belong.
        ///</summary>
        public string Group { get; set; } // Group (length: 50)

        ///<summary>
        /// Sales in the territory year to date.
        ///</summary>
        public decimal SalesYtd { get; set; } // SalesYTD

        ///<summary>
        /// Sales in the territory the previous year.
        ///</summary>
        public decimal SalesLastYear { get; set; } // SalesLastYear

        ///<summary>
        /// Business costs in the territory year to date.
        ///</summary>
        public decimal CostYtd { get; set; } // CostYTD

        ///<summary>
        /// Business costs in the territory the previous year.
        ///</summary>
        public decimal CostLastYear { get; set; } // CostLastYear

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
        /// Child Customers where [Customer].[TerritoryID] point to this entity (FK_Customer_SalesTerritory_TerritoryID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Customer> Customers { get; set; } // Customer.FK_Customer_SalesTerritory_TerritoryID

        /// <summary>
        /// Child SalesOrderHeaders where [SalesOrderHeader].[TerritoryID] point to this entity (FK_SalesOrderHeader_SalesTerritory_TerritoryID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } // SalesOrderHeader.FK_SalesOrderHeader_SalesTerritory_TerritoryID

        /// <summary>
        /// Child SalesPeople where [SalesPerson].[TerritoryID] point to this entity (FK_SalesPerson_SalesTerritory_TerritoryID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<SalesPerson> SalesPeople { get; set; } // SalesPerson.FK_SalesPerson_SalesTerritory_TerritoryID

        /// <summary>
        /// Child SalesTerritoryHistories where [SalesTerritoryHistory].[TerritoryID] point to this entity (FK_SalesTerritoryHistory_SalesTerritory_TerritoryID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<SalesTerritoryHistory> SalesTerritoryHistories { get; set; } // SalesTerritoryHistory.FK_SalesTerritoryHistory_SalesTerritory_TerritoryID

        /// <summary>
        /// Child StateProvinces where [StateProvince].[TerritoryID] point to this entity (FK_StateProvince_SalesTerritory_TerritoryID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<StateProvince> StateProvinces { get; set; } // StateProvince.FK_StateProvince_SalesTerritory_TerritoryID


        // Foreign keys

        /// <summary>
        /// Parent CountryRegion pointed by [SalesTerritory].([CountryRegionCode]) (FK_SalesTerritory_CountryRegion_CountryRegionCode)
        /// </summary>
        public virtual CountryRegion CountryRegion { get; set; } // FK_SalesTerritory_CountryRegion_CountryRegionCode

        public SalesTerritory()
        {
            SalesYtd = 0.00m;
            SalesLastYear = 0.00m;
            CostYtd = 0.00m;
            CostLastYear = 0.00m;
            Rowguid = System.Guid.NewGuid();
            ModifiedDate = System.DateTime.Now;
            Customers = new System.Collections.Generic.List<Customer>();
            SalesOrderHeaders = new System.Collections.Generic.List<SalesOrderHeader>();
            SalesPeople = new System.Collections.Generic.List<SalesPerson>();
            SalesTerritoryHistories = new System.Collections.Generic.List<SalesTerritoryHistory>();
            StateProvinces = new System.Collections.Generic.List<StateProvince>();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>