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

    // vProductModelInstructions
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class VProductModelInstruction
    {
        public int? ProductModelId { get; set; } // ProductModelID (Primary key)
        public string Name { get; set; } // Name (Primary key) (length: 50)
        public string Instructions { get; set; } // Instructions
        public int? LocationId { get; set; } // LocationID
        public decimal? SetupHours { get; set; } // SetupHours
        public decimal? MachineHours { get; set; } // MachineHours
        public decimal? LaborHours { get; set; } // LaborHours
        public int? LotSize { get; set; } // LotSize
        public string Step { get; set; } // Step (length: 1024)
        public System.Guid Rowguid { get; set; } // rowguid (Primary key)
        public System.DateTime ModifiedDate { get; set; } // ModifiedDate (Primary key)
        public VProductModelInstruction()
        {
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
