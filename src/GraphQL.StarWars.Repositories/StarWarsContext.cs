using GraphQL.StarWars.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.StarWars.Repositories
{
    public class StarWarsContext : DbContext
    {
        private readonly bool _migrations;

        public StarWarsContext(DbContextOptions<StarWarsContext> context) : base(context)
        {
        }

        public virtual DbSet<Episode> Episodes { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<CharacterFriend> CharacterFriends { get; set; }
        public virtual DbSet<CharacterEpisode> CharacterEpisodes { get; set; }
        public virtual DbSet<Droid> Droids { get; set; }
        public virtual DbSet<Human> Humans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Episode>().HasKey(c => c.Id);
            modelBuilder.Entity<Episode>().Property(e => e.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Planet>().HasKey(c => c.Id);
            modelBuilder.Entity<Planet>().Property(e => e.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Character>().HasKey(c => c.Id);
            modelBuilder.Entity<Character>().Property(e => e.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<CharacterFriend>().HasKey(t => new {t.CharacterId, t.FriendId});

            modelBuilder.Entity<CharacterFriend>()
                .HasOne(cf => cf.Character)
                .WithMany(c => c.CharacterFriends)
                .HasForeignKey(cf => cf.CharacterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CharacterFriend>()
                .HasOne(cf => cf.Friend)
                .WithMany(t => t.FriendCharacters)
                .HasForeignKey(cf => cf.FriendId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CharacterEpisode>().HasKey(t => new {t.CharacterId, t.EpisodeId});

            modelBuilder.Entity<CharacterEpisode>()
                .HasOne(cf => cf.Character)
                .WithMany(c => c.CharacterEpisodes)
                .HasForeignKey(cf => cf.CharacterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CharacterEpisode>()
                .HasOne(cf => cf.Episode)
                .WithMany(t => t.CharacterEpisodes)
                .HasForeignKey(cf => cf.EpisodeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Human>().HasOne(h => h.HomePlanet).WithMany(p => p.Humans);
        }
    }
}