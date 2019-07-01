using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBriteCatalog.Domain
{
    public class CatalogItem
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public DateTime EventTime { get; set; }
        public int CatalogCategoryId { get; set; }
        public virtual CatalogCategory Category { get; set; }
        public int CatalogLocationId { get; set; }
        public virtual CatalogLocation Location { get; set; }

    }
}
