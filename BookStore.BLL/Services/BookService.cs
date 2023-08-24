using System.ComponentModel.DataAnnotations;
using BookStore.BLL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStore.BLL.Services;

/// <summary>
/// Сервис для работы с книгами
/// </summary>
public sealed class BookService : IBookService
{
    private readonly IRepository<Book> _bookRepository;
    private readonly IMapper _mapper;

    public BookService(IRepository<Book> bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Получение отфилтрованного списка книг
    /// </summary>
    /// <param name="parameters">Параметры для фильтра</param>
    /// <returns>Возвращает отфилтрованный список книг</returns>
    public async Task<IEnumerable<BookDto>?> GetBooksByFilteredAsync(FilterParameter parameters)
    {
        var query = _bookRepository.GetQueryable();

        if (parameters.CreateOn.HasValue)
            query = query.Where(s => s.PublishedDate == parameters.CreateOn.Value);

        if (!string.IsNullOrWhiteSpace(parameters.Title))
            query = query.Where(s => s.Title == parameters.Title);

        var result = _mapper.Map<List<BookDto>>(await query.ToListAsync());
        return result;
    }

    /// <summary>
    /// Получение данных о книге по id
    /// </summary>
    /// <param name="id">Идентификатор книги</param>
    /// <returns>Возвращает книгу по id</returns>
    public async Task<BookDto?> GetBookByIdAsync(int id) =>
        _mapper.Map<BookDto>(await _bookRepository.GetByIdAsync(id));

    /// <summary>
    /// Сохранение книги в базу данных
    /// </summary>
    /// <param name="dto">Дто книги</param>
    /// <returns>Возвращащет созданную книгу</returns>
    public async Task<BookDto?> CreateBookAsync(BookDto dto)
    {
        var book = _mapper.Map<Book>(dto);
        _bookRepository.Create(book);
        await _bookRepository.SaveChangesAsync();
        return _mapper.Map<BookDto>(book);
    }

    /// <summary>
    /// Удаление книги
    /// </summary>
    /// <param name="bookId">Идентификатор книги</param>
    /// <returns>Возвращает true, если книга была удалена</returns>
    public async Task<bool> DeleteBookAsync(int bookId)
    {
        var book = await _bookRepository.GetByIdAsync(bookId);
        if (book is null)
            throw new ValidationException("Книга не найдена");

        _bookRepository.Delete(book);
        await _bookRepository.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Получение всех книг
    /// </summary>
    /// <returns>Возвращащет список всез книг</returns>
    public async Task<IEnumerable<BookDto>> Books() =>
        _mapper.Map<IEnumerable<BookDto>>(await _bookRepository.GetAllAsync());
}