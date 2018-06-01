using System;
using System.ComponentModel.DataAnnotations;

namespace MyWebsite.Attributes
{
    public class AgeCheckAttribute : ValidationAttribute
    {
        public int MinimumAge { get; private set; }
        public int MaximumAge { get; private set; }

        public AgeCheckAttribute(int minimumAge, int maximumAge)
        {
            MinimumAge = minimumAge;
            MaximumAge = maximumAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var date = Convert.ToDateTime(value);

            if (date.AddYears(MinimumAge) > DateTime.Today
                || date.AddYears(MaximumAge) < DateTime.Today)
            {
                return new ValidationResult(GetErrorMessage(validationContext));
            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage(ValidationContext validationContext)
        {
            // 有帶 ErrorMessage 的话优先使用
            // [AgeCheck(18, 120, ErrorMessage="xxx")] 
            if (!string.IsNullOrEmpty(this.ErrorMessage))
            {
                return this.ErrorMessage;
            }

            // 自定义错误信息
            return $"{validationContext.DisplayName} can't be in future";
        }
    }
}