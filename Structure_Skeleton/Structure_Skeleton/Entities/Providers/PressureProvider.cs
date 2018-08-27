using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PressureProvider : Provider
{
    private const double DurabilityLoss = 300;
    private const double DurabilityMultiplier = 2;

    public PressureProvider(int id, double energyOutput) : base(id, energyOutput)
    {
        this.Durability -= DurabilityLoss;
        this.EnergyOutput *= DurabilityMultiplier;
    }
}
