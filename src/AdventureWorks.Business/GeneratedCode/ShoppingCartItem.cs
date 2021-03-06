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

    // ShoppingCartItem
        ///<summary>
        /// Contains online customer orders until the order is submitted or cancelled.
        ///</summary>
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class ShoppingCartItem
    {

        ///<summary>
        /// Primary key for ShoppingCartItem records.
        ///</summary>
        public int? ShoppingCartItemId { get; set; } // ShoppingCartItemID (Primary key)

        ///<summary>
        /// Shopping cart identification number.
        ///</summary>
        public string ShoppingCartId { get; set; } // ShoppingCartID (length: 50)

        ///<summary>
        /// Product quantity ordered.
        ///</summary>
        public int Quantity { get; set; } // Quantity

        ///<summary>
        /// Product ordered. Foreign key to Product.ProductID.
        ///</summary>
        public int ProductId { get; set; } // ProductID

        ///<summary>
        /// Date the time the record was created.
        ///</summary>
        public System.DateTime DateCreated { get; set; } // DateCreated

        ///<summary>
        /// Date and time the record was last updated.
        ///</summary>
        public System.DateTime ModifiedDate { get; set; } // ModifiedDate

        // Foreign keys

        /// <summary>
        /// Parent Product pointed by [ShoppingCartItem].([ProductId]) (FK_ShoppingCartItem_Product_ProductID)
        /// </summary>
        public virtual Product Product { get; set; } // FK_ShoppingCartItem_Product_ProductID

        public ShoppingCartItem()
        {
            Quantity = 1;
            DateCreated = System.DateTime.Now;
            ModifiedDate = System.DateTime.Now;
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
