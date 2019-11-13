using Harbin.Common.TypeSafeEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Entities
{
    public class ContactTypeEnum : TypeSafeEnum<ContactTypeEnum, int>
    {
        #region ctor
        private ContactTypeEnum(int contactTypeID) : base(contactTypeID)
        {
        }
        #endregion

        #region Enum Instances
        public static readonly ContactTypeEnum ACCOUNTING_MANAGER = new AccountingManagerContactTypeEnum();
        public static readonly ContactTypeEnum ASSISTANT_SALES_AGENT = new AssistantSalesAgentContactTypeEnum();
        public static readonly ContactTypeEnum ASSISTANT_SALES_REPRESENTATIVE = new AssistantSalesRepresentativeContactTypeEnum();
        public static readonly ContactTypeEnum COORDINATOR_FOREIGN_MARKETS = new ContactTypeEnum(4);
        public static readonly ContactTypeEnum EXPORT_ADMINISTRATOR = new ContactTypeEnum(5);
        public static readonly ContactTypeEnum INTERNATIONAL_MARKETING_MANAGER = new ContactTypeEnum(6);
        public static readonly ContactTypeEnum MARKETING_ASSISTANT = new ContactTypeEnum(7);
        public static readonly ContactTypeEnum MARKETING_MANAGER = new ContactTypeEnum(8);
        public static readonly ContactTypeEnum MARKETING_REPRESENTATIVE = new ContactTypeEnum(9);
        public static readonly ContactTypeEnum ORDER_ADMINISTRATOR = new ContactTypeEnum(10);
        public static readonly ContactTypeEnum OWNER = new ContactTypeEnum(11);
        public static readonly ContactTypeEnum OWNER_MARKETING_ASSISTANT= new ContactTypeEnum(12);
        public static readonly ContactTypeEnum PRODUCT_MANAGER = new ContactTypeEnum(13);
        public static readonly ContactTypeEnum PURCHASING_AGENT = new ContactTypeEnum(14);
        public static readonly ContactTypeEnum PURCHASING_MANAGER = new ContactTypeEnum(15);
        public static readonly ContactTypeEnum REGIONAL_ACCOUNT_REPRESENTATIVE = new ContactTypeEnum(16);
        public static readonly ContactTypeEnum SALES_AGENT = new ContactTypeEnum(17);
        public static readonly ContactTypeEnum SALES_ASSOCIATE = new ContactTypeEnum(18);
        public static readonly ContactTypeEnum SALES_MANAGER = new ContactTypeEnum(19);
        public static readonly ContactTypeEnum SALES_REPRESENTATIVE = new ContactTypeEnum(20);
        #endregion

        #region Specialized enum (derived classes)
        public class AccountingManagerContactTypeEnum: ContactTypeEnum
        {
            public AccountingManagerContactTypeEnum():base(contactTypeID: 1)
            {
            }
        }
        public class AssistantSalesAgentContactTypeEnum : ContactTypeEnum
        {
            public AssistantSalesAgentContactTypeEnum() : base(contactTypeID: 2)
            {
            }
        }
        public class AssistantSalesRepresentativeContactTypeEnum : ContactTypeEnum
        {
            public AssistantSalesRepresentativeContactTypeEnum() : base(contactTypeID: 3)
            {
            }
        }
        #endregion
    }

    #region Classes which are extended with this Enum: BusinessEntityContact
    partial class BusinessEntityContact
    {
        [NotMapped]
        [TypeSafeEnumWrapper(UnderlyingProperty = "ContactTypeId")]
        public ContactTypeEnum ContactType
        {
            get { return ContactTypeEnum.FromKey(this.ContactTypeId.Value); }
            set { this.ContactTypeId = value.Key; }
        }
    }

    #endregion
}
