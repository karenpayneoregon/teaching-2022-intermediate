using System;
using System.Linq;
using CreateSocialSecurityNumbers.Classes;

namespace CreateSocialSecurityNumbers;

internal partial class Program
{
    static void Main(string[] args)
    {
        StandardSocialSecurityNumber();
        AnsiConsole.MarkupLine("[yellow]Done[/]");
        Console.ReadLine();
    }
    /// <summary>
    /// Example for using <see cref="Bogus"/> to generate a random SSN, in this case with dashes.
    /// If using this way of generating SSN we need to use string.Replace to get rid of the dashes
    /// </summary>
    /// <remarks>
    /// Bogus does not show doing SSN but Karen Payne examined source to find it.
    /// https://github.com/bchavez/Bogus/blob/master/Source/Bogus/Extensions/UnitedStates/ExtensionsForUnitedStates.cs#L13
    /// Note there are different locales
    /// https://github.com/bchavez/Bogus/tree/master/Source/Bogus/Extensions
    /// </remarks>
public static void StandardSocialSecurityNumber()
{

    var list = Enumerable.Range(1, 12).Select(x => BEU.Ssn(new Bogus.Person()));

    foreach (var ssn in list)
    {
        Console.WriteLine($"{ssn} is valid? {Helpers.IsValidSocialSecurityNumber(ssn).ToYesNo()}");
    }
}
}

