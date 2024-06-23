using System.Collections;

namespace backendAPI.model;

public class Publisher
{
    public int id { get; set; }
    
    public string Name { get; set; }
    
    //One to One With Author
    public Author Author { get; set; }
    
    public int AuthorId { get; set; }
    
    //Many to Many with Book-Publisher
    public ICollection<BookPublisher> BookPublishers { get; set; }
}