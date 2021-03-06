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
        ///<summary>
        /// Cross-reference table mapping products to special offer discounts.
        ///</summary>
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class SpecialOfferProduct
    {

        ///<summary>
        /// Primary key for SpecialOfferProduct records.
        ///</summary>
        public int? SpecialOfferId { get; set; } // SpecialOfferID (Primary key)

        ///<summary>
        /// Product identification number. Foreign key to Product.ProductID.
        ///</summary>
        public int? ProductId { get; set; } // ProductID (Primary key)

        ///<summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        ///</summary>
        public System.Guid Rowguid { get; set; } // rowguid

        ///<summary>
        /// Date and time the record was last updated.
        ///</summary>
        public System.DateTime ModifiedDate { get; set; } // ModifiedDate

        // Reverse navigation

        /// <summary>
        /// Child SalesOrderDetails where [SalesOrderDetail].([ProductID], [SpecialOfferID]) point to this entity (FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } // SalesOrderDetail.FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID


        // Foreign keys

        /// <summary>
        /// Parent Product pointed by [SpecialOfferProduct].([ProductId]) (FK_SpecialOfferProduct_Product_ProductID)
        /// </summary>
        public virtual Product Product { get; set; } // FK_SpecialOfferProduct_Product_ProductID

        /// <summary>
        /// Parent SpecialOffer pointed by [SpecialOfferProduct].([SpecialOfferId]) (FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID)
        /// </summary>
        public virtual SpecialOffer SpecialOffer { get; set; } // FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID

        public SpecialOfferProduct()
        {
            Rowguid = System.Guid.NewGuid();
            ModifiedDate = System.DateTime.Now;
            SalesOrderDetails = new System.Collections.Generic.List<SalesOrderDetail>();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
