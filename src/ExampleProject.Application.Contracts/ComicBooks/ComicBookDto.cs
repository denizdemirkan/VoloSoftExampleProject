using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ExampleProject.ComicBooks
{
    public class ComicBookDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public PublisherType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }

        public int PageCount { get; set; }
    }
}
