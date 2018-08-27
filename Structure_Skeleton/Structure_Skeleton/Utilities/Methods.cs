using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Methods
{
    public static string SetUpperCase(string str)
    {
        var upperCaseString = str.First().ToString().ToUpper() + str.Substring(1);

        return upperCaseString;
    }

    public static void LogError(IWriter writer, Exception ex)
    {
        writer.WriteLine(ex.InnerException?.Message ?? ex.Message);
        writer.WriteLine(ex.StackTrace);
    }

    public static string RemoveFromStringEnd(this string str, string suffix)
    {
        return str.EndsWith(suffix) ? str.Substring(0, str.Length - suffix.Length) : str;
    }
}
