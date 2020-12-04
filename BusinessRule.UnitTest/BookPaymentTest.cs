using System;
using System.Linq;
using BusinessRule.BL.Interfaces;
using BusinessRule.BL.UtilityClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessRule.UnitTest
{
    [TestClass]
    public class BookPaymentTest : SampleInput
    {
        IProcessOrder OrderProcess;
        [TestMethod]
        public void Valid_BookOrder()
        {
            //Arrange
            var book = GetProductInfo().Where(x => x.ProductType == BL.Models.ProductFor.BOOK).FirstOrDefault();
            OrderProcess = ProcessOrders.GetPaymentMethod(BL.Models.PaymentFor.BOOK);
            double royaltyAmount = book.Price * book.Quantity * book.Commission;
            string message = "Payment slip created with Amount -" + royaltyAmount;

            //Act
            var result = OrderProcess.ProcessPayment(book);

            //Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(message, result.Message);
        }
        [TestMethod]
        public void Process_Empty_BookOrder()
        {
            //arrange
            var book = GetProductInfo().Where(x => x.ProductType == BL.Models.ProductFor.BOOK).FirstOrDefault();
            book.Name = string.Empty;
            OrderProcess = ProcessOrders.GetPaymentMethod(BL.Models.PaymentFor.BOOK);
            double royaltyAmount = book.Price * book.Quantity * book.Commission;

            //Act
            var ex = OrderProcess.ProcessPayment(book);
            //assert          

            Assert.AreEqual(ex.Message, "Book Name is missing");
        }
    }
}
