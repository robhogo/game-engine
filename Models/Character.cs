using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoBHo_GameEngine.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CharacterClass CharacterClass { get; set; }
        public int Money { get; set; }
        public string ImgUrl { get; set; }

        public CharacterLvl CombatLvl { get; set; }
        public CharacterLvl CraftingLvl { get; set; }
        public CharacterLvl GatheringLvl { get; set; }

        public int UserId { get; set; }
    }
}
