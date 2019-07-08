using System;
using Microsoft.EntityFrameworkCore;

namespace submissionforgenesis.Models
{
    public class OrderContext: DbContext
    {
        public OrderContext()
        {
        }

        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    

    }
}
