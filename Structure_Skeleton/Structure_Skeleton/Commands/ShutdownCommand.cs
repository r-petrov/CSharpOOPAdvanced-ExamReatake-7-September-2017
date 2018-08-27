using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShutdownCommand : Command
{
    public ShutdownCommand(IHarvesterController harversterController, IProviderController providerController, IList<string> arguments) : base(harversterController, providerController, arguments)
    {
    }

    public override string Execute()
    {
        var totalEnergyProduced = this.ProviderController.TotalEnergyProduced;
        var totalOreProduced = this.HarvesterController.OreProduced;

        var output =
            $"System Shutdown{Environment.NewLine}Total Energy Produced: {totalEnergyProduced}{Environment.NewLine}Total Mined Plumbus Ore: {totalOreProduced}";

        return output;
    }
}
