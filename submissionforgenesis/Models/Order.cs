using System;
using System.Collections.Generic;

namespace submissionforgenesis.Models
{
    public class Order
    {
        public long OrderId { get; set; }
        public int ProductId { get; set; }
        public long ClientId { get; set; }
        public string DeliveryAddress { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
   

    }
}
