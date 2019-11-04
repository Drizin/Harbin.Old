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

    // CountryRegionCurrency
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class CountryRegionCurrencyConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CountryRegionCurrency>
    {
        public CountryRegionCurrencyConfiguration() : this("Sales")
        {
        }

        public CountryRegionCurrencyConfiguration(string schema)
        {
            ToTable("CountryRegionCurrency", schema);
            HasKey(x => new { x.CountryRegionCode, x.CurrencyCode });

            Property(x => x.CountryRegionCode).HasColumnName(@"CountryRegionCode").HasColumnType("nvarchar").IsRequired().HasMaxLength(3).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.CurrencyCode).HasColumnName(@"CurrencyCode").HasColumnType("nchar").IsRequired().IsFixedLength().HasMaxLength(3).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.ModifiedDate).HasColumnName(@"ModifiedDate").HasColumnType("datetime").IsRequired();

            // Foreign keys
            HasRequired(a => a.CountryRegion).WithMany(b => b.CountryRegionCurrencies).HasForeignKey(c => c.CountryRegionCode).WillCascadeOnDelete(false); // FK_CountryRegionCurrency_CountryRegion_CountryRegionCode
            HasRequired(a => a.Currency).WithMany(b => b.CountryRegionCurrencies).HasForeignKey(c => c.CurrencyCode).WillCascadeOnDelete(false); // FK_CountryRegionCurrency_Currency_CurrencyCode
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
