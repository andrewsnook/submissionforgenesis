using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using submissionforgenesis.Helpers;
using submissionforgenesis.Models;

namespace submissionforgenesis.Controllers
{
    [Route("api/Orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly OrderContext _context;

        // seed
        public OrdersController(OrderContext context)
        {
            _context = context;

            if (_context.Orders.Count() == 0)
            {
                //    var product = new Product
                //    {
                //        Id = 1,
                //        Name = "Product 1",
                //        Price = 3.99M
                //    };
                //    var listOfProducts = new List<Product>();
                //    listOfProducts.Add(product);
                //    _context.Orders.Add(new Order
                //    {
                //        OrderId = 1,
                //        ClientId = 123,
                //        ProductId = 1,
                //        Address1 = "123 Fake st",
                //        Address2 = "Fake Town",
                //        County = "Cork",
                //        Country = "Ireland"

                //    });
                //    _context.SaveChanges();
                OrdersHelpers helper = new OrdersHelpers();
                helper.SeedOrders(_context);
            }

            
        }

        
        [HttpGet]
        public List<Order> Get()
        {
            return _context.Orders.ToList();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetAsync(long id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Order>> Post(Order order)
        {
            // validate
            var moreThan10AreOnOrder = _context.Orders.Any(x => x.ProductId == order.ProductId && x.Quantity > 10);
            if (moreThan10AreOnOrder)
            {
                return BadRequest("More than 10 of this product are on order");
            }

            var allOrdersOnClientId = _context.Orders.Where(x => x.ClientId == order.ClientId);
            

            if (allOrdersOnClientId.Any(x=>x.Price > 100))
            {
                return BadRequest("The client owes over 100 euro");
            }



            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Post), new { id = order.OrderId }, order);
            


        }

    }
}
