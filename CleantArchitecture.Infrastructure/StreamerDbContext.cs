using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace ClientArchitecture.Data;

public class StreamerDbContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       // base.OnConfiguring(optionsBuilder);

       optionsBuilder.UseSqlServer(
           "data source=localhost; Initial Catalog=StreamersDb; user=sa; password=someThingComplicated1234;TrustServerCertificate=True;")
           .LogTo(Console.WriteLine, new[] {   DbLoggerCategory.Database.Name }, Microsoft.Extensions.Logging.LogLevel.Information
           ).EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Streamer>()
            .HasMany(m => m.Videos)
            .WithOne(m => m.Streamer)
            .HasForeignKey(m => m.StreamerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Video>()
            .HasMany(x => x.Actors)
            .WithMany(x => x.Videos)
            .UsingEntity<VideoActor>(
                pt => pt.HasKey(x => new { x.ActorId, x.VideoId })
            );
    }

    public DbSet<Streamer> Streamers { get; set; }
    public DbSet<Video> Videos { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Director> Director { get; set; }
    public DbSet<VideoActor> VideoActors { get; set; }
    
    public StreamerDbContext()
    {
        
    }
}