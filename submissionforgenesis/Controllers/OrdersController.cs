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
            

            if (allOrdersOnClientId.Any(x=>(x.Price * x.Quantity) > 100))
            {
                return BadRequest("The client owes over 100 euro");
            }



            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Post), new { id = order.OrderId }, order);
            
        }

    }
}
