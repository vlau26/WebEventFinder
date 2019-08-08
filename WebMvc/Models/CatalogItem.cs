using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Models
{
    public class CatalogItem
    {
        internal string Name;

        public int EventId { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public DateTime EventStartTime { get; set; }
        public DateTime EventEndTime { get; set; }


        public int CatalogCategoryId { get; set; }
        public string CatalogCategory  { get; set; }
        public int CatalogLocationId { get; set; }
        public string  CatalogLocation  { get; set; }

    }
}
