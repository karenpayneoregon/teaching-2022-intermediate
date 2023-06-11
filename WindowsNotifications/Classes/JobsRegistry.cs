using FluentScheduler;

namespace Notifications.Classes;

public class JobsRegistry : Registry
{
    public JobsRegistry()
    {
        // Toast notification

        // run once every minute while app is running
        Schedule(ApplicationJobs.AnnoyingToastNotification)
            .WithName("Annoying")
            .ToRunEvery(1).Minutes();

        // run once three minutes after app starts
        DateTime dateTime = DateTime.Now.AddMinutes(3);
        Schedule(ApplicationJobs.OnceToastNotification)
            .WithName("Annoying").ToRunOnceAt(dateTime);
    }
}