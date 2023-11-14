namespace GetCnd;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        await WebHelpers.DownloadJson();
        AnsiConsole.MarkupLine("[yellow]Done[/]");
        Console.ReadLine();
    }

}

internal static class WebHelpers
{

    public static async Task DownloadFileAsync(this HttpClient client, Uri uri, string fileName)
    {
        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }

        await Task.Delay(500);

        await using var stream = await client.GetStreamAsync(uri);
        await using var fs = new FileStream(fileName!, FileMode.CreateNew);
        await stream.CopyToAsync(fs);
    }

    public static async Task DownloadJson()
    {
        using var client = new HttpClient();
        var fileName = @"test.json";
        /*
         * https://api.cdnjs.com/libraries?search=bootstrap&fields=filename,description,version
         *
         * bootstrap-icons
         * https://api.cdnjs.com/libraries?search=bootstrap-icons&fields=filename,description,version,github
         */
        var uri = new Uri("https://api.cdnjs.com/libraries?search=bootstrap-icons&fields=filename,description,version");

        await client.DownloadFileAsync(uri, fileName);
    }
}



