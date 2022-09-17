using System.Runtime.CompilerServices;
using Spectre.Console;
using ConsoleHelperLibrary.Classes;

// ReSharper disable once CheckNamespace
namespace IndexMonths
{
    internal partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            AnsiConsole.MarkupLine("");
            Console.Title = "Code sample:";
            WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
        }
    }
}
