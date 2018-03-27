using Chapter8_SportsStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter8_SportsStore.Data
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext dbContext;

        public EFOrderRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IQueryable<Order> Orders => dbContext.Orders.Include(o => o.Lines).ThenInclude(l => l.Product);

        public void SaveOrder(Order order)
        {
            dbContext.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0)
            {
                dbContext.Orders.Add(order);
            }
            dbContext.SaveChanges();
        }
    }
}
