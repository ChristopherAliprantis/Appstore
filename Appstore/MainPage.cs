namespace Appstore;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        var H = new Grid
        {
            Width = 1000,
            Height = 1000,
        };
        this.Content = H;
    }
}
