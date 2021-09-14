using AutoMapper;
using ECommerce.Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using ECommerce.Ordering.Application.Features.Orders.Commands.UpdateOrder;
using ECommerce.Ordering.Application.Features.Orders.Queries;
using ECommerce.Ordering.Domain.Entities;

namespace ECommerce.Ordering.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrdersVm>().ReverseMap();
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
        }
    }
}