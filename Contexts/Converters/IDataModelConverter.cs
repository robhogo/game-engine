using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoBHo_GameEngine.Contexts.Converters
{
    public interface IDataModelConverter<DataModel, Model, Request>
    {
        Model DataModelToModel(DataModel dataModel);
        DataModel ModelToDataModel(Model model);
        DataModel RequestToDataModel(Request request);

    }
}
