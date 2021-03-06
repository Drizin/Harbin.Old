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

    // EmployeePayHistory
        ///<summary>
        /// Employee pay history.
        ///</summary>
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class EmployeePayHistory
    {

        ///<summary>
        /// Employee identification number. Foreign key to Employee.BusinessEntityID.
        ///</summary>
        public int? BusinessEntityId { get; set; } // BusinessEntityID (Primary key)

        ///<summary>
        /// Date the change in pay is effective
        ///</summary>
        public System.DateTime RateChangeDate { get; set; } // RateChangeDate (Primary key)

        ///<summary>
        /// Salary hourly rate.
        ///</summary>
        public decimal Rate { get; set; } // Rate

        ///<summary>
        /// 1 = Salary received monthly, 2 = Salary received biweekly
        ///</summary>
        public byte PayFrequency { get; set; } // PayFrequency

        ///<summary>
        /// Date and time the record was last updated.
        ///</summary>
        public System.DateTime ModifiedDate { get; set; } // ModifiedDate

        // Foreign keys

        /// <summary>
        /// Parent Employee pointed by [EmployeePayHistory].([BusinessEntityId]) (FK_EmployeePayHistory_Employee_BusinessEntityID)
        /// </summary>
        public virtual Employee Employee { get; set; } // FK_EmployeePayHistory_Employee_BusinessEntityID

        public EmployeePayHistory()
        {
            ModifiedDate = System.DateTime.Now;
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
