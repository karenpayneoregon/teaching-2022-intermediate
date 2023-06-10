using System.Diagnostics;
using System.Net;
using System.Text.Json;
using Microsoft.Toolkit.Uwp.Notifications;
using Notifications.Models;

namespace Notifications;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        if (!ToastOperations.ListenerAvailable())
        {
            MessageBox.Show(@"OS does not support code in this app");
            Controls.OfType<Button>().ToList().ForEach(button =>
            {
                button.Enabled = false;
            });
        }
        else
        {
            Shown += OnShown!;
            Closing += OnClosing;
        }

    }

    private void OnClosing(object? sender, CancelEventArgs e)
    {
        ToastOperations.Clear();
    }

    private void OnShown(object sender, EventArgs e)
    {
        ToastOperations.Listener();
    }

    /// <summary>
    /// Here we present a notification and when the button is pressed in the notification
    /// show a message dialog (which typically is not done but some might want this. 
    /// </summary>
    private async void ExecuteWithMessageBoxButton_Click(object sender, EventArgs e)
    {
        ExecuteWithMessageBoxButton.Enabled = false;
        await Helpers.SimulateWorkAsync();
        ExecuteWithMessageBoxButton.Enabled = true;

       ToastOperations.ExecuteButton = ExecuteWithMessageBoxButton;

        var karenPhoto = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", @"Karen.png");

        new ToastContentBuilder()
            .AddArgument("action", "viewConversation")
            .AddArgument("conversationId", ToastOperations.Dictionary["key2"])
            .AddText("Hey")
            //.AddAppLogoOverride(new Uri(karenPhoto)).SetToastDuration(ToastDuration.Long)
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

    private void HeroButton_Click(object sender, EventArgs e)
    {
        ToastOperations.Hero();
    }

    private void ScheduleButton_Click(object sender, EventArgs e)
    {
        ToastOperations.Schedule();
    }

    private void AlarmButton_Click(object sender, EventArgs e)
    {
        ToastOperations.Alarm();
    }

    private void TextInputButton_Click(object sender, EventArgs e)
    {
        ToastOperations.TextBoxFavoriteColor();
    }

    private void SelectButton_Click(object sender, EventArgs e)
    {
        ToastOperations.ComboBoxFavoriteColor();
    }

    private async void DownLoadButton_Click(object sender, EventArgs e)
    {
        var usHolidays = await WorkOperations.GetHolidays();
        if (usHolidays.Any())
        {
            ToastOperations.HolidaysDownloaded();
        }
        else
        {
            ToastOperations.HolidaysDownloadFailed();
        }
    }
}