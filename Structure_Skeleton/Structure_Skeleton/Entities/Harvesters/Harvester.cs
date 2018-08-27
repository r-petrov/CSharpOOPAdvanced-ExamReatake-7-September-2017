using System;

public abstract class Harvester : IHarvester
{
    private const int InitialDurability = 1000;
    private const int DurabilityLoss = 100;

    protected Harvester(int id, double oreOutput, double energyRequirement)
    {
        this.ID = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
        this.Durability = InitialDurability;
    }

    public int ID { get; }

    public double OreOutput { get; set; }

    public double EnergyRequirement { get; set; }

    public virtual double Durability { get; set; }

    public double Produce()
    {
        return this.OreOutput;
    }

    public void Broke()
    {
        this.Durability -= DurabilityLoss;
        if (this.Durability < 0)
        {
            throw new Exception();
        }
    }

    //public void ChangeEnergyRequirement(int value)
    //{
    //    this.EnergyRequirement = (this.EnergyRequirement*value)/100;
    //}

    //public void ChangeOreOutput(int value)
    //{
    //    this.OreOutput = (this.OreOutput * value) / 100;
    //}
}