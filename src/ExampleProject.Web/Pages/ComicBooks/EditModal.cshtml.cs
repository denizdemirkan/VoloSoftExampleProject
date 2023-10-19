using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Threading.Tasks;
using System;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using ExampleProject.ComicBooks;
using AutoMapper;
using ExampleProject.Authors;
using static ExampleProject.Web.Pages.Authors.EditModalModel;
using static ExampleProject.Web.Pages.ComicBooks.CreateModalModel;

namespace ExampleProject.Web.Pages.ComicBooks
{
    public class EditModalModel : ExampleProjectPageModel
    {
        [BindProperty]
        public EditComicBookViewModel ComicBook { get; set; }


        private readonly IComicBookAppService _comicBookAppService;

        public EditModalModel(IComicBookAppService comicBookAppService)
        {
            _comicBookAppService = comicBookAppService;
        }

        public async Task OnGetAsync(Guid id)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ComicBookDto, EditComicBookViewModel>();
            });

            var mapper = config.CreateMapper();

            var comicBookDto = await _comicBookAppService.GetAsync(id);
            ComicBook = mapper.Map<ComicBookDto, EditComicBookViewModel>(comicBookDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateComicBookViewModel, CreateUpdateComicBookDto>();
            });

            var mapper = config.CreateMapper();

            await _comicBookAppService.UpdateAsync(
                ComicBook.Id,
                mapper.Map<EditComicBookViewModel, CreateUpdateComicBookDto>(ComicBook)
            );

            return NoContent();
        }

        public class EditComicBookViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }


            [Required]
            [StringLength(128)]
            public string Name { get; set; }

            [Required]
            public PublisherType Type { get; set; } = PublisherType.Undefined;

            [Required]
            [DataType(DataType.Date)]
            public DateTime PublishDate { get; set; } = DateTime.Now;

            [Required]
            public float Price { get; set; }

            [Required]
            public int PageCount { get; set; }
        }
    }
}
