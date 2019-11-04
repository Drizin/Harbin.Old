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

    // EmployeeDepartmentHistory
        ///<summary>
        /// Employee department transfers.
        ///</summary>
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class EmployeeDepartmentHistory
    {

        ///<summary>
        /// Employee identification number. Foreign key to Employee.BusinessEntityID.
        ///</summary>
        public int? BusinessEntityId { get; set; } // BusinessEntityID (Primary key)

        ///<summary>
        /// Department in which the employee worked including currently. Foreign key to Department.DepartmentID.
        ///</summary>
        public short DepartmentId { get; set; } // DepartmentID (Primary key)

        ///<summary>
        /// Identifies which 8-hour shift the employee works. Foreign key to Shift.Shift.ID.
        ///</summary>
        public byte ShiftId { get; set; } // ShiftID (Primary key)

        ///<summary>
        /// Date the employee started work in the department.
        ///</summary>
        public System.DateTime StartDate { get; set; } // StartDate (Primary key)

        ///<summary>
        /// Date the employee left the department. NULL = Current department.
        ///</summary>
        public System.DateTime? EndDate { get; set; } // EndDate

        ///<summary>
        /// Date and time the record was last updated.
        ///</summary>
        public System.DateTime ModifiedDate { get; set; } // ModifiedDate

        // Foreign keys

        /// <summary>
        /// Parent Department pointed by [EmployeeDepartmentHistory].([DepartmentId]) (FK_EmployeeDepartmentHistory_Department_DepartmentID)
        /// </summary>
        public virtual Department Department { get; set; } // FK_EmployeeDepartmentHistory_Department_DepartmentID

        /// <summary>
        /// Parent Employee pointed by [EmployeeDepartmentHistory].([BusinessEntityId]) (FK_EmployeeDepartmentHistory_Employee_BusinessEntityID)
        /// </summary>
        public virtual Employee Employee { get; set; } // FK_EmployeeDepartmentHistory_Employee_BusinessEntityID

        /// <summary>
        /// Parent Shift pointed by [EmployeeDepartmentHistory].([ShiftId]) (FK_EmployeeDepartmentHistory_Shift_ShiftID)
        /// </summary>
        public virtual Shift Shift { get; set; } // FK_EmployeeDepartmentHistory_Shift_ShiftID

        public EmployeeDepartmentHistory()
        {
            ModifiedDate = System.DateTime.Now;
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>