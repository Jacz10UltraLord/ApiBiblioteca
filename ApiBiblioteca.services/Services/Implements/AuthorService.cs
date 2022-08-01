using ApiBiblioteca.DTO.Models;
using ApiBiblioteca.services.Repositories;

namespace ApiBiblioteca.services.Services.Implements
{
    public class AuthorService : GenericService<Author>, IAuthorService
    {
        public AuthorService(IAuthorRepository authorRepository) : base(authorRepository)
        { 

        }
    }
}