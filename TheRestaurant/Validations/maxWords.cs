using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjRestaurant.Validations
{
    public class maxWords: ValidationAttribute
    {
        private readonly int _maxWords;
        public maxWords(int maxWords)
            : base("{0} has too Many Words")
        {
            _maxWords = maxWords;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value!=null)
            {
                string valString = value.ToString();
                if (valString.Split(' ').Length > _maxWords)
                {
                    var ErrorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}