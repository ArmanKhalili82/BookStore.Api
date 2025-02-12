﻿namespace BookStore.Models.Models;

public class Author
{
    public int AuthorId { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public ICollection<Book> Books { get; set; }
}
