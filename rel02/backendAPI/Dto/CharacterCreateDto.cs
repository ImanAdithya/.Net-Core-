namespace backendAPI.Dto;

public record struct CharacterCreateDto(
    string Name,
    BackpackCreateDto backpack,
    List<WeaponCreateDto> Wepons, 
    List<FactionCreateDto> Factions);