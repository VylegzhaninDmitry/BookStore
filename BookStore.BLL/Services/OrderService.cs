using System.ComponentModel.DataAnnotations;
using BookStore.BLL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStore.BLL.Services;

/// <summary>
/// Сервис для работы с заказами
/// </summary>
public sealed class OrderService : IOrderService
{
    private readonly IRepository<Order> _orderRepository;
    private readonly IRepository<Book> _bookRepository;
    private readonly IMapper _mapper;

    public OrderService(IRepository<Order> orderRepository, IRepository<Book> bookRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _bookRepository = bookRepository;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Получение отфильтрованного списка заказов
    /// </summary>
    /// <param name="parameters">Параметры для фильтра</param>
    /// <returns>Возвращает отфилтрованный список заказов</returns>
    public async Task<IEnumerable<OrderDto>?> GetOrdersByFilteredAsync(FilterParameter parameters)
    {
        var query = _orderRepository.GetQueryable();

        if (parameters.CreateOn.HasValue)
            query = query.Where(s => s.CreatedOn == parameters.CreateOn.Value);

        if (parameters.OrderId.HasValue)
            query = query.Where(s => s.Id == parameters.OrderId);

        var result = _mapper.Map<List<OrderDto>>(await query.ToListAsync());
        return result;
    }

    /// <summary>
    /// Получение заказа по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Возвращает заказ по id</returns>
    public async Task<OrderDto?> GetOrderByIdAsync(int id)
    {
        var entity = await _orderRepository.GetByIdAsync(id);
        if (entity is null)
            throw new ValidationException("Заказ не найден");
        
        return _mapper.Map<OrderDto>(entity);
    }

    /// <summary>
    /// Создание заказа
    /// </summary>
    /// <param name="dto">Список книг для заказа</param>
    /// <returns>Возвращащет созданный заказ</returns>
    public async Task<OrderDto?> CreateOrderAsync(CreateOrderDto dto)
    {
        var orderItems = _mapper.Map<List<OrderBook>>(dto.Items);
        var bookIds = orderItems.Select(s => s.BookId!.Value).ToList();
        var books =  _bookRepository.GetQueryable().Where(i => bookIds.Contains(i.Id));
        var order = new Order
        {
            CreatedOn = DateTime.UtcNow.ToLocalTime(),
            TotalPrice = books.Sum(s => s.Price),
            OrderBooks = orderItems.Where(s => books.AsEnumerable().Any(i => i.Id == s.BookId)).ToList()
        };

        _orderRepository.Create(order);
        await _orderRepository.SaveChangesAsync();
        return _mapper.Map<OrderDto>(order);
    }
}