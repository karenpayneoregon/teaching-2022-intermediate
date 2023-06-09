namespace Notifications.Classes;
internal class Helpers
{
    public static async Task SimulateWorkAsync(int times = 2, int delay = 500)
    {
        for (int index = 1; index <= times; index++)
        {
            await Task.Delay(delay);
        }
    }
}
