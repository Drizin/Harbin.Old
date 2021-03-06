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

    // BusinessEntityAddress
        ///<summary>
        /// Cross-reference table mapping customers, vendors, and employees to their addresses.
        ///</summary>
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class BusinessEntityAddress
    {

        ///<summary>
        /// Primary key. Foreign key to BusinessEntity.BusinessEntityID.
        ///</summary>
        public int? BusinessEntityId { get; set; } // BusinessEntityID (Primary key)

        ///<summary>
        /// Primary key. Foreign key to Address.AddressID.
        ///</summary>
        public int? AddressId { get; set; } // AddressID (Primary key)

        ///<summary>
        /// Primary key. Foreign key to AddressType.AddressTypeID.
        ///</summary>
        public int? AddressTypeId { get; set; } // AddressTypeID (Primary key)

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
        /// Parent Address pointed by [BusinessEntityAddress].([AddressId]) (FK_BusinessEntityAddress_Address_AddressID)
        /// </summary>
        public virtual Address Address { get; set; } // FK_BusinessEntityAddress_Address_AddressID

        /// <summary>
        /// Parent AddressType pointed by [BusinessEntityAddress].([AddressTypeId]) (FK_BusinessEntityAddress_AddressType_AddressTypeID)
        /// </summary>
        public virtual AddressType AddressType { get; set; } // FK_BusinessEntityAddress_AddressType_AddressTypeID

        /// <summary>
        /// Parent BusinessEntity pointed by [BusinessEntityAddress].([BusinessEntityId]) (FK_BusinessEntityAddress_BusinessEntity_BusinessEntityID)
        /// </summary>
        public virtual BusinessEntity BusinessEntity { get; set; } // FK_BusinessEntityAddress_BusinessEntity_BusinessEntityID

        public BusinessEntityAddress()
        {
            Rowguid = System.Guid.NewGuid();
            ModifiedDate = System.DateTime.Now;
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
