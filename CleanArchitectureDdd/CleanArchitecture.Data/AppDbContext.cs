using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Data
{
    public class AppDbContext: DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
            :base(options)
        {
            _configuration = configuration;            
        }

        public DbSet<Streamer>? Streamers { get; set; }
        public DbSet<Video>? Videos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:DefaultConnection"], options =>
            {
                options.EnableRetryOnFailure(
                maxRetryCount: 5, 
                maxRetryDelay: TimeSpan.FromSeconds(10), // Max time between retry
                errorNumbersToAdd: null);
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StreamerModel>().ToTable("Streamers");
            modelBuilder.Entity<VideoModel>().ToTable("Videos");

            //Relationships:
            modelBuilder.Entity<VideoModel>()
                .HasOne(v => v.Streamer)
                .WithMany(s => s.VideoModels)
                .HasForeignKey(f => f.StreamerId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
