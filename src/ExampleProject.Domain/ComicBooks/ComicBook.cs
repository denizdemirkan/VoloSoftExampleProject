using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace ExampleProject.ComicBooks
{
    public class ComicBook : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public PublisherType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }

        public int PageCount { get; set; }
    }
}
