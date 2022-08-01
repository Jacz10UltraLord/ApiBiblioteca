using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBiblioteca.DTO.Models
{
    [Table("dbo.Books")]
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }


        public string Genre { get; set; }

        public int Pages { get; set;}

        [ForeignKey("Author")]
        public int IdAuthor { get; set; }

        public virtual Author Author { get; set; }
    }
}