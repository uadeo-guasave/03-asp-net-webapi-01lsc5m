using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using myapi.Helpers;

namespace myapi.Models
{
  public class User
  {
    public int Id { get; set; }

    [Required(ErrorMessage="El campo {0} es obligatorio."), MaxLength(50)]
    public string Firstname { get; set; }

    [Required, MaxLength(50)]
    public string Lastname { get; set; }

    [Required, MaxLength(200), EmailAddress]
    public string Email { get; set; }

    [Required, MaxLength(6), Gender]
    public string Gender { get; set; }

    [Required, StringLength(20, MinimumLength = 8, ErrorMessage="El campo {0} debe ser una cadena de texto con longitud entre 8 y 20 caracteres.")]
    public string Name { get; set; }

    [Required, StringLength(12, MinimumLength = 8)/*, Compare(nameof(AnotherPassword))*/]
    public string Password { get; set; }

    // [NotMapped]
    // public string AnotherPassword { get; set; }
  }

  public enum gender
  {
    Male, Female
  }
}