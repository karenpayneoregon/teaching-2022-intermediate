using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.Notifications;

namespace Notifications.Classes;


public class ToastOperations
{
    public static Dictionary<string, int> Dictionary { get; } = new()
    {
        { "key1", 100 },
        { "key2", 200 },
        { "key3", 300 },
        { "key4", 400 }
    };

    public static Button ExecuteButton { get; set; } = null!;
    public static string MainKey => "conversationId";

    public static bool ListenerAvailable()
    {
        if (ApiInformation.IsTypePresent("Windows.UI.Notifications.Management.UserNotificationListener"))
        {
            return true;
        }

        else
        {
            return false;
        }
    }
    public static void Clear()
    {
        ToastNotificationManagerCompat.History.Clear();
    }
    public static void Listener()
    {
        ToastNotificationManagerCompat.OnActivated += toastArgs =>
        {
            ToastArguments args = ToastArguments.Parse(toastArgs.Argument);

            if (args.Contains(MainKey))
            {
                if (args[MainKey] == Dictionary["key2"].ToString())
                {
                    Dialogs.Information(ExecuteButton, "Notification triggered", "Woohoo");
                }
                else if (args[MainKey] == Dictionary["key1"].ToString())
                {
                    Process.Start(new ProcessStartInfo(args["url"]) { UseShellExecute = true });

                }
                else if (args[MainKey] == Dictionary["key3"].ToString())
                {
                    if (args.Contains("action"))
                    {
                        if (args["action"] == "snooze")
                        {
                            WorkOperations.Snooze();
                        }
                        else if (args["action"] == "work")
                        {
                            WorkOperations.GotoWork();
                        }
                    }
                }else if (args[MainKey] == Dictionary["key4"].ToString())
                {
                    ValueSet? valueSet = toastArgs.UserInput;
                    
                    if (!valueSet.Keys.Contains("favoriteColor")) return;

                    var favoriteColor = valueSet["favoriteColor"].ToString();
                    if (!string.IsNullOrWhiteSpace(favoriteColor))
                    {
                        Debug.WriteLine($"favorite color: {favoriteColor}");
                    }

                }
            }
            else if (args.Contains("okColor"))
            {
                ValueSet? valueSet = toastArgs.UserInput;
                Debug.WriteLine($"favorite color: {valueSet["colors"]}");
            }
        };
    }

    public static void Hero()
    {
        var heroImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", @"CheckBoxes.png");
        // Requires Microsoft.Toolkit.Uwp.Notifications NuGet package version 7.0 or greater
        new ToastContentBuilder()
            .AddArgument("action", "viewConversation")
            .AddArgument("conversationId", Dictionary["key1"])
            .AddText("Check out")
            .AddText("ASP.NET Core/Razor pages")
            .AddText("Working with Checkboxes")
            .AddInlineImage(new Uri(heroImage))
            .AddButton(new ToastButton()
                .SetContent("Open URL")
                .AddArgument("url", "https://dev.to/karenpayneoregon/aspnet-corerazor-pages-working-with-checkboxes-3ck4"))
            .SetToastScenario(ToastScenario.Default)
            .Show();    
    }
    /// <summary>
    /// Shows notification that download was successful 
    /// </summary>
    public static void HolidaysDownloaded()
    {
        new ToastContentBuilder()
            .AddText("Holidays download")
            .AddButton(new ToastButton().SetContent("OK"))
            .SetToastScenario(ToastScenario.Default)
            .Show();
    }
    /// <summary>
    /// Shows notification that download was not successful 
    /// </summary>
    public static void HolidaysDownloadFailed()
    {
        new ToastContentBuilder()
            .AddText("Holidays not download")
            .AddText("Email sent to developer")
            .AddButton(new ToastButton().SetContent("OK"))
            .SetToastScenario(ToastScenario.Alarm)
            .Show();
    }

    public static void Alarm()
    {
        var alarmPhoto = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", @"alarm.png");
        var checkPhoto = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", @"checkMark.png");

        new ToastContentBuilder()
            .AddArgument("action", "viewConversation")
            .AddArgument("conversationId", Dictionary["key3"])
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

    public static void Schedule(int seconds = 5)
    {
        new ToastContentBuilder()
            .AddArgument("action", "viewItemsDueToday")
            .AddText("You have")
            .AddText("Items due today!")
            .Schedule(DateTime.Now.AddSeconds(seconds), toast =>
            {
                toast.Tag = "18365"; 
                toast.Group = "PersonalAlerts";
            });
    }

    public static void ComboBoxFavoriteColor()
    {
        var choices = new (string comboBoxItemId, string comboBoxItemContent)[]
        {
            ("Blue", "Blue"),
            ("Green", "Green"),
            ("Red", "Red"),
            ("Yellow", "Yellow")
        };


        new ToastContentBuilder()
            .AddText("Question")
            .AddComboBox("colors",
                "What is your favorite color",
                "Green", choices)
            .AddButton(new ToastButton("OK", "okColor"))
            .AddButton(new ToastButton("Cancel", "cancelColor"))
            .Show();
    }

    public static void TextBoxFavoriteColor()
    {
        new ToastContentBuilder()
            .AddArgument("conversationId", Dictionary["key4"])
            .AddText("Question")
            .AddInputTextBox("favoriteColor",
                placeHolderContent: "Type a response",
                title: "What is your favorite color")
            .AddButton(new ToastButton()
                .SetContent("Give it to me"))
            .Show();
    }
}
