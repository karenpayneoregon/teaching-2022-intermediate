using FluentScheduler;
using Microsoft.Toolkit.Uwp.Notifications;

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

    }

    /// <summary>
    /// Here we present a notification and when the button is pressed in the notification
    /// show a message dialog (which typically is not done but some might want this. 
    /// </summary>
    private async void ExecuteAboutArticleButton_Click(object sender, EventArgs e)
    {
        ArticleButton.Enabled = false;
        await Helpers.SimulateWorkAsync();
        ArticleButton.Enabled = true;

        var karenPhoto = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", @"Karen.png");

        new ToastContentBuilder()
            .AddArgument("action", "viewConversation")
            .AddArgument("conversationId", ToastOperations.Dictionary["key2"])
            .AddText("Hey")
            .SetToastDuration(ToastDuration.Short)
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

    /// <summary>
    /// Prompt user for a favorite color via a text input
    /// </summary>
    private void TextInputButton_Click(object sender, EventArgs e)
    {
        ToastOperations.TextBoxFavoriteColor();
    }

    /// <summary>
    /// Prompt user for a favorite color via a ComboBox
    /// </summary>
    private void SelectButton_Click(object sender, EventArgs e)
    {
        ToastOperations.ComboBoxFavoriteColor();
    }

    /// <summary>
    /// Show notification after successful or failed download
    /// </summary>
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

    /// <summary>
    /// Kill the annoying job if still scheduled
    /// </summary>
    private void StopScheduledNotificationButton_Click(object sender, EventArgs e)
    {
        Schedule? schedule = JobManager.AllSchedules.FirstOrDefault(x => x.Name == "Annoying");
        if (schedule is not null)
        {
            JobManager.RemoveJob("Annoying");
        }
    }


}