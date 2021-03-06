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

    // vSalesPersonSalesByFiscalYears
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class VSalesPersonSalesByFiscalYear
    {
        public int? SalesPersonId { get; set; } // SalesPersonID
        public string FullName { get; set; } // FullName (length: 152)
        public string JobTitle { get; set; } // JobTitle (Primary key) (length: 50)
        public string SalesTerritory { get; set; } // SalesTerritory (Primary key) (length: 50)
        public decimal? C2002 { get; set; } // 2002
        public decimal? C2003 { get; set; } // 2003
        public decimal? C2004 { get; set; } // 2004
        public VSalesPersonSalesByFiscalYear()
        {
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
