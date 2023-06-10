using Notifications.Models;
using System.Text.Json;

namespace Notifications.Classes;
public class WorkOperations
{
    public static void Snooze()
    {
        // TODO
    }

    public static void GotoWork()
    {
        // TODO
    }

    public static async Task<List<PublicHoliday>> GetHolidays(string countryCode = "US")
    {
    
        var jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        using var httpClient = new HttpClient();

        var response = await httpClient.GetAsync($"https://date.nager.at/api/v3/publicholidays/{DateTime.Now.Year}/{countryCode}");

        if (response.IsSuccessStatusCode)
        {
            await using var jsonStream = await response.Content.ReadAsStreamAsync();

            // Distinct is used as there were duplicate entries
            return JsonSerializer.Deserialize<PublicHoliday[]>(jsonStream, jsonSerializerOptions)
                    !.Distinct(PublicHoliday.DateComparer).ToList();
        }
        else
        {
            return Enumerable.Empty<PublicHoliday>().ToList();
        }
    }
}
