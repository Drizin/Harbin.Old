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

    // SpecialOfferProduct
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class SpecialOfferProductConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<SpecialOfferProduct>
    {
        public SpecialOfferProductConfiguration() : this("Sales")
        {
        }

        public SpecialOfferProductConfiguration(string schema)
        {
            ToTable("SpecialOfferProduct", schema);
            HasKey(x => new { x.SpecialOfferId, x.ProductId });

            Property(x => x.SpecialOfferId).HasColumnName(@"SpecialOfferID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.ProductId).HasColumnName(@"ProductID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Rowguid).HasColumnName(@"rowguid").HasColumnType("uniqueidentifier").IsRequired();
            Property(x => x.ModifiedDate).HasColumnName(@"ModifiedDate").HasColumnType("datetime").IsRequired();

            // Foreign keys
            HasRequired(a => a.Product).WithMany(b => b.SpecialOfferProducts).HasForeignKey(c => c.ProductId).WillCascadeOnDelete(false); // FK_SpecialOfferProduct_Product_ProductID
            HasRequired(a => a.SpecialOffer).WithMany(b => b.SpecialOfferProducts).HasForeignKey(c => c.SpecialOfferId).WillCascadeOnDelete(false); // FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
