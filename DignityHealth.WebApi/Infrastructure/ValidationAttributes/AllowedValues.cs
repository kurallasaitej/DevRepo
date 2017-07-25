using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace DignityHealth.WebApi.Infrastructure.ValidationAttributes
{
    /// <summary>
    /// Validation to take only the comma separated allowed values.
    /// </summary>
    public class AllowedValues : ValidationAttribute
    {     
        /// <summary>
        /// Takes allowed values with comma separation.
        /// </summary>
        public string CommaSeparatedValues { get; set; }

        /// <summary>
        /// Overrides IsValid method to handle our custom logic to check allowed values for this property.
        /// </summary>
        /// <param name="value">Received values</param>
        /// <returns>Boolean</returns>
        public override bool IsValid(object value)
        {
            string receivedvalue =Convert.ToString(value);
            if (string.IsNullOrEmpty(receivedvalue))
            {
                //As there are no values assigned to the property,no need to validate.
                return true;
            }
                        
            if (CommaSeparatedValues.ToLower().Split(',').Contains(receivedvalue.ToLower())) 
            {
                //If the assigned value is part of allowed values,then validation is true.
                return true;
            }
            return false;
        }       
    }
}