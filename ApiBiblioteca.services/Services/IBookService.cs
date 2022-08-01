using ApiBiblioteca.DTO.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBiblioteca.services.Services
{
    public interface IBookService : IGenericService<Book>
    {
        Task<bool> CheckAuthor(int id);
        Task<bool> CheckQuantity();

        Task<List<Book>> GetByAuthor(string text);
        Task<List<Book>> GetByTitle(string text);
        Task<List<Book>> GetByYear(int year);

    }
}
