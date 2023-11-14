using Newtonsoft.Json;
using TaxpayerLibraryEntityVersion.Classes;
using TaxpayerLibraryEntityVersion.Models;
using TaxpayerMocking.Classes;

namespace TaxpayerMocking
{
    internal partial class Program
    {
        static async Task Main(string[] args)
        {
            //var test = SqlStatements.LongestColumnLength("", "");
            var statement = SqlStatements.MinMaxForColumn("Taxpayer","LastName");
            List<ColumnResult> columnResults = await DapperOperations.GetColumnLengths(statement);

            foreach (var col in columnResults)
            {
                Console.WriteLine($"{col.Value,-20}{col.Length}");
            }

  

            SetupDatabase.Initialize(25);
            List<Taxpayer> taxpayerList = SetupDatabase.GetTaxpayers();

            var result = taxpayerList.RangeDetails();

            foreach (var container in result)
            {
                Console.WriteLine($"{container.Value.Id, -5:D4}{container.Value.FullName, -30} {container.StartIndex}' {container.EndIndex}");
            }

            Console.WriteLine();


            //JsonExample(taxpayerList);

            //var table = CreateTable();

            //AnsiConsole.Clear();

            //foreach (var taxpayer in taxpayerList)
            //{
            //    if (taxpayer.StartDate.HasValue)
            //    {
            //        table.AddRow(taxpayer.Id.ToString(),
            //            taxpayer.FullName,
            //            taxpayer.SocialSecurityNumber,
            //            taxpayer.Pin,
            //            taxpayer.StartDate.Value.ToString("MM/dd/yyyy"),
            //            taxpayer.Category.Description);
            //    }
            //}

            //AnsiConsole.Write(table);
            Console.ReadLine();
        }

        /// <summary>
        /// How to serialize a self-referencing model
        /// </summary>
        private static void JsonExample(List<Taxpayer> taxpayerList)
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects, 
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(taxpayerList, jsonSerializerSettings);
            File.WriteAllText("Taxpayers.json", json);
            List<Taxpayer> taxpayers = JsonConvert.DeserializeObject<List<Taxpayer>>(json);

            // put breakpoint here to examine the list
        }
    }
}