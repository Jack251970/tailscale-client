using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;

namespace TailscaleClient.Views;

[ObservableObject]
public sealed partial class Error : Page
{
    [ObservableProperty]
    private ImageSource _imageSource = null;

    public Error()
    {
        InitializeComponent();
        Page_ActualThemeChanged(this, null);
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        App.MainWindow.SetTitleBar(AppTitleBar);
    }

    private void Page_ActualThemeChanged(FrameworkElement sender, object args)
    {
        if (sender.ActualTheme == ElementTheme.Light)
        {
            ImageSource = new BitmapImage(Constants.AppIconLightAppxUri);
        }
        else
        {
            ImageSource = new BitmapImage(Constants.AppIconDarkAppxUri);
        }
    }
}
