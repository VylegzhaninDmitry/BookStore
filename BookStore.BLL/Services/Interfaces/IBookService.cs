namespace BookStore.BLL.Services.Interfaces;

public interface IBookService
{
    Task<IEnumerable<BookDto>?> GetBooksByFilteredAsync(FilterParameter parameter);

    Task<BookDto?> GetBookByIdAsync(int id);

    Task<BookDto?> CreateBookAsync(BookDto book);

    Task<bool> DeleteBookAsync(int bookId);

    Task<IEnumerable<BookDto>> Books();
}