using FluentScheduler;
using Serilog.Core;
using System.Runtime.CompilerServices;
using Serilog;

namespace Notifications;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {

        Application.Run(new Form1());
        ToastOperations.Clear();

        // Stop the FluentScheduler scheduler
        // See also: StopScheduledNotificationButton_Click in Form1
        JobManager.StopAndBlock();
    }       

    [ModuleInitializer]
    public static void Init()
    {
        ApplicationConfiguration.Initialize();

        // Start the FluentScheduler scheduler
        JobManager.Initialize(new JobsRegistry());

        ToastOperations.OnActivated();
        SetupLogging.Development();

        JobManager.JobStart += info => Log.Information($"{info.Name}: started");
        JobManager.JobEnd += info => Log.Information($"{info.Name}: ended ({info.Duration})");
    }
}