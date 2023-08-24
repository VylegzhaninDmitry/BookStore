namespace BookStore.BLL.Common.DTO;

public class OrderItemDto
{
    public int? BookId { get; set; }
    
    public BookDto? Book { get; set; }
}