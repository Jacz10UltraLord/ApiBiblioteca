using System.ComponentModel.DataAnnotations;

namespace ApiBiblioteca.DTO.DTOs
{
    public class BookDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required, StringLength(255)]

        public string Genre { get; set; }

        [Required]
        public int Pages { get; set; }

        [Required]
        public int IdAuthor { get; set; }

        public virtual AuthorDTO Author { get; set; }
    }
}