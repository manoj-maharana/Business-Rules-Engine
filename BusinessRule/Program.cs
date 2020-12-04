using BusinessRule.BL.Interfaces;
using BusinessRule.BL.Models;
using BusinessRule.BL.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRule
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Business Rules Engine \n");
            Console.WriteLine("******************************** \n");
            Console.WriteLine("Please Select Any One Following Rules: \n");
            Console.WriteLine("******************************** \n");
            Console.WriteLine("1: Physical Product \n" +
                              "2: Process Book Order \n" +
                              "3: New Activation for Member\n" +
                              "4: Process Video \n" +
                              "5: Process Physical or Book\n" +
                              "6: Upgrade Member\n");

            Console.WriteLine("********************************");
            try
            {
                var inputValue = Convert.ToInt32(Console.ReadLine());
                Process(inputValue);
            }
            catch
            {
                Console.WriteLine("Please enter a valid option Number!");
            }

            Console.Read();
        }
        private static void Process(int input_options)
        {
            int memberShipType = 0;
            var paymentType = (PaymentFor)Enum.Parse(typeof(PaymentFor), input_options.ToString());
            if (input_options == 3 || input_options == 6)
            {
                paymentType = (PaymentFor)Enum.Parse(typeof(PaymentFor), "3".ToString());
                memberShipType = input_options == 3 ? 1 : 2;
                var result = ProcessOrders.CreateMemberShipObject();
                var sampleInput = SampleInput.GetSampleDataMember(memberShipType);

                if (result != null)
                {
                    var data = result.ProcessPayment(sampleInput);

                    Console.WriteLine($"Order of the {paymentType.ToString()} and  {data.Message}\n");
                }
                else
                {
                    Console.WriteLine("Invalid operation");
                }

            }
            else
            {
                IProcessOrder processor = ProcessOrders.GetPaymentMethod(paymentType);
                var data = SampleInput.GetSampleDataForOrder(paymentType);
                if (processor != null)
                {
                    var result = processor.ProcessPayment(data);

                    Console.WriteLine($"Order of {paymentType.ToString()} and  {result.Message}\n");
                }
                else
                {
                    Console.WriteLine("Invalid operation");
                }
            }


        }
    }

    public static class SampleInput
    {
        private static List<ProductInfo> GetProducts()
        {
            List<ProductInfo> details = new List<ProductInfo>();
            details.Add(new ProductInfo
            {
                ProductType = ProductFor.BOOK,
                Name = "1st Book",
                Price = 1500,
                Quantity = 50,
                RoyaltyDepartmentPrice = 10,
                Commission = 15,
                Description = "Test Description"

            });

            details.Add(new ProductInfo
            {
                ProductType = ProductFor.VIDEO,
                Name = "1st Video Test",
                Description = "learning to msi",
                Price = 1500,
                Quantity = 50,
                Commission = 15,

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

        private static List<MemeberShipDetails> GetMembers()
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


        public static ProductInfo GetSampleDataForOrder(PaymentFor options)
        {
            ProductInfo data = null;

            switch (options)
            {
                case PaymentFor.PHYSICALPRODUCT:
                    data = GetProducts().Where(x => x.ProductType == ProductFor.PHYSICALPRODUCT).FirstOrDefault();
                    break;
                case PaymentFor.BOOK:
                    data = GetProducts().Where(x => x.ProductType == ProductFor.BOOK).FirstOrDefault();
                    break;
                case PaymentFor.BOOKORPHYSICAL:
                    data = GetProducts().Where(x => x.ProductType == ProductFor.BOOKORPHYSICAL).FirstOrDefault();
                    break;
                case PaymentFor.VIDEO:
                    data = GetProducts().Where(x => x.ProductType == ProductFor.VIDEO).FirstOrDefault();
                    break;
                default:
                    data = null;
                    break;
            }
            return data;
        }

        public static MemeberShipDetails GetSampleDataMember(int memberShipType = 0)
        {
            MemeberShipDetails memberData = null;
            memberData = GetMembers().Where(x => x.MemberShipType == (MemberShipFor)memberShipType).FirstOrDefault();
            return memberData;
        }

    }
}
