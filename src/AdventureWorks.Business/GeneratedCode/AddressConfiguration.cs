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

    // Address
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class AddressConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Address>
    {
        public AddressConfiguration() : this("Person")
        {
        }

        public AddressConfiguration(string schema)
        {
            ToTable("Address", schema);
            HasKey(x => x.AddressId);

            Property(x => x.AddressId).HasColumnName(@"AddressID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.AddressLine1).HasColumnName(@"AddressLine1").HasColumnType("nvarchar").IsRequired().HasMaxLength(60);
            Property(x => x.AddressLine2).HasColumnName(@"AddressLine2").HasColumnType("nvarchar").IsOptional().HasMaxLength(60);
            Property(x => x.City).HasColumnName(@"City").HasColumnType("nvarchar").IsRequired().HasMaxLength(30);
            Property(x => x.StateProvinceId).HasColumnName(@"StateProvinceID").HasColumnType("int").IsRequired();
            Property(x => x.PostalCode).HasColumnName(@"PostalCode").HasColumnType("nvarchar").IsRequired().HasMaxLength(15);
            Property(x => x.SpatialLocation).HasColumnName(@"SpatialLocation").HasColumnType("geography").IsOptional();
            Property(x => x.Rowguid).HasColumnName(@"rowguid").HasColumnType("uniqueidentifier").IsRequired();
            Property(x => x.ModifiedDate).HasColumnName(@"ModifiedDate").HasColumnType("datetime").IsRequired();

            // Foreign keys
            HasRequired(a => a.StateProvince).WithMany(b => b.Addresses).HasForeignKey(c => c.StateProvinceId).WillCascadeOnDelete(false); // FK_Address_StateProvince_StateProvinceID
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>