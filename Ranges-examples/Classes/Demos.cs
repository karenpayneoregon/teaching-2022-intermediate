using LanguageExtensions;
using Ranges_examples.Classes;
using System.Diagnostics;
using System.Globalization;
using Models;

namespace Classes
{
    class Demos
    {
        /// <summary>
        /// Get work days via a range using indices
        /// </summary>
        public static void DayNamesIndexing()
        {
            var days = DateTimeFormatInfo.CurrentInfo?.DayNames;

            var workDays = days?[1..6];

            // Monday through Friday show day names
            foreach (var day in workDays)
            {
                Console.WriteLine(day);
            }

            Console.WriteLine("");

            // to visualize indices done above e.g. 0 is Sunday
            var indexed = days!
                .Select((name, index) => new
                {
                    Name = name,
                    Index = index
                });

            foreach (var dayItem in indexed)
            {
                Console.WriteLine($"{dayItem.Index,-3}{dayItem.Name}");
            }
        }

        public static void WithString()
        {
            var someText = "ABCDEFG";

            var substring = someText.SubstringByIndexes(1, 3);
            Console.WriteLine(substring);

            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };


            var startIndex = list.Find(x => x == 2);
            var endIndex = startIndex + 3;
            //var range = (new Index(find),new Index(2 - find,true));


            if (endIndex <= list.Count)
            {
                var array1 = list.ToArray()[startIndex..endIndex];
                Console.WriteLine(string.Join(",", array1));
            }
            else
            {
                Console.WriteLine("out of range");
            }

        }

        public static void CreatingContacts1()
        {
            /*
             * First contact for between
             */
            var firstContact = new ContactName() { FirstName = "Frédérique", LastName = "Citeaux" };

            /*
             * Last contact for between
             */
            var lastContact = new ContactName() { FirstName = "Elizabeth", LastName = "Brown" };

            var contactsArray = MockedData.ReadContacts().ToArray();
            var contacts = contactsArray.ContactsListIndices();

            var (startIndex, endIndex) = contacts.BetweenContacts(firstContact, lastContact);

            var citiesBetweenTwoCities = contactsArray[startIndex..endIndex];

            foreach (var item in citiesBetweenTwoCities)
            {
                Console.WriteLine(item);
            }

        }
        public static void CreatingContacts2()
        {
            /*
             * First contact for between
             */
            var firstContact = new ContactName() { FirstName = "Frédérique", LastName = "Citeaux" };

            /*
             * Last contact for between
             */
            var lastContact = new ContactName() { FirstName = "Elizabeth", LastName = "Brown" };

            var contactsArray = MockedData.ReadContacts().ToArray();
            var contacts = contactsArray.ContactsListIndices();

            var range = contacts.BetweenContacts(firstContact, lastContact);

            var citiesBetweenTwoCities = contactsArray[range.startIndex..range.endIndex];

            foreach (var item in citiesBetweenTwoCities)
            {
                Console.WriteLine(item);
            }

        }

        /// <summary>
        /// public static int GetCityIndex(string cityName) => SomeOregonCities.ToList().IndexOf(cityName);
        /// </summary>
        public static void CreatingCities()
        {
            string startCity = "Aloha";
            string endCity = "Ashland";

            string[] oregonCities = FileOperations.OregonCities();

            var cities = oregonCities.CityListIndices();
            var (startIndex1, endIndex1) = cities.BetweenCities(startCity, endCity);

            var citiesBetweenTwoCities = oregonCities[startIndex1..endIndex1];

            foreach (var item in citiesBetweenTwoCities)
            {
                Debug.WriteLine(item);
            }

            Console.WriteLine();
        }

        public static void Creating1()
        {
            string startCity = "Aloha";
            string endCity = "Ashland";

            var cities = Helpers.GetBetweenInclusive(FileOperations.OregonCities(), startCity, endCity);

            if (cities is not null)
            {
                foreach (var result in cities)
                {
                    Debug.WriteLine(result);
                }
            }
            else
            {
                Debug.WriteLine("Operation failed");
            }


        }
    }
}
