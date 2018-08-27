using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture]
public class ProviderControllerTests
{
    private List<IProvider> providers;
    private ProviderController controller;
    private IEnergyRepository energyRepository;

    [SetUp]
    public void InitializeProviders()
    {
        this.energyRepository = new EnergyRepository();
        this.providers = new List<IProvider>();
        this.controller = new ProviderController(this.energyRepository);
    }

    [Test]
    public void RegisterShouldAddNewProviderToProvidersList()
    {
        //Arrange
        IList<string> arguments = new List<string>() { "Pressure", "1", "120" };

        //Act
        this.controller.Register(arguments);

        //Assert
        Assert.AreEqual(1, this.controller.Entities.Count);
    }

    [Test]
    public void RepairShouldAddValueToProvidersDurability()
    {
        //Arrange
        var value = 120d;
        IList<string> arguments = new List<string>() { "Hammer", "1", "120" };
        this.controller.Register(arguments);
        var startDurability = this.controller.Entities.First().Durability;

        //Act
        this.controller.Repair(value);

        //Assert
        Assert.AreEqual(startDurability + value, this.controller.Entities.First().Durability);
    }
}
