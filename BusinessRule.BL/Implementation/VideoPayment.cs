using BusinessRule.BL.Interfaces;
using BusinessRule.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRule.BL.Implementation
{
    public class VideoPayment : IProcessOrder
    {
        public PaymentResult ProcessPayment(ProductInfo model)
        {
            if (!string.IsNullOrEmpty(model.Description))
            {
                if (model.Description.ToLowerInvariant() == VideoTypes.VIDEO_TITLE_FOR_CHECK)
                {
                    return new PaymentResult
                    {
                        IsSuccess = true,
                        Message = "Added First Aid video to the packing slip."
                    };
                }
                else
                {
                    return new PaymentResult
                    {
                        IsSuccess = true,
                        Message = "Generated Packing slip"
                    };
                }
            }
            else
            {
                throw new InvalidOperationException("Video Descrption is missing");
            }
        }
    }
}
