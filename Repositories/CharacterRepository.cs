using Microsoft.EntityFrameworkCore;
using RoBHo_GameEngine.Contexts;
using RoBHo_GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoBHo_GameEngine.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly GameEngineContext _context;

        public CharacterRepository(GameEngineContext context)
        {
            _context = context;
        }

        public bool Create(Character character)
        {
            try
            {
                _context.Add(character);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Character> GetAll()
        {
            return _context.Characters.ToList();
        }

        public List<Character> GetAllByUser(int userId)
        {
           return _context.Characters
                .Include(c => c.CharacterLvls).
                Where(c => c.UserId == userId).ToList();
        }
    }
}
