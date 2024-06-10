using ConnectFour.Features;
using System.Globalization;
using Microsoft.Maui.Controls;
namespace ConnectFour;

public partial class App : Application
{
    public static DatabaseService Database { get; private set; }
    public App(IServiceProvider serviceProvider)
	{
		InitializeComponent();
		MainPage = serviceProvider.GetService<MainPage>();
        
    }

    protected override void OnStart()
    {
        base.OnStart();
        SetCulture(CultureInfo.CurrentCulture);
    }

    private void SetCulture(CultureInfo cultureInfo)
    {
        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
    }
    public void ChangePlayerOneColor(Color newColor)
    {
        Resources["PlayerOneLight"] = newColor;
        Resources["PlayerOneLightBrush"] = new SolidColorBrush(newColor);
    }

    public void ChangePlayerTwoColor(Color newColor)
    {
        Resources["PlayerTwoLight"] = newColor;
        Resources["PlayerTwoLightBrush"] = new SolidColorBrush(newColor);
    }
}

