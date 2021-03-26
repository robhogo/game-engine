using RoBHo_GameEngine.Contexts;
using RoBHo_GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoBHo_GameEngine.Services
{
    public class CharacterLogic : ICharacterLogic
    {
        private readonly GameEngineContext _context;

        public CharacterLogic(GameEngineContext context)
        {
            _context = context;
        }

        public List<Character> GetAll()
        {
            return _context.Characters.ToList();
        }
    }
}
