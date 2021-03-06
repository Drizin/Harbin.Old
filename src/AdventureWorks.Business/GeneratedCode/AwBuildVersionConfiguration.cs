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

    // AWBuildVersion
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class AwBuildVersionConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<AwBuildVersion>
    {
        public AwBuildVersionConfiguration() : this("dbo")
        {
        }

        public AwBuildVersionConfiguration(string schema)
        {
            ToTable("AWBuildVersion", schema);
            HasKey(x => x.SystemInformationId);

            Property(x => x.SystemInformationId).HasColumnName(@"SystemInformationID").HasColumnType("tinyint").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.DatabaseVersion).HasColumnName(@"Database Version").HasColumnType("nvarchar").IsRequired().HasMaxLength(25);
            Property(x => x.VersionDate).HasColumnName(@"VersionDate").HasColumnType("datetime").IsRequired();
            Property(x => x.ModifiedDate).HasColumnName(@"ModifiedDate").HasColumnType("datetime").IsRequired();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
