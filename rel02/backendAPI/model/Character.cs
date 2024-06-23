namespace backendAPI.model;

public class Character
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    //One to One with Backpack
    public int BackpackId { get; set; }
    
    public BackPack BackPack { get; set; }
    
    //Many to One with weapon
    public List<Weapon> WeaponList { get; set; }
    
    //Many to Many with Faction
    public List<Faction> FactionLsit { get; set; }

}