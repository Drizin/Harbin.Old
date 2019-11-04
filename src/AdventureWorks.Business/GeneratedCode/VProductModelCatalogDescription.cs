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

    // vProductModelCatalogDescription
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class VProductModelCatalogDescription
    {
        public int? ProductModelId { get; set; } // ProductModelID (Primary key)
        public string Name { get; set; } // Name (Primary key) (length: 50)
        public string Summary { get; set; } // Summary
        public string Manufacturer { get; set; } // Manufacturer
        public string Copyright { get; set; } // Copyright (length: 30)
        public string ProductUrl { get; set; } // ProductURL (length: 256)
        public string WarrantyPeriod { get; set; } // WarrantyPeriod (length: 256)
        public string WarrantyDescription { get; set; } // WarrantyDescription (length: 256)
        public string NoOfYears { get; set; } // NoOfYears (length: 256)
        public string MaintenanceDescription { get; set; } // MaintenanceDescription (length: 256)
        public string Wheel { get; set; } // Wheel (length: 256)
        public string Saddle { get; set; } // Saddle (length: 256)
        public string Pedal { get; set; } // Pedal (length: 256)
        public string BikeFrame { get; set; } // BikeFrame
        public string Crankset { get; set; } // Crankset (length: 256)
        public string PictureAngle { get; set; } // PictureAngle (length: 256)
        public string PictureSize { get; set; } // PictureSize (length: 256)
        public string ProductPhotoId { get; set; } // ProductPhotoID (length: 256)
        public string Material { get; set; } // Material (length: 256)
        public string Color { get; set; } // Color (length: 256)
        public string ProductLine { get; set; } // ProductLine (length: 256)
        public string Style { get; set; } // Style (length: 256)
        public string RiderExperience { get; set; } // RiderExperience (length: 1024)
        public System.Guid Rowguid { get; set; } // rowguid (Primary key)
        public System.DateTime ModifiedDate { get; set; } // ModifiedDate (Primary key)
        public VProductModelCatalogDescription()
        {
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
