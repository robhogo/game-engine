using Microsoft.EntityFrameworkCore;
using RoBHo_GameEngine.Contexts.DataModels;

namespace RoBHo_GameEngine.Contexts
{
    public class GameEngineContext : DbContext
    {
        public GameEngineContext(DbContextOptions<GameEngineContext> options) : base(options)
        {
        }

        public DbSet<CharacterDataModel> Characters { get; set; }

        public DbSet<CharacterLvlDataModel> CharacterLvls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            onCharacterCreating(modelBuilder);

            modelBuilder.Entity<CharacterLvlDataModel>()
                .ToTable("CharacterLvls")
                .Property(cl => cl.LvlType)
               .HasConversion<int>();

            base.OnModelCreating(modelBuilder);
        }

        private void onCharacterCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterDataModel>()
                .ToTable("Character")
                .HasMany(c => c.CharacterLvls)
                .WithOne(cl => cl.Character);

            modelBuilder.Entity<CharacterDataModel>()
                .Property(c => c.CharacterClass)
                .HasConversion<int>();
        }
    }
}
