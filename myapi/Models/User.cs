using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
      int puntajeDeContraseña = FortalezaDeContraseña();

      if (puntajeDeContraseña < 4)
      {
        yield return new ValidationResult($"La contraseña es {(NivelDeFortaleza)puntajeDeContraseña} agrega mayúsculas, minúsculas, números, símbolos, sin espacios.", new string[] { nameof(Password) });
      }
    }

    private int FortalezaDeContraseña()
    {
      // Fortaleza de la contraseña
      // 1. Al menos un número*
      // 2. Al menos un símbolo (no alfanuméricos)*
      // 3. Al menos debe tener una letra mayúscula*
      // 4. Al menos debe tener una letra minúscula*
      // 5. No puede tener espacios
      // Ej: 1234-Fgrt
      // Map -> Select
      // Reduce -> Aggregate
      // Filter -> Where
      // NivelDeFortaleza ["Muy débil", "Débil", "Regular", "Fuerte", "Muy Fuerte"]
      int puntajeDeContraseña = 0;
      if (Password.Any(c => char.IsDigit(c)))
        puntajeDeContraseña++;
        
      if (Password.Any(c => char.IsSymbol(c)))
        puntajeDeContraseña++;
        
      if (Password.Any(c => char.IsUpper(c)))
        puntajeDeContraseña++;
        
      if (Password.Any(c => char.IsLower(c)))
        puntajeDeContraseña++;
        
      if (!Password.Any(c => char.IsWhiteSpace(c)))
        puntajeDeContraseña++;

      return puntajeDeContraseña;
    }
  }

  public enum gender
  {
    Male, Female
  }

  public enum NivelDeFortaleza
  {
    JODIDO = 0,
    MUY_DÉBIL = 1,
    DÉBIL = 2,
    REGULAR = 3,
    FUERTE = 4,
    MUY_FUERTE = 5
  }
}