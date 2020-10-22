using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myapi.Models
{
  [Table("authors")]
  public class Author
  {
    [Column("id")]
    public int Id { get; set; }

    [Column("firstname")]
    [Required, MaxLength(50)]
    public string Firstname { get; set; }

    [Column("lastname")]
    [Required, MaxLength(50)]
    public string Lastname { get; set; }

    [Column("age")]
    [Required]
    public int Age { get; set; }

    [Column("email")]
    [Required, MaxLength(200), EmailAddress]
    public string Email { get; set; }
  }
}