using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoBHo_GameEngine.Requests
{
    public class CharacterCreateRequest
    {
        public string Name { get; set; }
        public string imageUrl { get; set; }
        public int CharacterClass { get; set; }
        public int UserId { get; set; }
    }
}
