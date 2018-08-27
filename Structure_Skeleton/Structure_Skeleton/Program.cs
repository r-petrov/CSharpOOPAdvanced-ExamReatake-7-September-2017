using Minedraft.IO;

public class Program
{
    public static void Main(string[] args)
    {
        IEnergyRepository energyRepository = new EnergyRepository();
        IProviderController providerController = new ProviderController(energyRepository);
        IHarvesterController harvesterController = new HarvesterController(energyRepository);
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        Engine engine = new Engine(reader, writer, providerController, harvesterController);
        engine.Run();
    }
}