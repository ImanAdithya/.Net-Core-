namespace backendAPI.model;

public class BookPublisher
{
    public Book Book { get; set; }
    
    public int BookId { get; set; }

    public Publisher Publisher { get; set; }

    public int PublisherId { get; set; }
}