using System;
using System.Collections.Generic;
using System.Linq;
using Minedraft.IO;

public class Engine
{
    private ICommandInterpreter commandInterpreter;

    private IReader reader;

    private IWriter writer;

    public Engine(IReader reader, IWriter writer, IProviderController providerController, IHarvesterController harvesterController)
    {
        this.reader = reader;
        this.writer = writer;
        this.commandInterpreter = new CommandInterpreter(providerController, harvesterController);
    }

    public void Run()
    {
        var input = this.reader.ReadLine();
        var commandArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        var commandName = commandArgs[0];
        while (!commandName.Equals("Shutdown", StringComparison.OrdinalIgnoreCase))
        {
            try
            {
                var output = this.InterpretCommand(commandArgs);
                this.writer.WriteLine(output);

                input = this.reader.ReadLine();
            }
            catch (Exception ex)
            {
                Methods.LogError(this.writer, ex);
            }
        }
    }

    private string InterpretCommand(IList<string> args)
    {
        var output = this.commandInterpreter.ProcessCommand(args);

        return output;
    }
}
