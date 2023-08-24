namespace BookStore.BLL.Common.DTO;

public class OrderDto
{
    public int Id { get; set; }
    
    public DateTime CreatedOn { get; set; }

    public decimal? TotalPrice { get; set; }
    public List<OrderItemDto>? OrderBooks { get; set; }
}