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

    // PersonCreditCard
        ///<summary>
        /// Cross-reference table mapping people to their credit card information in the CreditCard table.
        ///</summary>
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.37.4.0")]
    public partial class PersonCreditCard
    {

        ///<summary>
        /// Business entity identification number. Foreign key to Person.BusinessEntityID.
        ///</summary>
        public int? BusinessEntityId { get; set; } // BusinessEntityID (Primary key)

        ///<summary>
        /// Credit card identification number. Foreign key to CreditCard.CreditCardID.
        ///</summary>
        public int? CreditCardId { get; set; } // CreditCardID (Primary key)

        ///<summary>
        /// Date and time the record was last updated.
        ///</summary>
        public System.DateTime ModifiedDate { get; set; } // ModifiedDate

        // Foreign keys

        /// <summary>
        /// Parent CreditCard pointed by [PersonCreditCard].([CreditCardId]) (FK_PersonCreditCard_CreditCard_CreditCardID)
        /// </summary>
        public virtual CreditCard CreditCard { get; set; } // FK_PersonCreditCard_CreditCard_CreditCardID

        /// <summary>
        /// Parent Person pointed by [PersonCreditCard].([BusinessEntityId]) (FK_PersonCreditCard_Person_BusinessEntityID)
        /// </summary>
        public virtual Person Person { get; set; } // FK_PersonCreditCard_Person_BusinessEntityID

        public PersonCreditCard()
        {
            ModifiedDate = System.DateTime.Now;
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
