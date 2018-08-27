using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class RegisterCommand : Command
{
    public RegisterCommand(IHarvesterController harversterController, IProviderController providerController, IList<string> arguments) : base(harversterController, providerController, arguments)
    {
    }

    public override string Execute()
    {
        var entityName = this.Arguments[0];
        var upperCaseControllerName = Methods.SetUpperCase($"{entityName}{Constants.Controller}");
        this.Arguments.RemoveAt(0);

        //Get the property information from the type using reflection.
        var controllerProperty = this.GetType().GetProperty(upperCaseControllerName, BindingFlags.Instance | BindingFlags.NonPublic);
        if (controllerProperty == null)
        {
            throw new Exception($"There is no such controller as {upperCaseControllerName}.");
        }

        // Get the value of the property by combining the property info with the main instance.
        var controllerPropertyObject = controllerProperty.GetValue(this);
        var controllerPropertyType = controllerPropertyObject.GetType();
        var controllerPropertyRegisterMethodName = Methods.RemoveFromStringEnd(this.GetType().Name, Constants.Command);
        var controllerPropertyRegisterMethod = controllerPropertyType.GetMethod(controllerPropertyRegisterMethodName, new Type[] {typeof(IList<string>)});
        if (controllerPropertyRegisterMethod == null)
        {
            throw new Exception($"There is no method with name {controllerPropertyRegisterMethodName} in {upperCaseControllerName}.");
        }

        var output = controllerPropertyRegisterMethod.Invoke(controllerPropertyObject, new object[] {this.Arguments}).ToString();

        return output;
    }
}
