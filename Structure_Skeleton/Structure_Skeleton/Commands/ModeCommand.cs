using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ModeCommand : Command
{
    public ModeCommand(IHarvesterController harversterController, IProviderController providerController, IList<string> arguments) : base(harversterController, providerController, arguments)
    {
    }

    public override string Execute()
    {
        var modeType = this.Arguments[0];
        var output = this.HarvesterController.ChangeMode(modeType);

        return output;
    }
}
