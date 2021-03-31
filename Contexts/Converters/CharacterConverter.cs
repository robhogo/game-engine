using RoBHo_GameEngine.Contexts.DataModels;
using RoBHo_GameEngine.Models;
using RoBHo_GameEngine.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoBHo_GameEngine.Contexts.Converters
{
    public class CharacterConverter : IDataModelConverter<CharacterDataModel, Character, CharacterCreateRequest>
    {
        private readonly IDataModelConverter<CharacterLvlDataModel, CharacterLvl, LvlType> _lvlConverter;

        public CharacterConverter(IDataModelConverter<CharacterLvlDataModel, CharacterLvl, LvlType> lvlConverter)
        {
            _lvlConverter = lvlConverter;
        }

        public Character DataModelToModel(CharacterDataModel dataModel)
        {
            Character character = new Character
            {
                Id = dataModel.Id,
                Name = dataModel.Name,
                CharacterClass = new CharacterClass { Id = dataModel.CharacterClass, Name = dataModel.CharacterClass.ToString() },
                Money = dataModel.Money,
                UserId = dataModel.UserId,
                ImgUrl = dataModel.ImgUrl,
                CombatLvl = _lvlConverter.DataModelToModel(dataModel.CharacterLvls.FirstOrDefault(c => c.LvlType == LvlType.combat)),
                CraftingLvl = _lvlConverter.DataModelToModel(dataModel.CharacterLvls.FirstOrDefault(c => c.LvlType == LvlType.crafting)),
                GatheringLvl = _lvlConverter.DataModelToModel(dataModel.CharacterLvls.FirstOrDefault(c => c.LvlType == LvlType.gathering)),
            };
            return character;
        }

        public CharacterDataModel ModelToDataModel(Character model)
        {
            throw new NotImplementedException();
        }

        public CharacterDataModel RequestToDataModel(CharacterCreateRequest request)
        {
            List<CharacterLvlDataModel> characterLvls = new List<CharacterLvlDataModel>
            {
                _lvlConverter.RequestToDataModel(LvlType.combat),
                _lvlConverter.RequestToDataModel(LvlType.crafting),
                _lvlConverter.RequestToDataModel(LvlType.gathering)
            };

            CharacterDataModel character = new CharacterDataModel()
            {
                Name = request.Name,
                ImgUrl = request.imageUrl,
                CharacterClass = (CharacterClassType)request.CharacterClass,
                Money = 0,
                UserId = request.UserId,
                CharacterLvls = characterLvls
            };

            return character;
        }
    }
}
