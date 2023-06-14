using System.Diagnostics;
using Notifications.Models;

namespace Notifications.Classes;

public class TimeOperations
{
    /// <summary>
    /// For demonstrating working with ToastSelectionBoxItem in
    /// ToastOperations.
    ///
    /// In a real application the Action would perform a meaningful task
    /// 
    /// </summary>
    public static List<Time> TimeList() =>
        new()
        {
            new () { Id = 15, Action = () => Debug.WriteLine("15 minutes") },
            new () { Id = 30, Action = () => Debug.WriteLine("30 minutes")  },
            new () { Id = 45, Action = () => Debug.WriteLine("45 minutes")  },
            new () { Id = 60, Action = () => Debug.WriteLine("60 minutes")  }
        };
}