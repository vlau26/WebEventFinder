﻿using EventBriteAssignment.Services.OrderApi.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventBriteAssignment.Services.OrderApi.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
         
         public string EventName { get; set; }
        public string PictureUrl { get; set; }
        public decimal UnitPrice { get; set; }
        
        public int Units { get; set; }
        public int EventId { get; private set; }

        protected OrderItem() { }
        public Order Order { get; set; }
        public int OrderId { get; set; }

        public OrderItem(int eventId, string eventName, decimal unitPrice,   string pictureUrl, int units = 1)
        {
            if (units <= 0)
            {
                throw new OrderingDomainException("Invalid number of units");
            }

            EventId = eventId;

            EventName = eventName;
            UnitPrice = unitPrice;
            
            Units = units;
            PictureUrl = pictureUrl;
        }
        public void SetPictureUri(string pictureUri)
        {
            if (!String.IsNullOrWhiteSpace(pictureUri))
            {
                PictureUrl = pictureUri;
            }
        }

         

         

        public void AddUnits(int units)
        {
            if (units < 0)
            {
                throw new OrderingDomainException("Invalid units");
            }

            Units += units;
        }

    }
}
