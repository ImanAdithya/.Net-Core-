namespace backendAPI.model;

public class Faction
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    //Many to Many with Character
    public List<Character> CharacterList { get; set; }
    
    
}