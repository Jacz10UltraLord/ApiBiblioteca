using ApiBiblioteca.DTO;
using ApiBiblioteca.DTO.DTOs;
using ApiBiblioteca.DTO.Models;
using ApiBiblioteca.services.Repositories.Implements;
using ApiBiblioteca.services.Services.Implements;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiBiblioteca.Controllers
{
    [RoutePrefix("api/Books")]
    public class BooksController : ApiController
    {
        private IMapper mapper;
        private readonly BookService bookService = new BookService(new BookRepository(Context.Create()));

        public BooksController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var books = await bookService.GetAll();
            var booksDTO = books.Select(x => mapper.Map<BookDTO>(x));

            return Ok(booksDTO);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var book = await bookService.GetById(id);
            if (book == null)
                return NotFound();

            var bookDTO = mapper.Map<BookDTO>(book);

            return Ok(bookDTO);
        }

        [HttpGet]
        [Route("GetByAuthor/{author}")]
        public async Task<IHttpActionResult> GetByAuthor(string author)
        {
            var books = await bookService.GetByAuthor(author);
            var booksDTO = books.Select(x => mapper.Map<BookDTO>(x));

            return Ok(booksDTO);
        }

        [HttpGet]
        [Route("GetByTitle/{title}")]
        public async Task<IHttpActionResult> GetByTitle(string title)
        {
            var books = await bookService.GetByTitle(title);
            var booksDTO = books.Select(x => mapper.Map<BookDTO>(x));

            return Ok(booksDTO);
        }
        
        [HttpGet]
        [Route("GetByYear/{year}")]
        public async Task<IHttpActionResult> GetByYear(int year)
        {
            var books = await bookService.GetByYear(year);
            var booksDTO = books.Select(x => mapper.Map<BookDTO>(x));

            return Ok(booksDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] BookDTO bookDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if (!await bookService.CheckAuthor(bookDTO.IdAuthor))
                    throw new Exception("El autor no está registrado");

                if (await bookService.CheckQuantity())
                    throw new Exception("No es posible registrar el libro, se alcanzó el máximo permitido.");

                var book = mapper.Map<Book>(bookDTO);
                book = await bookService.Insert(book);
                return Ok(book);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
