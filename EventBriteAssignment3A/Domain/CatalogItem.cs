using System;
using System.ComponentModel.DataAnnotations;

namespace EventBriteCatalog.Domain
{
    public class CatalogItem
    {
        public int EventId { get; set; } 
        public string EventName { get; set; } 
        public string Description { get; set; } 
        public decimal Price { get; set; } 
        public string PictureUrl { get; set; } 

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Time")]
        public DateTime EventStartTime { get; set; }  

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Time")]
        public DateTime EventEndTime { get; set; } 

        public int CatalogCategoryId { get; set; }
        public virtual CatalogCategory Category { get; set; }
        public int CatalogLocationId { get; set; }
        public virtual CatalogLocation Location { get; set; }

    }
}
