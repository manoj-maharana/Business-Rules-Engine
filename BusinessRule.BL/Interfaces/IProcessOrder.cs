using BusinessRule.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRule.BL.Interfaces
{
    public interface IProcessOrder
    {
        PaymentResult ProcessPayment(ProductInfo model);
    }
}
