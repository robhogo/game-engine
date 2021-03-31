using System.ComponentModel.DataAnnotations;

namespace RoBHo_GameEngine.Contexts.DataModels
{
    public class CharacterLvlDataModel
    {
        [Key]
        public int Id { get; set; }
        public int Lvl { get; set; }
        public int CurrentXp { get; set; }
        public LvlType LvlType { get; set; } 
        public CharacterDataModel Character { get; set; }
     
    }
}
