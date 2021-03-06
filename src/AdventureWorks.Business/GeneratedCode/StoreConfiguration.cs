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

    // Store
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class StoreConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Store>
    {
        public StoreConfiguration() : this("Sales")
        {
        }

        public StoreConfiguration(string schema)
        {
            ToTable("Store", schema);
            HasKey(x => x.BusinessEntityId);

            Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(x => x.SalesPersonId).HasColumnName(@"SalesPersonID").HasColumnType("int").IsOptional();
            Property(x => x.Demographics).HasColumnName(@"Demographics").HasColumnType("xml").IsOptional();
            Property(x => x.Rowguid).HasColumnName(@"rowguid").HasColumnType("uniqueidentifier").IsRequired();
            Property(x => x.ModifiedDate).HasColumnName(@"ModifiedDate").HasColumnType("datetime").IsRequired();

            // Foreign keys
            HasOptional(a => a.SalesPerson).WithMany(b => b.Stores).HasForeignKey(c => c.SalesPersonId).WillCascadeOnDelete(false); // FK_Store_SalesPerson_SalesPersonID
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
