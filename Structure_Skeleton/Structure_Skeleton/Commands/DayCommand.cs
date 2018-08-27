using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DayCommand : Command
{
    public DayCommand(IHarvesterController harversterController, IProviderController providerController, IList<string> arguments) : base(harversterController, providerController, arguments)
    {
    }

    public override string Execute()
    {
        var energyProducedOutputMessage = this.ProviderController.Produce();
        var oreProducedOutputMessage = this.HarvesterController.Produce();
        var output = $"{energyProducedOutputMessage}{Environment.NewLine}{oreProducedOutputMessage}";

        return output;
    }
}
