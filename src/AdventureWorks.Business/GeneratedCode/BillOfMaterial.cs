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

    // BillOfMaterials
        ///<summary>
        /// Items required to make bicycles and bicycle subassemblies. It identifies the heirarchical relationship between a parent product and its components.
        ///</summary>
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class BillOfMaterial
    {

        ///<summary>
        /// Primary key for BillOfMaterials records.
        ///</summary>
        public int? BillOfMaterialsId { get; set; } // BillOfMaterialsID (Primary key)

        ///<summary>
        /// Parent product identification number. Foreign key to Product.ProductID.
        ///</summary>
        public int? ProductAssemblyId { get; set; } // ProductAssemblyID

        ///<summary>
        /// Component identification number. Foreign key to Product.ProductID.
        ///</summary>
        public int ComponentId { get; set; } // ComponentID

        ///<summary>
        /// Date the component started being used in the assembly item.
        ///</summary>
        public System.DateTime StartDate { get; set; } // StartDate

        ///<summary>
        /// Date the component stopped being used in the assembly item.
        ///</summary>
        public System.DateTime? EndDate { get; set; } // EndDate

        ///<summary>
        /// Standard code identifying the unit of measure for the quantity.
        ///</summary>
        public string UnitMeasureCode { get; set; } // UnitMeasureCode (length: 3)

        ///<summary>
        /// Indicates the depth the component is from its parent (AssemblyID).
        ///</summary>
        public short BomLevel { get; set; } // BOMLevel

        ///<summary>
        /// Quantity of the component needed to create the assembly.
        ///</summary>
        public decimal PerAssemblyQty { get; set; } // PerAssemblyQty

        ///<summary>
        /// Date and time the record was last updated.
        ///</summary>
        public System.DateTime ModifiedDate { get; set; } // ModifiedDate

        // Foreign keys

        /// <summary>
        /// Parent Product pointed by [BillOfMaterials].([ComponentId]) (FK_BillOfMaterials_Product_ComponentID)
        /// </summary>
        public virtual Product Component { get; set; } // FK_BillOfMaterials_Product_ComponentID

        /// <summary>
        /// Parent Product pointed by [BillOfMaterials].([ProductAssemblyId]) (FK_BillOfMaterials_Product_ProductAssemblyID)
        /// </summary>
        public virtual Product ProductAssembly { get; set; } // FK_BillOfMaterials_Product_ProductAssemblyID

        /// <summary>
        /// Parent UnitMeasure pointed by [BillOfMaterials].([UnitMeasureCode]) (FK_BillOfMaterials_UnitMeasure_UnitMeasureCode)
        /// </summary>
        public virtual UnitMeasure UnitMeasure { get; set; } // FK_BillOfMaterials_UnitMeasure_UnitMeasureCode

        public BillOfMaterial()
        {
            StartDate = System.DateTime.Now;
            PerAssemblyQty = 1.00m;
            ModifiedDate = System.DateTime.Now;
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
