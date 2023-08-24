using AutoMapper;
using BookStore.BLL.Common.DTO;
using BookStore.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

/// <summary>
/// Контроллер для работы с книгами
/// </summary>
[Route("api/book")]
[ApiController]
public sealed class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;

    public BookController(IBookService bookService, IMapper mapper)
    {
        _bookService = bookService;
        _mapper = mapper;
    }

    /// <summary>
    /// Получение данных о книге по id
    /// </summary>
    /// <param name="id">Идентификатор книги</param>
    /// <returns>Возвращает книгу по id</returns>
    [HttpGet("get/{id:int}")]
    public async Task<IActionResult> GetBookByIdAsync(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);
        
        return book is null? BadRequest("Заказ не найден") : Ok(book);
    }

    /// <summary>
    /// Получение отфилтрованного списка книг
    /// </summary>
    /// <param name="parameters">Параметры для фильтра</param>
    /// <returns>Возвращает отфилтрованный список книг</returns>
    [HttpPost("filter")]
    public async Task<IActionResult> FilterAsync([FromBody] FilterParameter parameters) =>
        Ok(await _bookService.GetBooksByFilteredAsync(parameters));

    /// <summary>
    /// Сохранение книги в базу данных
    /// </summary>
    /// <param name="dto">Дто книги</param>
    /// <returns>Возвращащет созданную книгу</returns>
    [HttpPost("create-book")]
    public async Task<IActionResult> CreateBookAsync([FromBody] BookDto dto) =>
        Ok(await _bookService.CreateBookAsync(dto));

    /// <summary>
    /// Удаление книги
    /// </summary>
    /// <param name="id">Идентификатор книги</param>
    /// <returns>Возвращает true, если книга была удалена</returns>
    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> DeleteBookAsync(int id)
    {
        var isDeleted = await _bookService.DeleteBookAsync(id);
        return isDeleted ? Ok(isDeleted) : BadRequest("Не удалось удалить запись");
    }

    /// <summary>
    /// Получение всех книг
    /// </summary>
    /// <returns>Возвращащет список всез книг</returns>
    [HttpGet("get-books")]
    public async Task<IActionResult> GetBooksAsync() =>
        Ok(await _bookService.Books());
}