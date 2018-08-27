using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RepairCommand : Command
{
    public RepairCommand(IHarvesterController harversterController, IProviderController providerController, IList<string> arguments) : base(harversterController, providerController, arguments)
    {
    }

    public override string Execute()
    {
        var repairValue = double.Parse(this.Arguments[0]);
        var output = this.ProviderController.Repair(repairValue);

        return output;
    }
}
