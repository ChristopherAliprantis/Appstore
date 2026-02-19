namespace Appstore;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        var H = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition { Height = GridLength.Auto},
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star)}
            },
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)}
            }


        };
        this.Content = H;
        var bar = new StackPanel
        {

            Background = new SolidColorBrush(Colors.Transparent),
            Children =
            {
                new StackPanel
                {
                    Background = new SolidColorBrush(Colors.White),
                },
                new Rectangle
                {
                    Fill = new SolidColorBrush(Colors.Black)
                }

            },

        };
        this.SizeChanged += (s, e) =>
        {
            H.Width = this.ActualWidth;
            H.Height = this.ActualHeight;
            bar.Height = this.ActualHeight / 18;
            bar.Height = this.ActualWidth;
            ((Rectangle)bar.Children[1]).Height = bar.Height / 50;
            ((Rectangle)bar.Children[0]).Height = bar.Height - bar.Height / 50;
            ((Rectangle)bar.Children[1]).Width = bar.Width;
            ((Rectangle)bar.Children[0]).Height = bar.Width;

        };
        this.Loaded += (s, e) =>
        {
            H.Width = this.ActualWidth;
            H.Height = this.ActualHeight;
            bar.Height = this.ActualHeight / 18;
            bar.Height = this.ActualWidth;
            ((Rectangle)bar.Children[1]).Height = bar.Height / 50;
            ((Rectangle)bar.Children[0]).Height = bar.Height - bar.Height / 50;
            ((Rectangle)bar.Children[1]).Width = bar.Width;
            ((Rectangle)bar.Children[0]).Height = bar.Width;

        };
        Helpers.Add(H, bar, 0, 0);
    }
}

public class Helpers
{
    public static void Add(Grid grid, UIElement element, int row, int column)
    {
        grid.Children.Remove(element);
        Grid.SetRow(element, row);
        Grid.SetColumn(element, column);
        grid.Children.Add(element);
    }
}

