using System.ComponentModel.DataAnnotations;

namespace myapi.Helpers
{
  public class GenderAttribute: ValidationAttribute
  {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      if (value == null || string.IsNullOrEmpty(value.ToString()))
      {
        return ValidationResult.Success;
      }

      var gender = value.ToString().ToUpper();

      if (gender != "MALE" && gender != "FEMALE")
      {
        return new ValidationResult("El valor de Gender solo puede ser MALE ó FEMALE");
      }

      return ValidationResult.Success;
    }
  }
}