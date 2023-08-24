namespace BookStore.BLL.Common.DTO;

public class FilterParameter
{
    public DateTime? CreateOn { get; set; }
    
    public string? Title { get; set; }
    
    public int? OrderId { get; set; }
}