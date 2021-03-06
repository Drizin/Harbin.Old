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

    // WorkOrder
        ///<summary>
        /// Manufacturing work orders.
        ///</summary>
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class WorkOrder
    {

        ///<summary>
        /// Primary key for WorkOrder records.
        ///</summary>
        public int? WorkOrderId { get; set; } // WorkOrderID (Primary key)

        ///<summary>
        /// Product identification number. Foreign key to Product.ProductID.
        ///</summary>
        public int ProductId { get; set; } // ProductID

        ///<summary>
        /// Product quantity to build.
        ///</summary>
        public int OrderQty { get; set; } // OrderQty

        ///<summary>
        /// Quantity built and put in inventory.
        ///</summary>
        public int StockedQty { get; private set; } // StockedQty

        ///<summary>
        /// Quantity that failed inspection.
        ///</summary>
        public short ScrappedQty { get; set; } // ScrappedQty

        ///<summary>
        /// Work order start date.
        ///</summary>
        public System.DateTime StartDate { get; set; } // StartDate

        ///<summary>
        /// Work order end date.
        ///</summary>
        public System.DateTime? EndDate { get; set; } // EndDate

        ///<summary>
        /// Work order due date.
        ///</summary>
        public System.DateTime DueDate { get; set; } // DueDate

        ///<summary>
        /// Reason for inspection failure.
        ///</summary>
        public short? ScrapReasonId { get; set; } // ScrapReasonID

        ///<summary>
        /// Date and time the record was last updated.
        ///</summary>
        public System.DateTime ModifiedDate { get; set; } // ModifiedDate

        // Reverse navigation

        /// <summary>
        /// Child WorkOrderRoutings where [WorkOrderRouting].[WorkOrderID] point to this entity (FK_WorkOrderRouting_WorkOrder_WorkOrderID)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<WorkOrderRouting> WorkOrderRoutings { get; set; } // WorkOrderRouting.FK_WorkOrderRouting_WorkOrder_WorkOrderID


        // Foreign keys

        /// <summary>
        /// Parent Product pointed by [WorkOrder].([ProductId]) (FK_WorkOrder_Product_ProductID)
        /// </summary>
        public virtual Product Product { get; set; } // FK_WorkOrder_Product_ProductID

        /// <summary>
        /// Parent ScrapReason pointed by [WorkOrder].([ScrapReasonId]) (FK_WorkOrder_ScrapReason_ScrapReasonID)
        /// </summary>
        public virtual ScrapReason ScrapReason { get; set; } // FK_WorkOrder_ScrapReason_ScrapReasonID

        public WorkOrder()
        {
            ModifiedDate = System.DateTime.Now;
            WorkOrderRoutings = new System.Collections.Generic.List<WorkOrderRouting>();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
