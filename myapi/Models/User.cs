using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using myapi.Helpers;

namespace myapi.Models
{
  public class User : IValidatableObject
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [MaxLength(50)]
    public string Firstname { get; set; }

    [Required]
    [MaxLength(50)]
    public string Lastname { get; set; }

    [Required]
    [MaxLength(200)]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MaxLength(6)]
    [Gender]
    public string Gender { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 8, ErrorMessage = "El campo {0} debe ser una cadena de texto con longitud entre 8 y 20 caracteres.")]
    public string Name { get; set; }

    [Required]
    [StringLength(12, MinimumLength = 8)/*, Compare(nameof(AnotherPassword))*/]
    public string Password { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      // add logic
      // Fortaleza de la contraseña
      // 1. Al menos un número*
      // 2. Al menos un símbolo (no alfanuméricos)*
      // 3. Al menos debe tener una letra mayúscula*
      // 4. Al menos debe tener una letra minúscula*
      // 5. No puede tener espacios
      // Ej: 1234-Fgrt
      var validacion = new {
        numero = 0,
        simbolo = 0,
        minuscula = 0,
        mayuscula = 0,
        espacio = 0
      };
      foreach (var c in Password)
      {
        // como saber si es número?
        if (char.IsDigit(c))
        {
          validacion.numero++;
        }

        if (char.IsLetter(c) && char.IsUpper(c))
        {
          validacion.mayuscula++;
        }

        if (char.IsLetter(c) && char.IsLower(c))
        {
          validacion.minuscula++;
        }

        if (!char.IsLetterOrDigit(c))
        {
          validacion.simbolo++;
        }
      }

      throw new System.NotImplementedException();
    }

    // [NotMapped]
    // public string AnotherPassword { get; set; }
  }

  public enum gender
  {
    Male, Female
  }
}