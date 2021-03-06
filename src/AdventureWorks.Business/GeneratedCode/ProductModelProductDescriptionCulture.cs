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

    // ProductModelProductDescriptionCulture
        ///<summary>
        /// Cross-reference table mapping product descriptions and the language the description is written in.
        ///</summary>
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class ProductModelProductDescriptionCulture
    {

        ///<summary>
        /// Primary key. Foreign key to ProductModel.ProductModelID.
        ///</summary>
        public int? ProductModelId { get; set; } // ProductModelID (Primary key)

        ///<summary>
        /// Primary key. Foreign key to ProductDescription.ProductDescriptionID.
        ///</summary>
        public int? ProductDescriptionId { get; set; } // ProductDescriptionID (Primary key)

        ///<summary>
        /// Culture identification number. Foreign key to Culture.CultureID.
        ///</summary>
        public string CultureId { get; set; } // CultureID (Primary key) (length: 6)

        ///<summary>
        /// Date and time the record was last updated.
        ///</summary>
        public System.DateTime ModifiedDate { get; set; } // ModifiedDate

        // Foreign keys

        /// <summary>
        /// Parent Culture pointed by [ProductModelProductDescriptionCulture].([CultureId]) (FK_ProductModelProductDescriptionCulture_Culture_CultureID)
        /// </summary>
        public virtual Culture Culture { get; set; } // FK_ProductModelProductDescriptionCulture_Culture_CultureID

        /// <summary>
        /// Parent ProductDescription pointed by [ProductModelProductDescriptionCulture].([ProductDescriptionId]) (FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID)
        /// </summary>
        public virtual ProductDescription ProductDescription { get; set; } // FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID

        /// <summary>
        /// Parent ProductModel pointed by [ProductModelProductDescriptionCulture].([ProductModelId]) (FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID)
        /// </summary>
        public virtual ProductModel ProductModel { get; set; } // FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID

        public ProductModelProductDescriptionCulture()
        {
            ModifiedDate = System.DateTime.Now;
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
