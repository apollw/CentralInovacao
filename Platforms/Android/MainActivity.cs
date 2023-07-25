using Android.App;
using Android.Content.PM;
using Android.OS;

namespace CentralInovacao;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    //Mudar a cor da NavigationBar e da StatusBar no Android
    protected override void OnCreate(Bundle savedInstanceState)
    {
        Window.SetStatusBarColor(Android.Graphics.Color.DarkGreen);
        Window.SetNavigationBarColor(Android.Graphics.Color.DarkGreen);

        base.OnCreate(savedInstanceState);
    }
}
