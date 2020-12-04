using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRule.BL.Models
{
    public class ProductInfo : Product
    {
        public double RoyaltyDepartmentPrice { get; set; }

        public DateTime PackagingDate { get; set; }
        public PaymentFor PaymentOptions { get; set; }
        public double Commission { get; set; }
        public string AgentName { get; set; }
    }
}
