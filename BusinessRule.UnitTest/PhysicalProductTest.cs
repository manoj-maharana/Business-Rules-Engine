using BusinessRule.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using BusinessRule.BL.UtilityClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessRule.UnitTest
{
    [TestClass]
    public class PhysicalProductTest : SampleInput
    {
        IProcessOrder OrderProcess;
        [TestMethod]
        public void Valid_PhysicalProduct_Order()
        {
            //arrange
            var physcialProduct = GetProductInfo().Where(x => x.ProductType == BL.Models.ProductFor.PHYSICALPRODUCT).FirstOrDefault();
            OrderProcess = ProcessOrders.GetPaymentMethod(BL.Models.PaymentFor.PHYSICALPRODUCT);


            //act
            var result = OrderProcess.ProcessPayment(physcialProduct);

            //assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("Packing slip for shipping generated for physical product", result.Message);

        }

        [TestMethod]
        public void Process_Empty_PhysicalProduct()
        {
            //arrange
            var product = GetProductInfo().Where(x => x.ProductType == BL.Models.ProductFor.PHYSICALPRODUCT).FirstOrDefault();
            product.Name = string.Empty;
            OrderProcess = ProcessOrders.GetPaymentMethod(BL.Models.PaymentFor.PHYSICALPRODUCT);


            //Act
            var ex = OrderProcess.ProcessPayment(product);

            //Assert  
            Assert.AreEqual(ex.Message, "Physical Product Name is missing.");

        }
    }

}
