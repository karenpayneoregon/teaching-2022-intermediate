using FluentScheduler;
using Microsoft.Toolkit.Uwp.Notifications;

namespace Notifications.Classes;
internal class ApplicationJobs 
{

    public static void AnnoyingToastNotification()
    {
        new ToastContentBuilder().AddText("Annoying message").Show();

    }
}
