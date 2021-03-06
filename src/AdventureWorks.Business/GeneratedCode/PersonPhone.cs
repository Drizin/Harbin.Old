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

    // PersonPhone
        ///<summary>
        /// Telephone number and type of a person.
        ///</summary>
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class PersonPhone
    {

        ///<summary>
        /// Business entity identification number. Foreign key to Person.BusinessEntityID.
        ///</summary>
        public int? BusinessEntityId { get; set; } // BusinessEntityID (Primary key)

        ///<summary>
        /// Telephone number identification number.
        ///</summary>
        public string PhoneNumber { get; set; } // PhoneNumber (Primary key) (length: 25)

        ///<summary>
        /// Kind of phone number. Foreign key to PhoneNumberType.PhoneNumberTypeID.
        ///</summary>
        public int? PhoneNumberTypeId { get; set; } // PhoneNumberTypeID (Primary key)

        ///<summary>
        /// Date and time the record was last updated.
        ///</summary>
        public System.DateTime ModifiedDate { get; set; } // ModifiedDate

        // Foreign keys

        /// <summary>
        /// Parent Person pointed by [PersonPhone].([BusinessEntityId]) (FK_PersonPhone_Person_BusinessEntityID)
        /// </summary>
        public virtual Person Person { get; set; } // FK_PersonPhone_Person_BusinessEntityID

        /// <summary>
        /// Parent PhoneNumberType pointed by [PersonPhone].([PhoneNumberTypeId]) (FK_PersonPhone_PhoneNumberType_PhoneNumberTypeID)
        /// </summary>
        public virtual PhoneNumberType PhoneNumberType { get; set; } // FK_PersonPhone_PhoneNumberType_PhoneNumberTypeID

        public PersonPhone()
        {
            ModifiedDate = System.DateTime.Now;
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
