using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myapi.Models
{
    [Table("editorials")]
    public class Editorial
    {
        // Id, Nombre, Domicilio, Correo Electronico, Sitio Web, Telefono, Codigo postal
        [Column("id")]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        [Column("address")]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [Url]
        [Column("website")]
        public string Website { get; set; }

        [Required]
        [Phone]
        [Column("phone")]
        public string Phone { get; set; }

        [Required]
        [Range(1,99999)]
        [Column("postalcode")]
        public int PostalCode { get; set; }
    }
}