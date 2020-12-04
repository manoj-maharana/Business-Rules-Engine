using BusinessRule.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRule.BL.Interfaces
{
    public interface IMemberShipPayment
    {
        PaymentResult ProcessPayment(MemeberShipDetails model);
    }
}
