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

    // Culture
        ///<summary>
        /// Lookup table containing the languages in which some AdventureWorks data is stored.
        ///</summary>
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class Culture
    {

        ///<summary>
        /// Primary key for Culture records.
        ///</summary>
        public string CultureId { get; set; } // CultureID (Primary key) (length: 6)

        ///<summary>
        /// Culture description.
        ///</summary>
        public string Name { get; set; } // Name (length: 50)

        ///<summary>
        /// Date and time the record was last updated.
        ///</summary>
        public System.DateTime ModifiedDate { get; set; } // ModifiedDate

        // Reverse navigation

        /// <summary>
        /// Child ProductModelProductDescriptionCultures where [ProductModelProductDescriptionCulture].[CultureID] point to this entity (FK_ProductModelProductDescriptionCulture_Culture_CultureID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; set; } // ProductModelProductDescriptionCulture.FK_ProductModelProductDescriptionCulture_Culture_CultureID

        public Culture()
        {
            ModifiedDate = System.DateTime.Now;
            ProductModelProductDescriptionCultures = new System.Collections.Generic.List<ProductModelProductDescriptionCulture>();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
