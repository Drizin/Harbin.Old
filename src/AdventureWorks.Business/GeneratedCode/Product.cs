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

    // Product
        ///<summary>
        /// Products sold or used in the manfacturing of sold products.
        ///</summary>
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class Product
    {

        ///<summary>
        /// Primary key for Product records.
        ///</summary>
        public int? ProductId { get; set; } // ProductID (Primary key)

        ///<summary>
        /// Name of the product.
        ///</summary>
        public string Name { get; set; } // Name (length: 50)

        ///<summary>
        /// Unique product identification number.
        ///</summary>
        public string ProductNumber { get; set; } // ProductNumber (length: 25)

        ///<summary>
        /// 0 = Product is purchased, 1 = Product is manufactured in-house.
        ///</summary>
        public bool MakeFlag { get; set; } // MakeFlag

        ///<summary>
        /// 0 = Product is not a salable item. 1 = Product is salable.
        ///</summary>
        public bool FinishedGoodsFlag { get; set; } // FinishedGoodsFlag

        ///<summary>
        /// Product color.
        ///</summary>
        public string Color { get; set; } // Color (length: 15)

        ///<summary>
        /// Minimum inventory quantity.
        ///</summary>
        public short SafetyStockLevel { get; set; } // SafetyStockLevel

        ///<summary>
        /// Inventory level that triggers a purchase order or work order.
        ///</summary>
        public short ReorderPoint { get; set; } // ReorderPoint

        ///<summary>
        /// Standard cost of the product.
        ///</summary>
        public decimal StandardCost { get; set; } // StandardCost

        ///<summary>
        /// Selling price.
        ///</summary>
        public decimal ListPrice { get; set; } // ListPrice

        ///<summary>
        /// Product size.
        ///</summary>
        public string Size { get; set; } // Size (length: 5)

        ///<summary>
        /// Unit of measure for Size column.
        ///</summary>
        public string SizeUnitMeasureCode { get; set; } // SizeUnitMeasureCode (length: 3)

        ///<summary>
        /// Unit of measure for Weight column.
        ///</summary>
        public string WeightUnitMeasureCode { get; set; } // WeightUnitMeasureCode (length: 3)

        ///<summary>
        /// Product weight.
        ///</summary>
        public decimal? Weight { get; set; } // Weight

        ///<summary>
        /// Number of days required to manufacture the product.
        ///</summary>
        public int DaysToManufacture { get; set; } // DaysToManufacture

        ///<summary>
        /// R = Road, M = Mountain, T = Touring, S = Standard
        ///</summary>
        public string ProductLine { get; set; } // ProductLine (length: 2)

        ///<summary>
        /// H = High, M = Medium, L = Low
        ///</summary>
        public string Class { get; set; } // Class (length: 2)

        ///<summary>
        /// W = Womens, M = Mens, U = Universal
        ///</summary>
        public string Style { get; set; } // Style (length: 2)

        ///<summary>
        /// Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID.
        ///</summary>
        public int? ProductSubcategoryId { get; set; } // ProductSubcategoryID

        ///<summary>
        /// Product is a member of this product model. Foreign key to ProductModel.ProductModelID.
        ///</summary>
        public int? ProductModelId { get; set; } // ProductModelID

        ///<summary>
        /// Date the product was available for sale.
        ///</summary>
        public System.DateTime SellStartDate { get; set; } // SellStartDate

        ///<summary>
        /// Date the product was no longer available for sale.
        ///</summary>
        public System.DateTime? SellEndDate { get; set; } // SellEndDate

        ///<summary>
        /// Date the product was discontinued.
        ///</summary>
        public System.DateTime? DiscontinuedDate { get; set; } // DiscontinuedDate

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
        /// Child BillOfMaterials where [BillOfMaterials].[ComponentID] point to this entity (FK_BillOfMaterials_Product_ComponentID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<BillOfMaterial> BillOfMaterials_ComponentId { get; set; } // BillOfMaterials.FK_BillOfMaterials_Product_ComponentID

        /// <summary>
        /// Child BillOfMaterials where [BillOfMaterials].[ProductAssemblyID] point to this entity (FK_BillOfMaterials_Product_ProductAssemblyID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<BillOfMaterial> BillOfMaterials_ProductAssemblyId { get; set; } // BillOfMaterials.FK_BillOfMaterials_Product_ProductAssemblyID

        /// <summary>
        /// Child ProductCostHistories where [ProductCostHistory].[ProductID] point to this entity (FK_ProductCostHistory_Product_ProductID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<ProductCostHistory> ProductCostHistories { get; set; } // ProductCostHistory.FK_ProductCostHistory_Product_ProductID

        /// <summary>
        /// Child ProductDocuments where [ProductDocument].[ProductID] point to this entity (FK_ProductDocument_Product_ProductID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<ProductDocument> ProductDocuments { get; set; } // ProductDocument.FK_ProductDocument_Product_ProductID

        /// <summary>
        /// Child ProductInventories where [ProductInventory].[ProductID] point to this entity (FK_ProductInventory_Product_ProductID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<ProductInventory> ProductInventories { get; set; } // ProductInventory.FK_ProductInventory_Product_ProductID

        /// <summary>
        /// Child ProductListPriceHistories where [ProductListPriceHistory].[ProductID] point to this entity (FK_ProductListPriceHistory_Product_ProductID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<ProductListPriceHistory> ProductListPriceHistories { get; set; } // ProductListPriceHistory.FK_ProductListPriceHistory_Product_ProductID

        /// <summary>
        /// Child ProductProductPhotos where [ProductProductPhoto].[ProductID] point to this entity (FK_ProductProductPhoto_Product_ProductID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<ProductProductPhoto> ProductProductPhotos { get; set; } // ProductProductPhoto.FK_ProductProductPhoto_Product_ProductID

        /// <summary>
        /// Child ProductReviews where [ProductReview].[ProductID] point to this entity (FK_ProductReview_Product_ProductID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<ProductReview> ProductReviews { get; set; } // ProductReview.FK_ProductReview_Product_ProductID

        /// <summary>
        /// Child ProductVendors where [ProductVendor].[ProductID] point to this entity (FK_ProductVendor_Product_ProductID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<ProductVendor> ProductVendors { get; set; } // ProductVendor.FK_ProductVendor_Product_ProductID

        /// <summary>
        /// Child PurchaseOrderDetails where [PurchaseOrderDetail].[ProductID] point to this entity (FK_PurchaseOrderDetail_Product_ProductID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } // PurchaseOrderDetail.FK_PurchaseOrderDetail_Product_ProductID

        /// <summary>
        /// Child ShoppingCartItems where [ShoppingCartItem].[ProductID] point to this entity (FK_ShoppingCartItem_Product_ProductID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } // ShoppingCartItem.FK_ShoppingCartItem_Product_ProductID

        /// <summary>
        /// Child SpecialOfferProducts where [SpecialOfferProduct].[ProductID] point to this entity (FK_SpecialOfferProduct_Product_ProductID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<SpecialOfferProduct> SpecialOfferProducts { get; set; } // SpecialOfferProduct.FK_SpecialOfferProduct_Product_ProductID

        /// <summary>
        /// Child TransactionHistories where [TransactionHistory].[ProductID] point to this entity (FK_TransactionHistory_Product_ProductID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<TransactionHistory> TransactionHistories { get; set; } // TransactionHistory.FK_TransactionHistory_Product_ProductID

        /// <summary>
        /// Child WorkOrders where [WorkOrder].[ProductID] point to this entity (FK_WorkOrder_Product_ProductID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<WorkOrder> WorkOrders { get; set; } // WorkOrder.FK_WorkOrder_Product_ProductID


        // Foreign keys

        /// <summary>
        /// Parent ProductModel pointed by [Product].([ProductModelId]) (FK_Product_ProductModel_ProductModelID)
        /// </summary>
        public virtual ProductModel ProductModel { get; set; } // FK_Product_ProductModel_ProductModelID

        /// <summary>
        /// Parent ProductSubcategory pointed by [Product].([ProductSubcategoryId]) (FK_Product_ProductSubcategory_ProductSubcategoryID)
        /// </summary>
        public virtual ProductSubcategory ProductSubcategory { get; set; } // FK_Product_ProductSubcategory_ProductSubcategoryID

        /// <summary>
        /// Parent UnitMeasure pointed by [Product].([SizeUnitMeasureCode]) (FK_Product_UnitMeasure_SizeUnitMeasureCode)
        /// </summary>
        public virtual UnitMeasure UnitMeasure_SizeUnitMeasureCode { get; set; } // FK_Product_UnitMeasure_SizeUnitMeasureCode

        /// <summary>
        /// Parent UnitMeasure pointed by [Product].([WeightUnitMeasureCode]) (FK_Product_UnitMeasure_WeightUnitMeasureCode)
        /// </summary>
        public virtual UnitMeasure UnitMeasure_WeightUnitMeasureCode { get; set; } // FK_Product_UnitMeasure_WeightUnitMeasureCode

        public Product()
        {
            MakeFlag = true;
            FinishedGoodsFlag = true;
            Rowguid = System.Guid.NewGuid();
            ModifiedDate = System.DateTime.Now;
            BillOfMaterials_ComponentId = new System.Collections.Generic.List<BillOfMaterial>();
            BillOfMaterials_ProductAssemblyId = new System.Collections.Generic.List<BillOfMaterial>();
            ProductCostHistories = new System.Collections.Generic.List<ProductCostHistory>();
            ProductDocuments = new System.Collections.Generic.List<ProductDocument>();
            ProductInventories = new System.Collections.Generic.List<ProductInventory>();
            ProductListPriceHistories = new System.Collections.Generic.List<ProductListPriceHistory>();
            ProductProductPhotos = new System.Collections.Generic.List<ProductProductPhoto>();
            ProductReviews = new System.Collections.Generic.List<ProductReview>();
            ProductVendors = new System.Collections.Generic.List<ProductVendor>();
            PurchaseOrderDetails = new System.Collections.Generic.List<PurchaseOrderDetail>();
            ShoppingCartItems = new System.Collections.Generic.List<ShoppingCartItem>();
            SpecialOfferProducts = new System.Collections.Generic.List<SpecialOfferProduct>();
            TransactionHistories = new System.Collections.Generic.List<TransactionHistory>();
            WorkOrders = new System.Collections.Generic.List<WorkOrder>();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>