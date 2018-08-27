using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Command : ICommand
{
    protected Command(IHarvesterController harversterController, IProviderController providerController, IList<string> arguments)
    {
        this.HarvesterController = harversterController;
        this.ProviderController = providerController;
        this.Arguments = arguments;
    }

    protected Command(IController controller, IList<string> arguments)
    {
        this.Controller = controller;
        this.Arguments = arguments;
    }

    protected IHarvesterController HarvesterController { get; }

    protected IProviderController ProviderController { get; }

    protected IController Controller { get; }

    public IList<string> Arguments { get; }

    public abstract string Execute();
}
