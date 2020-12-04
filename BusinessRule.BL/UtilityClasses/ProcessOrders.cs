using BusinessRule.BL.Implementation;
using BusinessRule.BL.Interfaces;
using BusinessRule.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRule.BL.UtilityClasses
{
    public class ProcessOrders
    {
        public static IProcessOrder GetPaymentMethod(PaymentFor type)
        {
            IProcessOrder _processOrder = null;
            switch (type)
            {
                case PaymentFor.PHYSICALPRODUCT:
                    _processOrder = new PhysicalProductPayment();
                    break;
                case PaymentFor.BOOK:
                    _processOrder = new BookPayment();
                    break;
                case PaymentFor.BOOKORPHYSICAL:
                    _processOrder = new PhysicalorBookPayment();
                    break;
                case PaymentFor.VIDEO:
                    _processOrder = new VideoPayment();
                    break;
                default:
                    break;
            }
            return _processOrder;
        }

        public static IMemberShipPayment CreateMemberShipObject()
        {
            IMemberShipPayment _memberShipPayment = null;
            _memberShipPayment = new MemberShipPayment();

            return _memberShipPayment;
        }
    }
}
