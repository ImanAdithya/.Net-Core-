using backendAPI.model;
using Microsoft.EntityFrameworkCore;

namespace backendAPI.Data;

public class AppDbContext :DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Character> Characters { get; set; }
    public DbSet<BackPack> BackPacks { get; set; }
    public DbSet<Weapon> Weapons { get; set; }
    public DbSet<Faction> Factions { get; set; }
    
}