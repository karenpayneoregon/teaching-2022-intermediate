using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Classes;


public class ToastOperations
{
    public static Dictionary<string, int> Dictionary { get; } = new()
    {
        { "key1", 100 },
        { "key2", 200 },
        { "key3", 300}
    };

    public static Button ExecuteButton { get; set; } = null!;

    public static void Listener()
    {
        ToastNotificationManagerCompat.OnActivated += toastArgs =>
        {
            ToastArguments args = ToastArguments.Parse(toastArgs.Argument);

            if (args.Contains("conversationId"))
            {
                if (args["conversationId"] == Dictionary["key2"].ToString())
                {

                    Dialogs.Information(ExecuteButton, "Notification triggered", "Woohoo");
                }
                else if (args["conversationId"] == Dictionary["key1"].ToString())
                {
                    Process.Start(new ProcessStartInfo(args["url"]) { UseShellExecute = true });

                }
                else if (args["conversationId"] == Dictionary["key3"].ToString())
                {
                    if (args.Contains("action"))
                    {
                        if (args["action"] == "snooze")
                        {
                            WorkOperations.Snooze();
                        }
                        else if (args["action"] == "work")
                        {
                            WorkOperations.WakeUp();
                        }
                    }
                }
            }
        };
    }
}
