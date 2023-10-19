using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ExampleProject.ComicBooks
{
    public interface IComicBookAppService :
        ICrudAppService< //Defines CRUD methods
            ComicBookDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateComicBookDto> //Used to create/update a book
    {
    }
}
