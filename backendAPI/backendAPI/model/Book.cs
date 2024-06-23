namespace backendAPI.model;

public class Book
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    //One to Many With Author
    public Author Author { get; set; }
    
    public int AuthorId { get; set; }
    
    //Many to Many with Book-Publisher
    public ICollection<BookPublisher> BookPublishers { get; set; }
    
}