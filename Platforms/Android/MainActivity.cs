using Android.App;
using Android.Content.PM;
using Android.OS;

namespace CentralInovacao;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        //Mudar a cor da NavigationBar e da StatusBar no Android
        Window.SetStatusBarColor(Android.Graphics.Color.LightGray);
        Window.SetNavigationBarColor(Android.Graphics.Color.LightGray);

        base.OnCreate(savedInstanceState);
    }
}
