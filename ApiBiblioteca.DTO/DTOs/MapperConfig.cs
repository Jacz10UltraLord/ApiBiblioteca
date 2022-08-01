using ApiBiblioteca.DTO.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiBiblioteca.DTO.DTOs
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguration()
        { 
            return new MapperConfiguration(cfg =>{ 
                cfg.CreateMap<Author, AuthorDTO>();
                cfg.CreateMap<AuthorDTO,Author>();

                cfg.CreateMap<Book, BookDTO>();
                cfg.CreateMap<BookDTO, Book>();
            });
        }
    }
}