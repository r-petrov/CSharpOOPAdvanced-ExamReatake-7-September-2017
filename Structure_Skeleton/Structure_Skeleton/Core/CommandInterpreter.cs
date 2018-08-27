using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CommandInterpreter : ICommandInterpreter
{
    public CommandInterpreter(IProviderController providerController, IHarvesterController harvesterController)
    {
        this.ProviderController = providerController;
        this.HarvesterController = harvesterController;
    }

    public IHarvesterController HarvesterController { get; set; }

    public IProviderController ProviderController { get; set; }

    public string ProcessCommand(IList<string> args)
    {
        if (args == null || !args.Any())
        {
            throw new Exception("Command arguments should not be null or empty.");
        }

        var commandName = args[0];
        args.RemoveAt(0);
        var upperCaseCommandName = Methods.SetUpperCase(commandName + Constants.Command);

        Type commandType = Type.GetType(upperCaseCommandName);
        if (commandType == null)
        {
            throw new Exception("Invalid command type passed.");
        }
        
        var command = (ICommand) Activator.CreateInstance(commandType, new object[] {this.HarvesterController, this.ProviderController, args});
        var output = command.Execute();

        return output;
    }
}
