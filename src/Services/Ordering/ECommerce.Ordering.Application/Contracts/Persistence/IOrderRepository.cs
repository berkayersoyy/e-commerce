using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Ordering.Domain.Entities;

namespace ECommerce.Ordering.Application.Contracts.Persistence
{
    public interface IOrderRepository:IAsyncRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByEmail(string email);
    }
}