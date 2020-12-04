using BusinessRule.BL.Interfaces;
using BusinessRule.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRule.BL.Implementation
{
    public class PhysicalProductPayment : IProcessOrder
    {
        public PaymentResult ProcessPayment(ProductInfo model)
        {
            if (!string.IsNullOrEmpty(model.Name))
            {
                return new PaymentResult
                {
                    IsSuccess = true,
                    Message = "Packing slip for shipping generated for physical product",
                };
            }
            else
            {
                throw new InvalidOperationException("Physical Product Name is missing");
            }
        }
    }
}
