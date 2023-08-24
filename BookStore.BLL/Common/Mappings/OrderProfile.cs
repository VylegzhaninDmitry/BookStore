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
        CreateMap<OrderBook, OrderItemDto>();
        CreateMap<OrderItemDto, OrderBook>();
        CreateMap<CreateOrderItemDto, OrderBook>();
        CreateMap<OrderBook, CreateOrderItemDto>();
        CreateMap<OrderDto, CreateOrderDto>();
    }
}