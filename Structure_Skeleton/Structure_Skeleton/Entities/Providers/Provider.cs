using System;

public class Provider : IProvider
{
    private const double InitialDurability = 1000;
    private const double DurabilityLoss = 100;

    public Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = InitialDurability;
    }

    public int ID { get; }

    public double Durability { get; set; }

    public double EnergyOutput { get; set; }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Broke()
    {
        this.Durability -= DurabilityLoss;
        if (this.Durability < 0)
        {
            throw new Exception();
        }
    }

    public void Repair(double value)
    {
        this.Durability += value;
    }
}