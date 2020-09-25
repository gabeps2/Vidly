using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class RangeNumberInStock:ValidationAttribute
    {
        /*protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movies)validationContext.ObjectInstance;

        }*/
    }
}