using System;
using System.Collections.Generic;
using submissionforgenesis.Models;

namespace submissionforgenesis.Helpers
{
    public class OrdersHelpers
    {

        public void SeedOrders(OrderContext orderContext)
        {



            orderContext.Orders.Add(new Order
            {
                OrderId = 1,
                ClientId = 122,
                ProductId = 3,
                DeliveryAddress = "123 Fake st",
                Quantity = 3

            });



            orderContext.Orders.Add(new Order
            {
                OrderId = 456,
                ClientId = 123,
                ProductId = 2,
                DeliveryAddress = "Wayne Manor",
                Quantity = 11,
                Price = 50

            });


            orderContext.Orders.Add(new Order
            {
                OrderId = 345,
                ClientId = 124,
                ProductId = 1,
                DeliveryAddress = "Test",
                Quantity = 2,
                Price = 100

            });


            orderContext.SaveChanges();


        }
    }
}
