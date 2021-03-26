using System.ComponentModel.DataAnnotations;

namespace RoBHo_GameEngine.Models
{
    public class CharacterLvl
    {
        [Key]
        public int Id { get; set; }

        public int Lvl { get; set; }
        public int CurrentXp { get; set; }
        public LvlType LvlType { get; set; } 

        public Character Character { get; set; }
     
    }
}
