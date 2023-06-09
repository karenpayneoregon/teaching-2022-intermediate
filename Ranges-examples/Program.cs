using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Classes;
using Ranges_examples.Classes;
using Ranges_examples.LanguageExtensions;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Ranges_examples
{
    class Program
    {
        private static string _text;
        private static string _title;

        /// <summary>
        /// Index Operator ^
        /// Range Operator ..
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Demos.Creating1();
            Console.ReadLine();
        }









        /// <summary>
        /// Indexer to get sub string from end of string
        /// </summary>
        private static void Basic2()
        {
            var fileName = "myTestFileName.txt123";
            var index = (fileName.LastIndexOf(".", StringComparison.Ordinal) - fileName.Length);

            if (index.IsNegative())
            {
                index = index.Invert();
            }

            var indexFromEnd = new Index(index, true);
            var extension = fileName[indexFromEnd..^0];
            Console.WriteLine(extension);

            /*
             * Of course
             */
            Console.WriteLine(Path.GetExtension(fileName));
        }


        #region screen formatting

        private static void HorizontalRule(string title)
        {
            AnsiConsole.WriteLine();
            AnsiConsole.Render(new Rule($"[white bold]{title}[/]").RuleStyle("grey").LeftAligned());
            AnsiConsole.WriteLine();
        }
        private static void PanelBorders()
        {
            static IRenderable CreatePanel(string name, BoxBorder border)
            {
                return new Panel(_text)
                    .Header($" [yellow]{name}[/] ", Justify.Center)
                    .Border(border)
                    .BorderStyle(Style.Parse("grey"));
            }

            var items = new[]
            {
                CreatePanel(_title, BoxBorder.Square)

            };

            AnsiConsole.Render(
                new Padder(
                    new Columns(items).PadRight(2),
                    new Padding(2, 0, 0, 0)));
        }

        #endregion
    }
}
