using Microsoft.EntityFrameworkCore;
using RoBHo_GameEngine.Models;

namespace RoBHo_GameEngine.Contexts
{
    public class GameEngineContext : DbContext
    {
        public GameEngineContext(DbContextOptions<GameEngineContext> options) : base(options)
        {
        }

        public DbSet<Character> Characters { get; set; }

        public DbSet<CharacterLvl> CharacterLvls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            onCharacterCreating(modelBuilder);

            modelBuilder.Entity<CharacterLvl>()
                .ToTable("CharacterLvls")
                .Property(cl => cl.LvlType)
               .HasConversion<int>();

            base.OnModelCreating(modelBuilder);
        }

        private void onCharacterCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>()
                .ToTable("Character")
                .Property(c => c.CharacterClass)
                .HasConversion<int>();

        }
    }
}
