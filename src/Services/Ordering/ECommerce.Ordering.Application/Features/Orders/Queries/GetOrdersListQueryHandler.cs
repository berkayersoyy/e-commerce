using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Ordering.Application.Contracts.Persistence;
using MediatR;

namespace ECommerce.Ordering.Application.Features.Orders.Queries
{
    public class GetOrdersListQueryHandler :IRequestHandler<GetOrdersListQuery,IEnumerable<OrdersVm>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrdersVm>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _orderRepository.GetOrdersByEmail(request.Email);
            return _mapper.Map<IEnumerable<OrdersVm>>(orderList);
        }
    }
}