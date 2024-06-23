using backendAPI.Data;
using backendAPI.Dto;
using backendAPI.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backendAPI.controller;

[Route("api/[controller]")]
[ApiController]
public class TlouController : ControllerBase
{
    public readonly AppDbContext _context;

    public TlouController(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }

    [HttpPost]
    public async Task<ActionResult<List<Character>>> CreateCharacter(CharacterCreateDto createDto)
    {
        var newCharacter = new Character
        {
            Name=createDto.Name,
        };

        var backpack = new BackPack
        {
            Description = createDto.backpack.Description,
            Character = newCharacter
        };

        var weapons = createDto.Wepons.
            Select(w=>new Weapon
            { Name=w.Name, Character = newCharacter }).ToList();
        
        var factions = createDto.Factions.
            Select(f=>new Faction
                { Name=f.Name, CharacterList = new List<Character>{newCharacter} }).ToList();

        newCharacter.BackPack = backpack;
        newCharacter.WeaponList = weapons;
        newCharacter.FactionLsit = factions;
        
        
        _context.Characters.Add(newCharacter);
        await _context.SaveChangesAsync();

        return Ok(await _context.Characters
            .Include(c => c.BackPack)
            .Include(c=>c.WeaponList)
            .ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Character>> GetCharacterById(int id)
    {
        var character = await _context.Characters
            .Include(c => c.BackPack)
            .Include(c => c.WeaponList)
            .Include(c => c.FactionLsit)
            .FirstOrDefaultAsync(c => c.Id == id);

        return Ok(character);
    }

}