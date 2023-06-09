using System.Diagnostics;
using System.Security.Policy;
using Microsoft.Toolkit.Uwp.Notifications;

namespace Notifications;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        Shown += OnShown!;
        Closing += OnClosing;
    }

    private void OnClosing(object? sender, CancelEventArgs e)
    {
        ToastNotificationManagerCompat.History.Clear();
    }

    private void OnShown(object sender, EventArgs e)
    {
        ToastOperations.Listener();
    }

    private void ToastListener()
    {
        ToastNotificationManagerCompat.OnActivated += toastArgs =>
        {
            ToastArguments args = ToastArguments.Parse(toastArgs.Argument);

            foreach (var argument in args)
            {
                Debug.WriteLine($"{argument.Key}");
            }

            if (args.Contains("conversationId"))
            {
                if (args["conversationId"] == "9814")
                {
                    //Invoke(delegate { Dialogs.Information(ExecuteButton, "Notification triggered", "Woohoo"); });
                }
                else if (args["conversationId"] == "9813")
                {
                    Process.Start(new ProcessStartInfo(args["url"]) { UseShellExecute = true });
                }
            }
        };
    }

    private async void ExecuteButton_Click(object sender, EventArgs e)
    {
        ExecuteButton.Enabled = false;
        await Helpers.SimulateWorkAsync();
        ExecuteButton.Enabled = true;

       ToastOperations.ExecuteButton = ExecuteButton;

        var karenPhoto = Path.GetFullPath(@"Karen.png");
        var autoIncrementImage = Path.GetFullPath(@"auto1.png");
        var visualStudioTips1 = Path.GetFullPath(@"VisualStudioTips_1.png");
        new ToastContentBuilder()
            .AddArgument("action", "viewConversation")
            .AddArgument("conversationId", ToastOperations.Dictionary["key2"])
            .AddText("Hey")
            //.AddAppLogoOverride(new Uri(karenPhoto)).SetToastDuration(ToastDuration.Long)
            //.AddInlineImage(new Uri(visualStudioTips1)) //.SetToastDuration(ToastDuration.Long)
            .AddAppLogoOverride(new Uri(karenPhoto), ToastGenericAppLogoCrop.Circle)
            .AddButton(new ToastButton()
                .SetContent("Get the facts from her")
                .AddArgument("action", "viewReport")
                .AddArgument("webSite", "https://github.com/karenpayneoregon?tab=repositories"))
            .Show(toast =>
            {
                toast.ExpirationTime = DateTime.Now.AddMinutes(2);
            });
    }

    private void button1_Click(object sender, EventArgs e)
    {
        
        // Requires Microsoft.Toolkit.Uwp.Notifications NuGet package version 7.0 or greater
        new ToastContentBuilder()
            //.AddHeader("6289", "Camping!!", "action=openConversation&id=6289")
            .AddArgument("action", "viewConversation")
            .AddArgument("conversationId", ToastOperations.Dictionary["key1"])
            .AddText("Karen sent you a picture")
            .AddText("Check this out, The Enchantments in Oregon!")
            .AddButton(new ToastButton()
                .SetContent("Open URL")
                .AddArgument("url", "https://github.com/karenpayneoregon?tab=repositories"))
            .SetToastScenario(ToastScenario.Default)
            .Show();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        new ToastContentBuilder()
            .AddArgument("action", "viewItemsDueToday")
            .AddText("Whatever")
            .AddText("You have 3 items due today!")
            .Schedule(DateTime.Now.AddSeconds(5), toast =>
        {
            toast.Tag = "18365";
            toast.Group = "PersonalAlerts";
        });
    }

    private void button3_Click(object sender, EventArgs e)
    {
        var alarmPhoto = Path.GetFullPath(@"alarm.png");
        var checkPhoto = Path.GetFullPath(@"checkMark.png");
        new ToastContentBuilder()
            .AddArgument("action", "viewConversation")
            .AddArgument("conversationId", ToastOperations.Dictionary["key3"])
            .AddText("Time for work")
            .AddButton(new ToastButton()
                .SetContent("OK")
                .AddArgument("action", "work")
                .SetImageUri(new Uri(checkPhoto)))
            .AddButton(new ToastButton()
                .SetContent("Snooze")
                .AddArgument("action", "snooze")
                .SetImageUri(new Uri(alarmPhoto)))
            .SetToastScenario(ToastScenario.Alarm)
            .Show();
    }
}