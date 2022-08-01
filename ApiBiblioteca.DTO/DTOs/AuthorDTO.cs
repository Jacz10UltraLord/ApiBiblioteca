using System;
using System.ComponentModel.DataAnnotations;

namespace ApiBiblioteca.DTO.DTOs
{
    public class AuthorDTO
    {
        [Required(ErrorMessage = "Campo requerido")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo requerido"), StringLength(255)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo requerido")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Campo requerido"), StringLength(255)]
        public string City { get; set; }

        [Required(ErrorMessage = "Campo requerido"), EmailAddress]
        public string Email { get; set; }
    }
}