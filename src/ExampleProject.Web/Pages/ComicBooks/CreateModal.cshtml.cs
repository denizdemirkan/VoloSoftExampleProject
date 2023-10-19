using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ExampleProject.Authors;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using ExampleProject.Web.Pages;
using ExampleProject.ComicBooks;
using AutoMapper;

namespace ExampleProject.Web.Pages.ComicBooks;

public class CreateModalModel : ExampleProjectPageModel
{
    [BindProperty]
    public CreateComicBookViewModel ComicBook { get; set; }

    private readonly IComicBookAppService _comicBookAppService;

    public CreateModalModel(IComicBookAppService comicBookAppService)
    {
        _comicBookAppService = comicBookAppService;
    }

    public void OnGet()
    {
        ComicBook = new CreateComicBookViewModel();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CreateComicBookViewModel, CreateUpdateComicBookDto>();
        });

        var mapper = config.CreateMapper();

        var dto = mapper.Map<CreateComicBookViewModel, CreateUpdateComicBookDto>(ComicBook);
        await _comicBookAppService.CreateAsync(dto);
        return NoContent();
    }

    public class CreateComicBookViewModel
    {
        [Required]
        [StringLength(AuthorConsts.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        public PublisherType Type { get; set; }

        [TextArea]
        public DateTime PublishDate { get; set; }
        
        [Required]
        public float Price { get; set; }

        [Required]
        public int PageCount { get; set; }

    }
}
