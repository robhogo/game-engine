using RoBHo_GameEngine.Contexts;
using RoBHo_GameEngine.Models;
using RoBHo_GameEngine.Repositories;
using RoBHo_GameEngine.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoBHo_GameEngine.Services
{
    public class CharacterLogic : ICharacterLogic
    {
        private readonly ICharacterRepository _repository;

        public CharacterLogic(ICharacterRepository repository)
        {
            _repository = repository;
        }

        public bool Create(CharacterCreateRequest request)
        {
            List<CharacterLvl> characterLvls = new List<CharacterLvl> { new CharacterLvl(LvlType.combat), new CharacterLvl(LvlType.crafting), new CharacterLvl(LvlType.gathering)};

            Character character = new Character()
            {
                Name = request.Name,
                ImgUrl = request.imageUrl,
                CharacterClass = (CharacterClass)request.CharacterClass,
                Money = 0,
                UserId = request.UserId,
                CharacterLvls = characterLvls
            };
            
            return _repository.Create(character);
        }

        public List<Character> GetAll()
        {
            return _repository.GetAll();
        }

        public List<GetCharacterResponse> GetAllByUser(int userId)
        {
            List<GetCharacterResponse> response = new List<GetCharacterResponse>();
            List<Character> characters = _repository.GetAllByUser(userId);
            characters.ForEach(c => response.Add(new GetCharacterResponse(c)));
            return response;
        }
    }
}
