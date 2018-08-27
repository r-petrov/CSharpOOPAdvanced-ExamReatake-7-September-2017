using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minedraft.Entities.Enumerations;

public class HarvesterController : IHarvesterController
{
    private List<IHarvester> harvesters;
    private IHarvesterFactory factory;
    
    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.EnergyRepository = energyRepository;
        this.harvesters = new List<IHarvester>();
        this.factory = new HarvesterFactory();
        this.EnergyRepository.TakeEnergy(this.harvesters.Select(h => h.EnergyRequirement).Sum());
    }

    public IEnergyRepository EnergyRepository { get; set; }

    public double TotalEnergyRequired
    {
        get
        {
            return this.harvesters.Select(h => h.EnergyRequirement).Sum();
        }
    }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();

    public double OreProduced { get; set; }

    public string Register(IList<string> args)
    {
        var harvester = this.factory.GenerateHarvester(args);
        this.harvesters.Add(harvester);
        return string.Format(Constants.SuccessfullRegistration,
            harvester.GetType().Name);
    }

    public string Produce()
    {
        if (this.EnergyRepository.EnergyStored < this.TotalEnergyRequired)
        {
            return null;
        }

        this.EnergyRepository.TakeEnergy(this.TotalEnergyRequired);
        this.OreProduced = this.harvesters.Select(n => n.Produce()).Sum();

        return string.Format(Constants.OreOutputToday, this.OreProduced);
    }

    public string ChangeMode(string mode)
    {
        var modeType = (Mode)Enum.Parse(typeof(Mode), mode);
        var modeValue = (int) modeType;

        List<IHarvester> reminder = new List<IHarvester>();
        foreach (var harvester in this.harvesters)
        {
            harvester.EnergyRequirement = (harvester.EnergyRequirement * modeValue) / 100;
            harvester.OreOutput = (harvester.OreOutput * modeValue) / 100;
            try
            {
                harvester.Broke();
            }
            catch (Exception ex)
            {
                reminder.Add(harvester);
            }
        }

        foreach (var entity in reminder)
        {
            this.harvesters.Remove(entity);
        }

        return string.Format(Constants.ModeChanged, mode);
    }
}
