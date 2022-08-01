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
    [RoutePrefix("api/Authors")]
    public class AuthorsController : ApiController
    {
        private IMapper mapper;
        private readonly AuthorService authorService = new AuthorService(new AuthorRepository(Context.Create()));

        public AuthorsController()
        { 
            this.mapper= WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        { 
            var authors = await authorService.GetAll(); 
            var authorsDTO = authors.Select(x => mapper.Map<AuthorDTO>(x));

            return Ok(authorsDTO);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var author = await authorService.GetById(id);
            if(author == null)
                return NotFound();

            var authorDTO = mapper.Map<AuthorDTO>(author);  

            return Ok(authorDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] AuthorDTO authorDTO)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);  

            try
            {
                var author = mapper.Map<Author>(authorDTO);
                author = await authorService.Insert(author);
                return Ok(author);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
