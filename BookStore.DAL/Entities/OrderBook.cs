namespace BookStore.DAL.Entities;

public class OrderBook : BaseEntity
{
    public int? OrderId { get; set; }
    
    public virtual Order? Order { get; set; }
    
    public int? BookId { get; set; }
    
    public virtual Book? Book { get; set; }
}