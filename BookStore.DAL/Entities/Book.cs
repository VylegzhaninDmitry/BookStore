namespace BookStore.DAL.Entities;
public class Book : BaseEntity
{
    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public DateTime PublishedDate  { get; set; }
        
    public int Price { get; set; }
        
    public virtual List<OrderBook>? OrderBooks { get; set; }
}