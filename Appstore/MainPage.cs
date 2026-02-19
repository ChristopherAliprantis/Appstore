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
        var bar = new StackPanel
        {
            
            Background = new SolidColorBrush(Colors.White),
            Height = 60,
            Children =
            {
                new StackPanel
                {

                }
                new Rectangle
                {
                    Height = 2,
                    Width = 1000,
                    Fill = new SolidColorBrush(Colors.Black)
                }

        };

    }
}

public class Helpers
{
    static void Add(Grid grid, UIElement element, int row, int column)
    {
        grid.Children.Remove(element);
        Grid.SetRow(element, row);
        Grid.SetColumn(element, column);
        grid.Children.Add(element);
    }
}

