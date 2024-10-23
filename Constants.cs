using System;
using System.IO;

namespace TailscaleClient;

public static class Constants
{
    public const string AppDisplayName = "Tailscale";

    public readonly static string AppIconLightAbsolutePath = Path.Combine(AppContext.BaseDirectory, "Assets/Icons/AppIconBase-Light.ico");

    public readonly static string AppIconDarkAbsolutePath = Path.Combine(AppContext.BaseDirectory, "Assets/Icons/AppIconBase-Dark.ico");

    public readonly static Uri AppIconLightAppxUri = new("ms-appx:///Assets/Icons/AppIconBase-Light.ico");

    public readonly static Uri AppIconDarkAppxUri = new("ms-appx:///Assets/Icons/AppIconBase-Dark.ico");

    public readonly static Uri TrayIconConnectedLightUri = new("ms-appx:///Assets/Icons/TrayIcon-Connected-Light.ico");

    public readonly static Uri TrayIconConnectedDarkUri = new("ms-appx:///Assets/Icons/TrayIcon-Connected-Dark.ico");

    public readonly static Uri TrayIconDisconnectedLightUri = new("ms-appx:///Assets/Icons/TrayIcon-Disconnected-Light.ico");

    public readonly static Uri TrayIconDisconnectedDarkUri = new("ms-appx:///Assets/Icons/TrayIcon-Disconnected-Dark.ico");
}
