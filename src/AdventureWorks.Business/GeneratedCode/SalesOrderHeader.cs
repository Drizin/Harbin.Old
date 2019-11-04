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

    // SalesOrderHeader
        ///<summary>
        /// General sales order information.
        ///</summary>
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class SalesOrderHeader
    {

        ///<summary>
        /// Primary key.
        ///</summary>
        public int? SalesOrderId { get; set; } // SalesOrderID (Primary key)

        ///<summary>
        /// Incremental number to track changes to the sales order over time.
        ///</summary>
        public byte RevisionNumber { get; set; } // RevisionNumber

        ///<summary>
        /// Dates the sales order was created.
        ///</summary>
        public System.DateTime OrderDate { get; set; } // OrderDate

        ///<summary>
        /// Date the order is due to the customer.
        ///</summary>
        public System.DateTime DueDate { get; set; } // DueDate

        ///<summary>
        /// Date the order was shipped to the customer.
        ///</summary>
        public System.DateTime? ShipDate { get; set; } // ShipDate

        ///<summary>
        /// Order current status. 1 = In process; 2 = Approved; 3 = Backordered; 4 = Rejected; 5 = Shipped; 6 = Cancelled
        ///</summary>
        public byte Status { get; set; } // Status

        ///<summary>
        /// 0 = Order placed by sales person. 1 = Order placed online by customer.
        ///</summary>
        public bool OnlineOrderFlag { get; set; } // OnlineOrderFlag

        ///<summary>
        /// Unique sales order identification number.
        ///</summary>
        public string SalesOrderNumber { get; private set; } // SalesOrderNumber (length: 25)

        ///<summary>
        /// Customer purchase order number reference.
        ///</summary>
        public string PurchaseOrderNumber { get; set; } // PurchaseOrderNumber (length: 25)

        ///<summary>
        /// Financial accounting number reference.
        ///</summary>
        public string AccountNumber { get; set; } // AccountNumber (length: 15)

        ///<summary>
        /// Customer identification number. Foreign key to Customer.BusinessEntityID.
        ///</summary>
        public int CustomerId { get; set; } // CustomerID

        ///<summary>
        /// Sales person who created the sales order. Foreign key to SalesPerson.BusinessEntityID.
        ///</summary>
        public int? SalesPersonId { get; set; } // SalesPersonID

        ///<summary>
        /// Territory in which the sale was made. Foreign key to SalesTerritory.SalesTerritoryID.
        ///</summary>
        public int? TerritoryId { get; set; } // TerritoryID

        ///<summary>
        /// Customer billing address. Foreign key to Address.AddressID.
        ///</summary>
        public int BillToAddressId { get; set; } // BillToAddressID

        ///<summary>
        /// Customer shipping address. Foreign key to Address.AddressID.
        ///</summary>
        public int ShipToAddressId { get; set; } // ShipToAddressID

        ///<summary>
        /// Shipping method. Foreign key to ShipMethod.ShipMethodID.
        ///</summary>
        public int ShipMethodId { get; set; } // ShipMethodID

        ///<summary>
        /// Credit card identification number. Foreign key to CreditCard.CreditCardID.
        ///</summary>
        public int? CreditCardId { get; set; } // CreditCardID

        ///<summary>
        /// Approval code provided by the credit card company.
        ///</summary>
        public string CreditCardApprovalCode { get; set; } // CreditCardApprovalCode (length: 15)

        ///<summary>
        /// Currency exchange rate used. Foreign key to CurrencyRate.CurrencyRateID.
        ///</summary>
        public int? CurrencyRateId { get; set; } // CurrencyRateID

        ///<summary>
        /// Sales subtotal. Computed as SUM(SalesOrderDetail.LineTotal)for the appropriate SalesOrderID.
        ///</summary>
        public decimal SubTotal { get; set; } // SubTotal

        ///<summary>
        /// Tax amount.
        ///</summary>
        public decimal TaxAmt { get; set; } // TaxAmt

        ///<summary>
        /// Shipping cost.
        ///</summary>
        public decimal Freight { get; set; } // Freight

        ///<summary>
        /// Total due from customer. Computed as Subtotal + TaxAmt + Freight.
        ///</summary>
        public decimal TotalDue { get; private set; } // TotalDue

        ///<summary>
        /// Sales representative comments.
        ///</summary>
        public string Comment { get; set; } // Comment (length: 128)

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
        /// Child SalesOrderDetails where [SalesOrderDetail].[SalesOrderID] point to this entity (FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } // SalesOrderDetail.FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID

        /// <summary>
        /// Child SalesOrderHeaderSalesReasons where [SalesOrderHeaderSalesReason].[SalesOrderID] point to this entity (FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons { get; set; } // SalesOrderHeaderSalesReason.FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID


        // Foreign keys

        /// <summary>
        /// Parent Address pointed by [SalesOrderHeader].([BillToAddressId]) (FK_SalesOrderHeader_Address_BillToAddressID)
        /// </summary>
        public virtual Address BillToAddress { get; set; } // FK_SalesOrderHeader_Address_BillToAddressID

        /// <summary>
        /// Parent Address pointed by [SalesOrderHeader].([ShipToAddressId]) (FK_SalesOrderHeader_Address_ShipToAddressID)
        /// </summary>
        public virtual Address ShipToAddress { get; set; } // FK_SalesOrderHeader_Address_ShipToAddressID

        /// <summary>
        /// Parent CreditCard pointed by [SalesOrderHeader].([CreditCardId]) (FK_SalesOrderHeader_CreditCard_CreditCardID)
        /// </summary>
        public virtual CreditCard CreditCard { get; set; } // FK_SalesOrderHeader_CreditCard_CreditCardID

        /// <summary>
        /// Parent CurrencyRate pointed by [SalesOrderHeader].([CurrencyRateId]) (FK_SalesOrderHeader_CurrencyRate_CurrencyRateID)
        /// </summary>
        public virtual CurrencyRate CurrencyRate { get; set; } // FK_SalesOrderHeader_CurrencyRate_CurrencyRateID

        /// <summary>
        /// Parent Customer pointed by [SalesOrderHeader].([CustomerId]) (FK_SalesOrderHeader_Customer_CustomerID)
        /// </summary>
        public virtual Customer Customer { get; set; } // FK_SalesOrderHeader_Customer_CustomerID

        /// <summary>
        /// Parent SalesPerson pointed by [SalesOrderHeader].([SalesPersonId]) (FK_SalesOrderHeader_SalesPerson_SalesPersonID)
        /// </summary>
        public virtual SalesPerson SalesPerson { get; set; } // FK_SalesOrderHeader_SalesPerson_SalesPersonID

        /// <summary>
        /// Parent SalesTerritory pointed by [SalesOrderHeader].([TerritoryId]) (FK_SalesOrderHeader_SalesTerritory_TerritoryID)
        /// </summary>
        public virtual SalesTerritory SalesTerritory { get; set; } // FK_SalesOrderHeader_SalesTerritory_TerritoryID

        /// <summary>
        /// Parent ShipMethod pointed by [SalesOrderHeader].([ShipMethodId]) (FK_SalesOrderHeader_ShipMethod_ShipMethodID)
        /// </summary>
        public virtual ShipMethod ShipMethod { get; set; } // FK_SalesOrderHeader_ShipMethod_ShipMethodID

        public SalesOrderHeader()
        {
            RevisionNumber = 0;
            OrderDate = System.DateTime.Now;
            Status = 1;
            OnlineOrderFlag = true;
            SubTotal = 0.00m;
            TaxAmt = 0.00m;
            Freight = 0.00m;
            Rowguid = System.Guid.NewGuid();
            ModifiedDate = System.DateTime.Now;
            SalesOrderDetails = new System.Collections.Generic.List<SalesOrderDetail>();
            SalesOrderHeaderSalesReasons = new System.Collections.Generic.List<SalesOrderHeaderSalesReason>();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
