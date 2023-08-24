namespace BookStore.BLL.Common.DTO;

public class CreateOrderDto
{
    public DateTime CreatedOn { get; set; }
    public List<CreateOrderItemDto>? Items { get; set; }
}