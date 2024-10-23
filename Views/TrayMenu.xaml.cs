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
    }

    private void TrayMenu_ActualThemeChanged(FrameworkElement sender, object args)
    {
        if (sender.ActualTheme == ElementTheme.Light)
        {
            ImageSource = new BitmapImage(Constants.TrayIconConnectedLightUri);
        }
        else
        {
            ImageSource = new BitmapImage(Constants.TrayIconConnectedDarkUri);
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
            TrayIcon.Dispose();
        }
        catch { }
    }
}
