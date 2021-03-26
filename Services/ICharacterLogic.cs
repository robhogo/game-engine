using RoBHo_GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoBHo_GameEngine.Services
{
    public interface ICharacterLogic
    {
        List<Character> GetAll();
    }
}
