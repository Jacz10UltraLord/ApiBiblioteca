using ApiBiblioteca.DTO;
using ApiBiblioteca.DTO.Models;

namespace ApiBiblioteca.services.Repositories.Implements
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(Context context) : base(context)
        { 

        }
    }
}