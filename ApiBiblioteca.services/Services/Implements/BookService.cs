using ApiBiblioteca.DTO;
using ApiBiblioteca.DTO.Models;
using ApiBiblioteca.services.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBiblioteca.services.Services.Implements
{
    public class BookService : GenericService<Book>, IBookService
    {
        private readonly IBookRepository bookRepository;
        public BookService(IBookRepository bookRepository) : base(bookRepository)
        { 
            this.bookRepository = bookRepository;   
        }

        public async Task<bool> CheckAuthor(int id)
        {
            return await bookRepository.CheckAuthor(id);
        }

        public async Task<bool> CheckQuantity()
        {
            return await bookRepository.CheckQuantity();  
        }

        public async Task<List<Book>> GetByAuthor(string text)
        {
            return await bookRepository.GetByAuthor(text);
        }

        public async Task<List<Book>> GetByTitle(string text)
        {
            return await bookRepository.GetByTitle(text);
        }

        public async Task<List<Book>> GetByYear(int year)
        {
            return await bookRepository.GetByYear(year);
        }
    }
}