using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBriteAssignment.Services.CartApi.Model
{
    public class CartItem
    {
        public string Id { get; set; }
        public int EventId { get; set; }
        public string EventName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal OldPrice { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
    }
}
