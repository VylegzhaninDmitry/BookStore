using AutoMapper;
using BookStore.BLL.Common.DTO;
using BookStore.DAL.Entities;

namespace BookStore.API.AutoMapper;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookDto>().ReverseMap();
    }
}