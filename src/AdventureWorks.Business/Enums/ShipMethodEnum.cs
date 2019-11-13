using Harbin.Common.TypeSafeEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Entities
{
    public class ShipMethodEnum : TypeSafeEnum<ShipMethodEnum, int>
    {
        #region ctor
        private ShipMethodEnum(int shipMethodID) : base(shipMethodID)
        {
        }
        #endregion

        public bool CanCancelShipment { get; set; } = true;

        #region Methods
        /// <summary>
        /// How many business days for delivery (based on product weight)
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public virtual int CalcDeliveryDays(Product product)
        {
            switch (product.Weight ?? decimal.MaxValue)
            {
                case var n when (n <= 100):
                    return 3;
                case var n when (n <= 1000):
                    return 5;
                default:
                    return 7;
            }
        }
        #endregion


        #region Enum Instances
        public static readonly ShipMethodEnum XRQ_TRUCK_GROUND = new XrqTruckGroundShipMethodEnum();
        public static readonly ShipMethodEnum ZY_EXPRESS = new ShipMethodEnum(2);
        public static readonly ShipMethodEnum OVERSEAS_DELUXE = new ShipMethodEnum(3);
        public static readonly ShipMethodEnum OVERNIGHT_J_FAST = new ShipMethodEnum(4);
        public static readonly ShipMethodEnum CARGO_TRANSPORT_5 = new ShipMethodEnum(5);
        #endregion

        #region Specialized enum (derived classes)
        public class XrqTruckGroundShipMethodEnum : ShipMethodEnum
        {
            public XrqTruckGroundShipMethodEnum():base(shipMethodID: 1)
            {
                CanCancelShipment = false;
            }
            public override int CalcDeliveryDays(Product product)
            {
                // 2 extra days for Truck Ground
                return 2 + base.CalcDeliveryDays(product);
            }
        }
        #endregion
    }

    #region Classes which are extended with this Enum: SalesOrderHeader
    partial class SalesOrderHeader
    {
        [NotMapped]
        [TypeSafeEnumWrapper(UnderlyingProperty = "ShipMethodId")]
        public ShipMethodEnum ShipMethod
        {
            get { return ShipMethodEnum.FromKey(this.ShipMethodId); }
            set { this.ShipMethodId = value.Key; }
        }
    }
    #endregion
}
