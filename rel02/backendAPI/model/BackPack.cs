using System.Text.Json.Serialization;

namespace backendAPI.model;

public class BackPack
{
    public int Id { get; set; }
    
    public string Description { get; set; }
    
    //One to One with Character
    public int CharacterId { get; set; }
    public Character Character { get; set; }
    
    

}