using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ExampleProject.Authors;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using ExampleProject.Web.Pages;
using ExampleProject.Books;
using static ExampleProject.Web.Pages.Books.EditModalModel;
using AutoMapper;

namespace ExampleProject.Web.Pages.Authors;

public class EditModalModel : ExampleProjectPageModel
{
    [BindProperty]
    public EditAuthorViewModel Author { get; set; }

    private readonly IAuthorAppService _authorAppService;

    public EditModalModel(IAuthorAppService authorAppService)
    {
        _authorAppService = authorAppService;
    }

    public async Task OnGetAsync(Guid id)
    {

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<AuthorDto, EditAuthorViewModel>();
        });

        var mapper = config.CreateMapper();


        var authorDto = await _authorAppService.GetAsync(id);
        Author = mapper.Map<AuthorDto, EditAuthorViewModel>(authorDto);

    }

    public async Task<IActionResult> OnPostAsync()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<EditAuthorViewModel, UpdateAuthorDto>();
        });

        var mapper = config.CreateMapper();


        await _authorAppService.UpdateAsync(
            Author.Id,
            mapper.Map<EditAuthorViewModel, UpdateAuthorDto>(Author)
        );

        return NoContent();
    }

    public class EditAuthorViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }

        [Required]
        [StringLength(AuthorConsts.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [TextArea]
        public string ShortBio { get; set; }
    }
}

