using BusinessRule.BL.Interfaces;
using BusinessRule.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRule.BL.Implementation
{
    public class BookPayment : IProcessOrder
    {
        public PaymentResult ProcessPayment(ProductInfo model)
        {
            model.RoyaltyDepartmentPrice = model.Quantity * model.Price * model.Commission;

            if (!string.IsNullOrEmpty(model.Name))
            {
                return new PaymentResult
                {
                    IsSuccess = true,
                    Message = "Royalty payment slip created with Amount -" + model.RoyaltyDepartmentPrice,
                };
            }
            else
            {
                throw new InvalidOperationException("Book Name is missing");
            }
        }
    }
}
