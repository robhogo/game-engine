using RoBHo_GameEngine.Contexts.DataModels;
using RoBHo_GameEngine.Models;
using System;


namespace RoBHo_GameEngine.Contexts.Converters
{
    public class CharacterLvlConverter : IDataModelConverter<CharacterLvlDataModel, CharacterLvl, LvlType>
    {
        public CharacterLvl DataModelToModel(CharacterLvlDataModel dataModel)
        {
            return new CharacterLvl
            {
                Id = dataModel.Id,
                Lvl = dataModel.Lvl,
                LvlType = dataModel.LvlType,
                CurrentXp = dataModel.CurrentXp
            };
        }

        public CharacterLvlDataModel ModelToDataModel(CharacterLvl model)
        {
            throw new NotImplementedException();
        }

        public CharacterLvlDataModel RequestToDataModel(LvlType request)
        {
            return new CharacterLvlDataModel
            {
                Lvl = 1,
                CurrentXp = 0,
                LvlType = request,
            };
        }
    }
}
