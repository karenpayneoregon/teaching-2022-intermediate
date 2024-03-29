﻿
using Models;

namespace LanguageExtensions
{
    public static class Extensions
    {
        /// <summary>
        /// Get Indices for between two city names. Since city names are static there is no assertion on if a city exists.
        /// </summary>
        /// <param name="sender">List of <seealso cref="City"/></param>
        /// <param name="firstCity">First city name</param>
        /// <param name="lastCity">Last city name</param>
        /// <returns>Start city index, last city index with ^ (hat)</returns>
        /// <remarks>
        /// To keep code short null checks are excluded
        /// </remarks>
        public static (Index startIndex, Index endIndex) BetweenCities(this List<City> sender, string firstCity, string lastCity)
        {
            return
                (
                    sender.FirstOrDefault(name => name.Name == firstCity)!.StartIndex,
                    sender.FirstOrDefault(x => x.Name == lastCity)!.EndIndex
                );
        }
        /// <summary>
        /// Get Indices for between two contacts.
        /// </summary>
        /// <param name="sender">List of <seealso cref="Contacts"/></param>
        /// <param name="firstContact"><seealso cref="ContactName"/></param>
        /// <param name="lastContact"><seealso cref="ContactName"/></param>
        /// <returns>Start contact index, last contact index with ^ (hat)</returns>
        public static (Index startIndex, Index endIndex) BetweenContacts(this List<Contacts> sender, ContactName firstContact, ContactName lastContact)
        {
            return
            (
                sender.FirstOrDefault(contact => contact.FirstName ==
                    firstContact.FirstName && contact.LastName == firstContact.LastName)!.StartIndex,

                sender.FirstOrDefault(contact => contact.FirstName ==
                    lastContact.FirstName && contact.LastName == lastContact.LastName)!.EndIndex

            );
        }
        public static Range BetweenContacts1(this List<Contacts> sender, ContactName firstContact, ContactName lastContact)
        {
            var startIndex = sender.FirstOrDefault(contact => contact.FirstName == firstContact.FirstName && contact.LastName == firstContact.LastName)!.StartIndex;
            var endIndex = sender.FirstOrDefault(contact => contact.FirstName == lastContact.FirstName && contact.LastName == lastContact.LastName)!.EndIndex;
            return startIndex..endIndex;

        }
        /// <summary>
        /// Set indices for each contact
        /// </summary>
        /// <param name="contactsArray"><see cref="Contacts"/> array</param>
        /// <returns>start and end indices set for entire array</returns>
        public static List<Contacts> ContactsListIndices(this Contacts[] contactsArray)
        {
            //List<int> rangeReverse = Enumerable.Range(0, contactsArray.Length).Reverse().ToList();

            List<Contacts> contacts = contactsArray.Select(
                (contact, index) => new Contacts()
                {
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    StartIndex = new Index(index),
                    EndIndex =  new Index(contactsArray.Length - index -1, true)// new Index(rangeReverse[index], true)
                }).ToList();

            return contacts;

        }
        public static List<City> CityListIndices(this string[] citiesArray)
        {
            List<int> rangeReverse = Enumerable.Range(0, citiesArray.Length).Reverse().ToList();

            List<City> cities = citiesArray.Select(
                (cityName, index) => new City()
                {
                    Name = cityName,
                    StartIndex = new Index(index),
                    EndIndex = new Index(rangeReverse[index], true)
                }).ToList();
            return cities;
        }
        public static string SubstringByIndexes(this string value, int startIndex, int endIndex) => value[startIndex..(endIndex + 1)];


        /// <summary>
        /// Produces an array where the first element is startValue, last element is endValue with all values between both case insensitive.
        /// </summary>
        /// <param name="sender">List of <see cref="string"/></param>
        /// <param name="startValue">first element to start the range</param>
        /// <param name="endValue">last element to end the range</param>
        /// <returns>range between startValue and endValue or null if neither start or end values do not exist in sender array</returns>
        public static List<string> BetweenElements(this List<string> sender, string startValue, string endValue)
        {

            var startIndex = sender.FindIndex(element =>
                element.Equals(
                    startValue,
                    StringComparison.OrdinalIgnoreCase));

            var endIndex = sender.FindIndex(element =>
                element.Equals(
                    endValue,
                    StringComparison.OrdinalIgnoreCase)) - startIndex + 1;

            return startIndex == -1 || endIndex == -1 ? null : sender.GetRange(startIndex, endIndex);

        }
        /// <summary>
        /// Produces an array where the first element is startValue, last element is endValue with all values between both.
        /// </summary>
        /// <param name="sender">List of <see cref="int"/></param>
        /// <param name="startValue">first element to start the range</param>
        /// <param name="endValue">last element to end the range</param>
        /// <returns>range between startValue and endValue or null if neither start or end values do not exist in sender array</returns>
        public static List<int> BetweenElements(this List<int> sender, int startValue, int endValue)
        {

            var startIndex = sender.FindIndex(element =>
                element.Equals(startValue));

            var endIndex = sender.FindIndex(element =>
                element.Equals(endValue)) - startIndex + 1;

            return startIndex == -1 || endIndex == -1 ?
                null :
                sender.GetRange(startIndex, endIndex);
        }

        public static List<DateTime> BetweenDates(this List<DateTime> sender, DateTime startValue, DateTime endValue)
        {

            var startIndex = sender.FindIndex(element =>
                element.Date.Equals(startValue.Date));

            var endIndex = sender.FindIndex(element =>
                element.Date.Equals(endValue.Date)) - startIndex + 1;

            return startIndex == -1 || endIndex == -1 ?
                null :
                sender.GetRange(startIndex, endIndex);
        }
    }
}
