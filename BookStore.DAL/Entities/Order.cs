namespace BookStore.DAL.Entities;

public class Order : BaseEntity
{
    public DateTime CreatedOn { get; set; }

    public decimal TotalPrice { get; set; }
        
    public virtual List<OrderBook>? OrderBooks { get; set; }
}