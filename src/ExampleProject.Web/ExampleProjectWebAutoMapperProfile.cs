using AutoMapper;
using ExampleProject.Authors;
using ExampleProject.Books;
using ExampleProject.Web.Pages.Authors;

namespace ExampleProject.Web;

public class ExampleProjectWebAutoMapperProfile : Profile
{
    public ExampleProjectWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.

        CreateMap<BookDto, CreateUpdateBookDto>();
        CreateMap<Pages.Books.CreateModalModel.CreateBookViewModel, CreateUpdateBookDto>();
        CreateMap<BookDto, Pages.Books.EditModalModel.EditBookViewModel>();
        CreateMap<Pages.Books.EditModalModel.EditBookViewModel, CreateUpdateBookDto>();

        // ADD a NEW MAPPING
        CreateMap<CreateModalModel.CreateAuthorViewModel,
                    CreateAuthorDto>();
    }
}
