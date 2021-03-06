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

    // vPersonDemographics
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class VPersonDemographicConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<VPersonDemographic>
    {
        public VPersonDemographicConfiguration() : this("Sales")
        {
        }

        public VPersonDemographicConfiguration(string schema)
        {
            ToTable("vPersonDemographics", schema);
            HasKey(x => x.BusinessEntityId);

            Property(x => x.BusinessEntityId).HasColumnName(@"BusinessEntityID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.TotalPurchaseYtd).HasColumnName(@"TotalPurchaseYTD").HasColumnType("money").IsOptional().HasPrecision(19,4);
            Property(x => x.DateFirstPurchase).HasColumnName(@"DateFirstPurchase").HasColumnType("datetime").IsOptional();
            Property(x => x.BirthDate).HasColumnName(@"BirthDate").HasColumnType("datetime").IsOptional();
            Property(x => x.MaritalStatus).HasColumnName(@"MaritalStatus").HasColumnType("nvarchar").IsOptional().HasMaxLength(1);
            Property(x => x.YearlyIncome).HasColumnName(@"YearlyIncome").HasColumnType("nvarchar").IsOptional().HasMaxLength(30);
            Property(x => x.Gender).HasColumnName(@"Gender").HasColumnType("nvarchar").IsOptional().HasMaxLength(1);
            Property(x => x.TotalChildren).HasColumnName(@"TotalChildren").HasColumnType("int").IsOptional();
            Property(x => x.NumberChildrenAtHome).HasColumnName(@"NumberChildrenAtHome").HasColumnType("int").IsOptional();
            Property(x => x.Education).HasColumnName(@"Education").HasColumnType("nvarchar").IsOptional().HasMaxLength(30);
            Property(x => x.Occupation).HasColumnName(@"Occupation").HasColumnType("nvarchar").IsOptional().HasMaxLength(30);
            Property(x => x.HomeOwnerFlag).HasColumnName(@"HomeOwnerFlag").HasColumnType("bit").IsOptional();
            Property(x => x.NumberCarsOwned).HasColumnName(@"NumberCarsOwned").HasColumnType("int").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
