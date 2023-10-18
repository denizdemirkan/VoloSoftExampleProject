using AutoMapper;
using ExampleProject.Books;

namespace ExampleProject;

public class ExampleProjectApplicationAutoMapperProfile : Profile
{
    public ExampleProjectApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
    }
}
