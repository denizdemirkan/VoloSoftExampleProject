using ExampleProject.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using System.Linq.Dynamic.Core;
using Volo.Abp.Domain.Repositories;

namespace ExampleProject.ComicBooks
{
    [Authorize(ExampleProjectPermissions.ComicBooks.Default)]
    public class ComicBookAppService :
        CrudAppService<
            ComicBook, //The ComicBook entity
            ComicBookDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateComicBookDto>, //Used to create/update a book
        IComicBookAppService //implement the IBookAppService
    {
        public ComicBookAppService(
            IRepository<ComicBook, Guid> repository)
            : base(repository)
        {
            GetPolicyName = ExampleProjectPermissions.ComicBooks.Default;
            GetListPolicyName = ExampleProjectPermissions.ComicBooks.Default;
            CreatePolicyName = ExampleProjectPermissions.ComicBooks.Create;
            UpdatePolicyName = ExampleProjectPermissions.ComicBooks.Edit;
            DeletePolicyName = ExampleProjectPermissions.ComicBooks.Delete;
        }

        public override async Task<ComicBookDto> GetAsync(Guid id)
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join books and authors
            var query = from comicbook in queryable
                        select new { comicbook};

            //Execute the query and get the book with author
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(ComicBook), id);
            }

            var comicBookDto = ObjectMapper.Map<ComicBook, ComicBookDto>(queryResult.comicbook);
            return comicBookDto;
        }

        public override async Task<PagedResultDto<ComicBookDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join books and authors
            var query = from comicbook in queryable
                        select new { comicbook};

            //Paging
            query = query
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            //Execute the query and get a list
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of BookDto objects
            var comicBookDtos = queryResult.Select(x =>
            {
                var comicBookDto = ObjectMapper.Map<ComicBook, ComicBookDto>(x.comicbook);
                return comicBookDto;
            }).ToList();

            //Get the total count with another query
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<ComicBookDto>(
                totalCount,
                comicBookDtos
            );
        }



        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"comicbook.{nameof(ComicBook.Name)}";
            }

            return $"comicbook.{sorting}";
        }
    }
}