namespace Appstore;

public sealed partial class InfoPage : Page
{
    public InfoPage()
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

            Spacing = 0,
            Background = new SolidColorBrush(Colors.Transparent),
            Children =
            {
                new StackPanel
                {
                    Background = new SolidColorBrush(Colors.White),
                    Orientation = Orientation.Horizontal,
                    Spacing = 0,
                    Children =
                    {
                        new TextButton
                        {
                            Text = "Apps",

                        },
                        new TextButton
                        {
                            Text = "Info",

                        }
                    }

                },
                new Rectangle
                {
                    Fill = new SolidColorBrush(Colors.Black)
                }

            },

        };
        var content = new TextBlock
        {
            Text = "You can distribute the APK or EXE(+ DLLs and other stuff) files that you get from the app downloads; you need to say that github.com/ChristopherAliprantis made it. Also you can repackage the app in another package format.",
            TextWrapping = TextWrapping.WrapWholeWords,
            Foreground = new SolidColorBrush(Colors.Black),
            IsTextSelectionEnabled = true,
        };
        content.PointerEntered += (s, e) =>
        {
            this.ProtectedCursor = Microsoft.UI.Input.InputSystemCursor.Create(Microsoft.UI.Input.InputSystemCursorShape.IBeam);
        };
        content.PointerEntered += (s, e) =>
        {
            this.ProtectedCursor = Microsoft.UI.Input.InputSystemCursor.Create(Microsoft.UI.Input.InputSystemCursorShape.Arrow);
        };
        ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[0]).Tapped += async(s, e) =>
        {
            App.rootFrame.Navigate(typeof(MainPage));
            await Task.Delay(200);
        };
        ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[1]).Tapped += async(s, e) =>
        {
            App.rootFrame.Navigate(typeof(InfoPage));
            await Task.Delay(200);
        };
        this.SizeChanged += (s, e) =>
        {
            H.Width = this.ActualWidth;
            H.Height = this.ActualHeight;
            bar.Height = this.ActualHeight / 17;
            bar.Width = this.ActualWidth;
            ((Rectangle)bar.Children[1]).Height = bar.Height / 25;
            ((StackPanel)bar.Children[0]).Height = bar.Height - (bar.Height / 5);
            ((Rectangle)bar.Children[1]).Width = bar.Width;
            ((StackPanel)bar.Children[0]).Width = bar.Width;
            double pad = bar.Height / 12;
            ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[0]).Margin = new Thickness(bar.Width / 20.833, 0, 0, pad / 4);
            ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[1]).Margin = new Thickness(bar.Width / 31.25, 0, 0, pad / 4);
            ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[1]).Height = bar.Height - (pad / 2);
            ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[1]).Width = ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[0]).Height * 3;
            ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[0]).Height = bar.Height - (pad / 2);
            ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[0]).Width = ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[0]).Height * 3;
            ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[1]).FontSize = ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[1]).Height / 1.6;
            ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[0]).FontSize = ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[0]).Height / 1.6;
            content.Margin = new Thickness(bar.Width / 14, bar.Height / 9, 0, 0);
            content.Width = bar.Width - bar.Width / 14 - bar.Width / 34;
            content.FontSize = content.Width / 68;
        };
        this.Loaded += (s, e) =>
        {
            H.Width = this.ActualWidth;
            H.Height = this.ActualHeight;
            bar.Height = this.ActualHeight / 17;
            bar.Width = this.ActualWidth;
            ((Rectangle)bar.Children[1]).Height = bar.Height / 25;
            ((StackPanel)bar.Children[0]).Height = bar.Height - (bar.Height / 5);
            ((Rectangle)bar.Children[1]).Width = bar.Width;
            ((StackPanel)bar.Children[0]).Width = bar.Width;
            double pad = bar.Height / 12;
            ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[0]).Margin = new Thickness(bar.Width / 20.833, 0, 0, pad / 4);
            ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[1]).Margin = new Thickness(bar.Width / 31.25, 0, 0, pad / 4);
            ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[1]).Height = bar.Height - (pad / 2);
            ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[1]).Width = ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[0]).Height * 3;
            ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[0]).Height = bar.Height - (pad / 2);
            ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[0]).Width = ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[0]).Height * 3;
            ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[1]).FontSize = ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[1]).Height / 1.6;
            ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[0]).FontSize = ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[0]).Height / 1.6;
            content.Margin = new Thickness(bar.Width / 14, bar.Height / 9, 0, 0);
            content.Width = bar.Width - bar.Width / 14 - bar.Width / 34;
            content.FontSize = content.Width / 68;
        };
        Helpers.Add(H, bar, 0, 0);
        Helpers.Add(H, content, 1, 0);
    }
}
