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
            Character character = new Character()
            {
                Name = request.Name,
                ImgUrl = request.imageUrl,
                CharacterClass = (CharacterClass)request.CharacterClass,
                Money = 0,
                UserId = request.UserId
            };
            return _repository.Create(character);
        }

        public List<Character> GetAll()
        {
            return _repository.GetAll();
        }

    }
}
