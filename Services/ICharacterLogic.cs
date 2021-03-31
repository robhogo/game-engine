using RoBHo_GameEngine.Contexts;
using RoBHo_GameEngine.Contexts.DataModels;
using RoBHo_GameEngine.Models;
using RoBHo_GameEngine.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoBHo_GameEngine.Services
{
    public interface ICharacterLogic
    {
        List<Character> GetAll();
        bool Create(CharacterCreateRequest request);
        List<Character> GetAllByUser(int userId);
    }
}
