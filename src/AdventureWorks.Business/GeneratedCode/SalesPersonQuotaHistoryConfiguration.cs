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

    // SalesPersonQuotaHistory
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class SalesPersonQuotaHistoryConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<SalesPersonQuotaHistory>
    {
        public SalesPersonQuotaHistoryConfiguration() : this("Sales")
        {
        }

        public SalesPersonQuotaHistoryConfiguration(string schema)
        {
            ToTable("SalesPersonQuotaHistory", schema);
            HasKey(x => new { x.BusinessEntityId, x.QuotaDate });

            Property(x => x.BusinessEntityId).HasColumnName(@"BusinessEntityID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.QuotaDate).HasColumnName(@"QuotaDate").HasColumnType("datetime").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.SalesQuota).HasColumnName(@"SalesQuota").HasColumnType("money").IsRequired().HasPrecision(19,4);
            Property(x => x.Rowguid).HasColumnName(@"rowguid").HasColumnType("uniqueidentifier").IsRequired();
            Property(x => x.ModifiedDate).HasColumnName(@"ModifiedDate").HasColumnType("datetime").IsRequired();

            // Foreign keys
            HasRequired(a => a.SalesPerson).WithMany(b => b.SalesPersonQuotaHistories).HasForeignKey(c => c.BusinessEntityId).WillCascadeOnDelete(false); // FK_SalesPersonQuotaHistory_SalesPerson_BusinessEntityID
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>