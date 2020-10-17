using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SimpleAPI.Requests
{
    public class CurrencyAttribute : ValidationAttribute
    {
        private readonly IList<string> _acceptedCurrencyCodes = new List<string>
        {
            "EUR",
            "USD",
            "GBR"
        };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return _acceptedCurrencyCodes.Any(c => c == value.ToString())
                ? ValidationResult.Success
                : new ValidationResult($"{validationContext.MemberName} is not an accepted currency");
        }
    }
}