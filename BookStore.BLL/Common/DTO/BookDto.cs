namespace BookStore.BLL.Common.DTO
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime PublishedDate  { get; set; }
        public string Author { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}