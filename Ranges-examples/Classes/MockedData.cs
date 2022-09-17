using Models;

namespace Ranges_examples.Classes;

public class MockedData
{
    public static string ContactFileName => "contacts.json";

    public static List<Contacts> ReadContacts()
    {
        try
        {
            return JSonHelper.ConvertJSonToObject<List<Contacts>>(File.ReadAllText(ContactFileName));
        }
        catch (Exception)
        {
            return null;
        }

    }
}