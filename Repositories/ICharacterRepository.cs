using RoBHo_GameEngine.Contexts;
using RoBHo_GameEngine.Contexts.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoBHo_GameEngine.Repositories
{
    public interface ICharacterRepository
    {
        List<CharacterDataModel> GetAll();
        bool Create(CharacterDataModel character);
        List<CharacterDataModel> GetAllByUser(int userId);
    }
}
