using Microsoft.EntityFrameworkCore;

namespace backendAPI.model;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<BookPublisher> BookPublishers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Name).IsRequired();

            entity.HasOne(a => a.Publisher)
                .WithOne(p => p.Author)
                .HasForeignKey<Publisher>(p => p.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Title).IsRequired();

            entity.HasOne(a => a.Author)
               .WithMany(p=>p.Books)
               .HasForeignKey(a=>a.AuthorId)
               .OnDelete(DeleteBehavior.NoAction);
                
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(a => a.id);
            entity.Property(a => a.Name).IsRequired();
        });

        modelBuilder.Entity<BookPublisher>(entity =>
        {
            entity.HasKey(bp => new { bp.PublisherId, bp.BookId });
            
            entity.HasOne(bp=>bp.Book)
                .WithMany(b=>b.BookPublishers)
                .HasForeignKey(bp=> bp.BookId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(bp => bp.Publisher)
                .WithMany(p => p.BookPublishers)
                .HasForeignKey(bp => bp.PublisherId)
                .OnDelete(DeleteBehavior.NoAction);
        });

    }
}