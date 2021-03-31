using RoBHo_GameEngine.Contexts.Converters;
using RoBHo_GameEngine.Contexts.DataModels;
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
        private readonly IDataModelConverter<CharacterDataModel, Character, CharacterCreateRequest> _converter;

        public CharacterLogic(ICharacterRepository repository, IDataModelConverter<CharacterDataModel, Character, CharacterCreateRequest> converter)
        {
            _repository = repository;
            _converter = converter;
        }

        public bool Create(CharacterCreateRequest request)
        {
            CharacterDataModel character = _converter.RequestToDataModel(request);
            
            return _repository.Create(character);
        }

        public List<Character> GetAll()
        {
            List<Character> characters = new List<Character>();
            _repository.GetAll().ForEach(c => characters.Add(_converter.DataModelToModel(c)));
            return characters;
        }

        public List<Character> GetAllByUser(int userId)
        {
            List<Character> characters = new List<Character>();
            _repository.GetAllByUser(userId).ForEach(c => characters.Add(_converter.DataModelToModel(c)));
            return characters;
        }
    }
}
