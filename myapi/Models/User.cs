using System.ComponentModel.DataAnnotations;

namespace myapi.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Firstname { get; set; }
        [Required, MaxLength(50)]
        public string Lastname { get; set; }
        [Required, MaxLength(200)]
        public string Email { get; set; }
        [Required, MaxLength(6)]
        public gender Gender { get; set; }
        [Required, MaxLength(20)]
        public string Name { get; set; }
        [Required, MaxLength(12)]
        public string Password { get; set; }
    }

    public enum gender
    {
        MALE, FEMALE
    }
}