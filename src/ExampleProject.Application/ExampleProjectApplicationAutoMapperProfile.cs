using AutoMapper;
using ExampleProject.Authors;
using ExampleProject.Books;
using ExampleProject.ComicBooks;

namespace ExampleProject;

public class ExampleProjectApplicationAutoMapperProfile : Profile
{
    public ExampleProjectApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();

        CreateMap<Author, AuthorDto>().ReverseMap();
        CreateMap<Author, AuthorLookupDto>().ReverseMap();
        CreateMap<CreateAuthorDto, Author>().ReverseMap();

        CreateMap<ComicBook, ComicBookDto>();
        CreateMap<CreateUpdateComicBookDto, ComicBook>();

    }
}
