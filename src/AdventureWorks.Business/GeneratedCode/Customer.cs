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

    // Customer
        ///<summary>
        /// Current customer information. Also see the Person and Store tables.
        ///</summary>
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class Customer
    {

        ///<summary>
        /// Primary key.
        ///</summary>
        public int? CustomerId { get; set; } // CustomerID (Primary key)

        ///<summary>
        /// Foreign key to Person.BusinessEntityID
        ///</summary>
        public int? PersonId { get; set; } // PersonID

        ///<summary>
        /// Foreign key to Store.BusinessEntityID
        ///</summary>
        public int? StoreId { get; set; } // StoreID

        ///<summary>
        /// ID of the territory in which the customer is located. Foreign key to SalesTerritory.SalesTerritoryID.
        ///</summary>
        public int? TerritoryId { get; set; } // TerritoryID

        ///<summary>
        /// Unique number identifying the customer assigned by the accounting system.
        ///</summary>
        public string AccountNumber { get; private set; } // AccountNumber (length: 10)

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
        /// Child SalesOrderHeaders where [SalesOrderHeader].[CustomerID] point to this entity (FK_SalesOrderHeader_Customer_CustomerID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } // SalesOrderHeader.FK_SalesOrderHeader_Customer_CustomerID


        // Foreign keys

        /// <summary>
        /// Parent Person pointed by [Customer].([PersonId]) (FK_Customer_Person_PersonID)
        /// </summary>
        public virtual Person Person { get; set; } // FK_Customer_Person_PersonID

        /// <summary>
        /// Parent SalesTerritory pointed by [Customer].([TerritoryId]) (FK_Customer_SalesTerritory_TerritoryID)
        /// </summary>
        public virtual SalesTerritory SalesTerritory { get; set; } // FK_Customer_SalesTerritory_TerritoryID

        /// <summary>
        /// Parent Store pointed by [Customer].([StoreId]) (FK_Customer_Store_StoreID)
        /// </summary>
        public virtual Store Store { get; set; } // FK_Customer_Store_StoreID

        public Customer()
        {
            Rowguid = System.Guid.NewGuid();
            ModifiedDate = System.DateTime.Now;
            SalesOrderHeaders = new System.Collections.Generic.List<SalesOrderHeader>();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
