using RoBHo_GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoBHo_GameEngine.Repositories
{
    public interface ICharacterRepository
    {
        List<Character> GetAll();
        bool Create(Character character);
    }
}
