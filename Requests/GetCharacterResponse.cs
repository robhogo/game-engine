using RoBHo_GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoBHo_GameEngine.Requests
{
    public class GetCharacterResponse
    {
        public Character Character { get; set; }
        public CharacterLvl CombatLvl { get; set; }
        public CharacterLvl CraftingLvl { get; set; }
        public CharacterLvl GatheringLvl { get; set; }

        public GetCharacterResponse(Character character)
        {
            Character = character;
            CombatLvl = character.CharacterLvls.FirstOrDefault(cl => cl.LvlType == LvlType.combat);
            CraftingLvl = character.CharacterLvls.FirstOrDefault(cl => cl.LvlType == LvlType.crafting);
            GatheringLvl = character.CharacterLvls.FirstOrDefault(cl => cl.LvlType == LvlType.gathering);
            character.CharacterLvls.ForEach(cl => cl.Character = null);
            character.CharacterLvls = null;
        }
    }
}
