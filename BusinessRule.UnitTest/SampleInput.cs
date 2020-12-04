using BusinessRule.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRule.UnitTest
{
    public class SampleInput
    {
        List<ProductInfo> products;
        List<MemeberShipDetails> Members;
        public SampleInput()
        {
            products = GetProductInfo();

        }

        public List<ProductInfo> GetProductInfo()
        {
            List<ProductInfo> details = new List<ProductInfo>();
            details.Add(new ProductInfo
            {
                ProductType = ProductFor.BOOK,
                Name = "1st Book",
                Price = 1500,
                Quantity = 50

            });

            details.Add(new ProductInfo
            {
                ProductType = ProductFor.VIDEO,
                Name = "1st Video Test",
                Description = "learning to msi",
                Price = 1500,
                Quantity = 50

            });

            details.Add(new ProductInfo
            {
                ProductType = ProductFor.PHYSICALPRODUCT,
                AgentName = "Agent 001",
                Commission = 10,
                Name = "Physical Product Test 1",
                Description = "learning to msi",
                Price = 1500,
                Quantity = 50

            });
            details.Add(new ProductInfo
            {
                ProductType = ProductFor.BOOKORPHYSICAL,
                AgentName = "Agent 001",
                Name = "Physical or booking Product Test 1",
                Price = 1500,
                Quantity = 50
            });


            return details;
        }

        public List<MemeberShipDetails> GetMembers()
        {
            List<MemeberShipDetails> details = new List<MemeberShipDetails>();
            details.Add(new MemeberShipDetails
            {
                MemberName = "1st User",
                EndDate = DateTime.Today.AddDays(365),
                StartDate = DateTime.Today,
                MemberShipType = MemberShipFor.ACTIVATION
            });

            details.Add(new MemeberShipDetails
            {
                MemberName = "1st User",
                EndDate = DateTime.Today.AddDays(365),
                StartDate = DateTime.Today,
                MemberShipType = MemberShipFor.UPGRADE
            });

            return details;
        }

    }
}
