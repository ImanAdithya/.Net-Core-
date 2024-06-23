namespace backendAPI.model;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    //One to One With Publisher
    public Publisher Publisher { get; set; }

    public int PublisherId { get; set; }
    
    //Many to One With Books
    public ICollection<Book> Books { get; set; }
    

}