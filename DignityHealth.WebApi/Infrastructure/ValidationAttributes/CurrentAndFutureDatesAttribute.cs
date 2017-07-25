using System;
using System.ComponentModel.DataAnnotations;

namespace DignityHealth.WebApi.Infrastructure.ValidationAttributes
{
    /// <summary>
    /// Current And Future Dates Attribute
    /// </summary>
    public class CurrentAndFutureDatesAttribute : ValidationAttribute
    {
        /// <summary>
        /// Overrides IsValid method to handle our custom logic to check allowed values for this property.
        /// </summary>
        /// <param name="value">Received values</param>
        /// <returns>Boolean</returns>
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            if (DateTime.Compare(GetDateFromString(Convert.ToDateTime(value).ToShortDateString()), GetDateFromString(DateTime.Now.ToShortDateString())) >= 0)
                return true;
            return false;
        }

        /// <summary>
        /// Get Date from String
        /// </summary>
        /// <param name="inputDate">Input Date</param>
        /// <returns>DateTime</returns>
        private DateTime GetDateFromString(string inputDate)
        {
            return Convert.ToDateTime(inputDate);
        }
    }
}