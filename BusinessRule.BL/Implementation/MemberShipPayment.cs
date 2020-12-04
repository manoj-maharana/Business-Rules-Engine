using BusinessRule.BL.Interfaces;
using BusinessRule.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRule.BL.Implementation
{
    public class MemberShipPayment : IMemberShipPayment
    {
        public PaymentResult ProcessPayment(MemeberShipDetails model)
        {
            PaymentResult result = null;

            // If Payment is done then activate the membership and sent a email to owner.
            if (!string.IsNullOrEmpty(model.MemberName))
            {
                switch (model.MemberShipType)
                {
                    case MemberShipFor.ACTIVATION:
                        result = CreateNewActivation(model);
                        break;
                    case MemberShipFor.UPGRADE:
                        result = UpgradeMemeberShip(model);
                        break;
                    default:
                        break;
                }

            }
            else
            {
                throw new InvalidOperationException();
            }
            return result;
        }

        private PaymentResult CreateNewActivation(MemeberShipDetails memberInfo)
        {
            // Send an email to Owner/member about their new activation.
            return new PaymentResult
            {
                IsSuccess = true,
                Message = "Activation Completed and Sent an email to Owner"
            };
        }

        private PaymentResult UpgradeMemeberShip(MemeberShipDetails memberInfo)
        {
            // Send an email to Owner/member about their upgrade.
            return new PaymentResult
            {
                IsSuccess = true,
                Message = "upgrade Completed and Sent an email to Owner"
            };
        }

    }
}
