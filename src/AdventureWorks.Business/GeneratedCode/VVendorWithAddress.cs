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

    // vVendorWithAddresses
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class VVendorWithAddress
    {
        public int? BusinessEntityId { get; set; } // BusinessEntityID (Primary key)
        public string Name { get; set; } // Name (Primary key) (length: 50)
        public string AddressType { get; set; } // AddressType (Primary key) (length: 50)
        public string AddressLine1 { get; set; } // AddressLine1 (Primary key) (length: 60)
        public string AddressLine2 { get; set; } // AddressLine2 (length: 60)
        public string City { get; set; } // City (Primary key) (length: 30)
        public string StateProvinceName { get; set; } // StateProvinceName (Primary key) (length: 50)
        public string PostalCode { get; set; } // PostalCode (Primary key) (length: 15)
        public string CountryRegionName { get; set; } // CountryRegionName (Primary key) (length: 50)
        public VVendorWithAddress()
        {
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
