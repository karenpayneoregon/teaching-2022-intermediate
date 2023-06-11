using FluentScheduler;
using Microsoft.Toolkit.Uwp.Notifications;
using System.Threading.Tasks;

namespace Notifications.Classes;
internal class ApplicationJobs 
{

    public static void AnnoyingToastNotification()
    {
        new ToastContentBuilder().AddText("Annoying message").Show();
    }

    public static void OnceToastNotification()
    {
        new ToastContentBuilder()
            .AddText("Shown only once")
            .AddButton(new ToastButton().SetContent("Bye"))
            .Show(toast =>{
                toast.ExpirationTime = DateTime.Now.AddSeconds(2);
        });
    }
}
