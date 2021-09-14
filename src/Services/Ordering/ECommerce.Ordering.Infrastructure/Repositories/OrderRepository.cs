using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Ordering.Application.Contracts.Persistence;
using ECommerce.Ordering.Domain.Entities;
using ECommerce.Ordering.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Ordering.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>,IOrderRepository
    {
        public OrderRepository(OrderContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Order>> GetOrdersByEmail(string email)
        {
            var orderList = await _dbContext.Orders.Where(o => o.Email == email).ToListAsync();
            return orderList;
        }
    }
}