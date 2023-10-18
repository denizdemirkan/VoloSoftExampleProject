using AutoMapper;
using ExampleProject.Books;

namespace ExampleProject.Web;

public class ExampleProjectWebAutoMapperProfile : Profile
{
    public ExampleProjectWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.

        CreateMap<BookDto, CreateUpdateBookDto>();
    }
}
