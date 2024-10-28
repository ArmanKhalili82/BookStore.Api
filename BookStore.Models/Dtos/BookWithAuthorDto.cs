namespace BookStore.Models.Dtos;

public class BookWithAuthorDto
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string AuthorName { get; set; }
    public decimal Price { get; set; }
    public DateTime PublishDate { get; set; }
}
