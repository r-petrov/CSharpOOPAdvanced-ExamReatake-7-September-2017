using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class InspectCommand : Command
{
    public InspectCommand(IHarvesterController harversterController, IProviderController providerController, IList<string> arguments) : base(harversterController, providerController, arguments)
    {
    }

    public override string Execute()
    {
        var providerControllerType = this.ProviderController.GetType();
        var providerControllerEntities = (IReadOnlyCollection<IEntity>)providerControllerType.GetProperty(Constants.Entities).GetValue(providerControllerType);
        var harvesterControllerType = this.ProviderController.GetType();
        var harvesterControllerTypeEntities = (IReadOnlyCollection<IEntity>)providerControllerType.GetProperty(Constants.Entities).GetValue(harvesterControllerType);

        var id = int.Parse(this.Arguments[0]);
        var providerEntityInfo = this.GetEntityInfo(providerControllerEntities, id);
        var harvesterEntityInfo = this.GetEntityInfo(harvesterControllerTypeEntities, id);
        var output = string.Empty;
        if (string.IsNullOrEmpty(providerEntityInfo) && string.IsNullOrEmpty(harvesterEntityInfo))
        {
            output = string.Format(Constants.NoEntityFound, id);
        }
        else
        {
            output = providerEntityInfo ?? harvesterEntityInfo;
        }

        return output;
    }

    private string GetEntityInfo(IReadOnlyCollection<IEntity> entities, int id)
    {
        if (entities != null && entities.Any(e => e.ID == id))
        {
            return null;
        }

        var entity = entities.FirstOrDefault(e => e.ID == id);
        var entityType = entity.GetType().FullName;
        var output = $"{entityType}{Environment.NewLine}Durability: {entity.Durability}";

        return output;
    }
}
