using BusinessRule.BL.Interfaces;
using BusinessRule.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRule.BL.Implementation
{
    public class PhysicalorBookPayment : IProcessOrder
    {
        public PaymentResult ProcessPayment(ProductInfo model)
        {
            // assuming 20% commission
            model.Commission = (model.Quantity * model.Price) / 0.20;

            if (!string.IsNullOrEmpty(model.AgentName))
            {
                return new PaymentResult
                {
                    IsSuccess = true,
                    Message = "Commision paid to agent -" + model.Commission,
                };
            }
            else
            {
                throw new InvalidOperationException("Agent Name is missing");
            }
        }
    }
}
