using BusinessRule.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using BusinessRule.BL.UtilityClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessRule.UnitTest
{
    [TestClass]
    public class PhysicalOrBookPaymentTest : SampleInput
    {
        IProcessOrder OrderProcess;

        [TestMethod]
        public void Valid_PhysicalProduct_Order()
        {
            //arrange
            var physcialProduct = GetProductInfo().Where(x => x.ProductType == BL.Models.ProductFor.BOOKORPHYSICAL).FirstOrDefault();

            double Commission = (physcialProduct.Quantity * physcialProduct.Price) / 0.20;

            OrderProcess = ProcessOrders.GetPaymentMethod(BL.Models.PaymentFor.BOOKORPHYSICAL);
            string message = "Commision paid to agent -" + Commission;

            //act
            var result = OrderProcess.ProcessPayment(physcialProduct);

            //assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(message, result.Message);
        }

        [TestMethod]
        public void Process_Empty_PhysicalProduct()
        {
            //Arrange
            var product = GetProductInfo().Where(x => x.ProductType == BL.Models.ProductFor.BOOKORPHYSICAL).FirstOrDefault();
            product.AgentName = string.Empty;
            OrderProcess = ProcessOrders.GetPaymentMethod(BL.Models.PaymentFor.BOOKORPHYSICAL);

            //Act
            var ex = OrderProcess.ProcessPayment(product);

            //Assert  
            Assert.AreEqual(ex.Message, "Agent Name is missing.");

        }
    }
}
