using AutoMapper;
using BookStore.BLL.Common.DTO;
using BookStore.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

/// <summary>
/// Контроллер для работы с заказами
/// </summary>
[Route("api/order")]
[ApiController]
public sealed class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public OrderController(IOrderService orderService, IMapper mapper)
    {
        _mapper = mapper;
        _orderService = orderService;
    }

    /// <summary>
    /// Получение отфильтрованного списка заказов
    /// </summary>
    /// <param name="parameters">Параметры для фильтра</param>
    /// <returns>Возвращает отфилтрованный список заказов</returns>
    [HttpPost("filter")]
    public async Task<IActionResult> GetOrdersByFilteredAsync([FromBody] FilterParameter parameters) =>
        Ok(await _orderService.GetOrdersByFilteredAsync(parameters));

    /// <summary>
    /// Получение заказа по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Возвращает заказ по id</returns>
    [HttpGet("get-order/{id:int}")]
    public async Task<IActionResult> GetOrderByIdAsync(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        
        return order is null? BadRequest("Заказ не найден") : Ok(order);
    }

    /// <summary>
    /// Создание заказа
    /// </summary>
    /// <param name="dto">Дто заказа</param>
    /// <returns>Возвращащет созданный заказ</returns>
    [HttpPost("create-order")]
    public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderDto dto) =>
        Ok(await _orderService.CreateOrderAsync(dto));
}