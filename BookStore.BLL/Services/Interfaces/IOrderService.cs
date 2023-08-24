namespace BookStore.BLL.Services.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>?> GetOrdersByFilteredAsync(FilterParameter parameter);

    Task<OrderDto?> GetOrderByIdAsync(int id);

    Task<OrderDto?> CreateOrderAsync(CreateOrderDto dto);
}