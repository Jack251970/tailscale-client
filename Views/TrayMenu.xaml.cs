using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using WinUIEx;

namespace TailscaleClient.Views;

[ObservableObject]
public sealed partial class TrayMenu : UserControl
{
    [ObservableProperty]
    private string _appDisplayName = Constants.AppDisplayName;

    [ObservableProperty]
    private ImageSource _imageSource = null;

    public TrayMenu()
    {
        InitializeComponent();
        TrayMenu_ActualThemeChanged(this, null);
        Core.API.OnConnectedChanged += API_OnConnectedChanged;
    }

    private void API_OnConnectedChanged(object sender, bool connected)
    {
        App.MainWindow.DispatcherQueue.TryEnqueue(() => SetTrayMenuIcon(ActualTheme == ElementTheme.Light, connected));
    }

    private void TrayMenu_ActualThemeChanged(FrameworkElement sender, object args)
    {
        SetTrayMenuIcon(ActualTheme == ElementTheme.Light, Core.API.Connected);
    }

    private void SetTrayMenuIcon(bool lightTheme, bool connected)
    {
        if (lightTheme)
        {
            ImageSource = new BitmapImage(connected ? Constants.TrayIconConnectedLightUri : Constants.TrayIconDisconnectedLightUri);
        }
        else
        {
            ImageSource = new BitmapImage(connected ? Constants.TrayIconConnectedDarkUri : Constants.TrayIconDisconnectedDarkUri);
        }
    }

    [RelayCommand]
    private void ShowWindow()
    {
        App.MainWindow.Show();
        App.MainWindow.BringToFront();
    }

    [RelayCommand]
    private void ExitApp()
    {
        DisposeTrayIconControl();
        App.CanCloseWindow = true;
        App.MainWindow.Close();
    }

    private void DisposeTrayIconControl()
    {
        try
        {
            Core.API.OnConnectedChanged -= API_OnConnectedChanged;
            TrayIcon.Dispose();
        }
        catch { }
    }
}
