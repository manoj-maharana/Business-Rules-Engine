using BusinessRule.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using BusinessRule.BL.UtilityClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessRule.UnitTest
{
    [TestClass]
    public class VideoPaymentTest : SampleInput
    {
        IProcessOrder OrderProcess;

        [TestMethod]
        public void Valid_VideoOrder()
        {
            //arrange
            var video = GetProductInfo().Where(x => x.ProductType == BL.Models.ProductFor.VIDEO).FirstOrDefault();
            OrderProcess = ProcessOrders.GetPaymentMethod(BL.Models.PaymentFor.VIDEO);
            video.Description = "learning to msi";
            video.PackagingDate = DateTime.Today;

            //act
            var result = OrderProcess.ProcessPayment(video);

            //assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("Added First Aid video to the packing slip.", result.Message);

        }

        [TestMethod]
        public void Process_Empty_PhysicalProduct()
        {
            //arrange
            var video = GetProductInfo().Where(x => x.ProductType == BL.Models.ProductFor.VIDEO).FirstOrDefault();
            OrderProcess = ProcessOrders.GetPaymentMethod(BL.Models.PaymentFor.VIDEO);
            video.Description = string.Empty;

            //Act
            var ex = OrderProcess.ProcessPayment(video);

            //Assert  
            Assert.AreEqual(ex.Message, "Video Descrption is missing");

        }
    }
}
