using AutoMapper;
using ExampleProject.Authors;
using ExampleProject.Books;

namespace ExampleProject;

public class ExampleProjectApplicationAutoMapperProfile : Profile
{
    public ExampleProjectApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        CreateMap<Author, AuthorDto>();
    }
}
