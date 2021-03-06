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

    // vProductAndDescription
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class VProductAndDescription
    {
        public int? ProductId { get; set; } // ProductID (Primary key)
        public string Name { get; set; } // Name (Primary key) (length: 50)
        public string ProductModel { get; set; } // ProductModel (Primary key) (length: 50)
        public string CultureId { get; set; } // CultureID (Primary key) (length: 6)
        public string Description { get; set; } // Description (Primary key) (length: 400)
        public VProductAndDescription()
        {
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
