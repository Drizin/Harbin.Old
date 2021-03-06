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

    // vEmployeeDepartment
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class VEmployeeDepartment
    {
        public int? BusinessEntityId { get; set; } // BusinessEntityID (Primary key)
        public string Title { get; set; } // Title (length: 8)
        public string FirstName { get; set; } // FirstName (Primary key) (length: 50)
        public string MiddleName { get; set; } // MiddleName (length: 50)
        public string LastName { get; set; } // LastName (Primary key) (length: 50)
        public string Suffix { get; set; } // Suffix (length: 10)
        public string JobTitle { get; set; } // JobTitle (Primary key) (length: 50)
        public string Department { get; set; } // Department (Primary key) (length: 50)
        public string GroupName { get; set; } // GroupName (Primary key) (length: 50)
        public System.DateTime StartDate { get; set; } // StartDate (Primary key)
        public VEmployeeDepartment()
        {
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
