namespace BookStore.BLL.Common.Mappings;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<OrderDto, Order>()
            .ForMember(dest => dest.TotalPrice, 
                opt => opt.MapFrom(src => src.TotalPrice));
        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.TotalPrice, 
                opt => opt.MapFrom(src => src.TotalPrice));
        CreateMap<OrderItem, OrderItemDto>();
        CreateMap<OrderItemDto, OrderItem>();
        CreateMap<CreateOrderItemDto, OrderItem>();
        CreateMap<OrderItem, CreateOrderItemDto>();
        CreateMap<OrderDto, CreateOrderDto>();
    }
}