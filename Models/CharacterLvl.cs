using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoBHo_GameEngine.Models
{
    public class CharacterLvl
    {
        public int Id { get; set; }
        public int Lvl { get; set; }
        public int CurrentXp { get; set; }
        public LvlType LvlType { get; set; }
    }
}
