using FluentScheduler;

namespace Notifications.Classes;

public class JobsRegistry : Registry
{
    public JobsRegistry()
    {
        // Toast notification
        //Action annoyingToastNotification = ApplicationJobs.AnnoyingToastNotification;

        // run once every minute while app is running
        Schedule(ApplicationJobs.AnnoyingToastNotification)
            .WithName("Annoying")
            .ToRunEvery(1).Minutes();
    }
}