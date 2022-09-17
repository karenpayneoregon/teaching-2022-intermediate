namespace Ranges_examples.Classes;

public class FileOperations
{
    public static string[] OregonCities() => File.ReadAllLines("OregonCityNames.txt");

}