using AutoMapper;
using ECommerce.Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using EventBusRabbitMQ.Events;

namespace ECommerce.Ordering.API.Mappings
{
    public class OrderingProfile : Profile
    {
        public OrderingProfile()
        {
            CreateMap<CheckoutOrderCommand, BasketCheckoutEvent>().ReverseMap();
        }
    }
}