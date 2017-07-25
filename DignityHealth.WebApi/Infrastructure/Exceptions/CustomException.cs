using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DentalWarranty.WebApi.Infrastructure.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(String message)
            : base(message)
        {
            message = string.Format("Invalid or missing parameters {0}", message);
        }
    }​
}