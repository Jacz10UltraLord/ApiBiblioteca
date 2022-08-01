using ApiBiblioteca.DTO;
using ApiBiblioteca.DTO.Models;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBiblioteca.services.Repositories.Implements
{
    public class BookRepository : GenericRepository<Book>, IBookRepository 
    {
        private readonly Context context;
        private readonly int quantity=10; //número de registros de libros permitidos
        public BookRepository(Context context) : base(context)
        { 
            this.context = context;
        }

        public async Task<bool> CheckAuthor(int id)
        {
            var flag = await context.Authors.AnyAsync(x =>x.Id == id);
            return flag;    

        }

        public async Task<bool> CheckQuantity()
        {
            var count = await context.Books.CountAsync()+1;
            return count > quantity;
        }

        public async Task<List<Book>> GetByAuthor(string text)
        {
            var books = await context.Books.Include(x=>x.Author).Where(x => x.Author.Name.Contains(text)).ToListAsync();
            return books;
        }

        public async Task<List<Book>> GetByTitle(string text)
        {
            var books = await context.Books.Where(x => x.Title.Contains(text)).ToListAsync();
            return books;
        }

        public async Task<List<Book>> GetByYear(int year)
        {
            var books = await context.Books.Where(x => x.Year == year).ToListAsync();
            return books;
        }
    }
}