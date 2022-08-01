using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBiblioteca.DTO.Models
{
    [Table("dbo.Authors")]
    public class Author
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string City { get; set; }

        
        public string Email { get; set; }

        public virtual ICollection<Book> Books { get; set; }  
    }
}