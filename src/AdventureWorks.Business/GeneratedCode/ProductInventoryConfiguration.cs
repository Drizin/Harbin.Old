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

    // ProductInventory
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class ProductInventoryConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ProductInventory>
    {
        public ProductInventoryConfiguration() : this("Production")
        {
        }

        public ProductInventoryConfiguration(string schema)
        {
            ToTable("ProductInventory", schema);
            HasKey(x => new { x.ProductId, x.LocationId });

            Property(x => x.ProductId).HasColumnName(@"ProductID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.LocationId).HasColumnName(@"LocationID").HasColumnType("smallint").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Shelf).HasColumnName(@"Shelf").HasColumnType("nvarchar").IsRequired().HasMaxLength(10);
            Property(x => x.Bin).HasColumnName(@"Bin").HasColumnType("tinyint").IsRequired();
            Property(x => x.Quantity).HasColumnName(@"Quantity").HasColumnType("smallint").IsRequired();
            Property(x => x.Rowguid).HasColumnName(@"rowguid").HasColumnType("uniqueidentifier").IsRequired();
            Property(x => x.ModifiedDate).HasColumnName(@"ModifiedDate").HasColumnType("datetime").IsRequired();

            // Foreign keys
            HasRequired(a => a.Location).WithMany(b => b.ProductInventories).HasForeignKey(c => c.LocationId).WillCascadeOnDelete(false); // FK_ProductInventory_Location_LocationID
            HasRequired(a => a.Product).WithMany(b => b.ProductInventories).HasForeignKey(c => c.ProductId).WillCascadeOnDelete(false); // FK_ProductInventory_Product_ProductID
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
