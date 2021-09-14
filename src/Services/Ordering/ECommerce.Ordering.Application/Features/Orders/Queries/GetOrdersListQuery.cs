using System.Collections.Generic;
using MediatR;

namespace ECommerce.Ordering.Application.Features.Orders.Queries
{
    public class GetOrdersListQuery : IRequest<IEnumerable<OrdersVm>>
    {
        public string Email { get; set; }

        public GetOrdersListQuery(string email)
        {
            Email = email;
        }
    }
}