using Microsoft.UI.Xaml.Media.Imaging;

namespace Appstore;

public sealed partial class DynamicPage : Page
{
    public DynamicPage()
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
        var content = new StackPanel
        {
            Spacing = 0,
            Children =
            {
                new Image
                {
                    Source = new BitmapImage(new Uri(DynamicDetails.impath)),
                    Stretch = Stretch.Uniform,
                    HorizontalAlignment = HorizontalAlignment.Left,
                },
                new TextBlock
                {
                    Text = DynamicDetails.AppName,
                    IsTextSelectionEnabled = true,
                },
                new TextBlock
                {
                    Text = DynamicDetails.AppDescription,
                    IsTextSelectionEnabled = true,
                },
            }

        };
        for (int i = 0; i <= DynamicDetails.downloadlinks.Count - 1; i++)
        {
            content.Children.Add(new HL
            {
                Content = ((List<(string, string)>)DynamicDetails.downloadlinks)[i].Item1,
                path = ((List<(string, string)>)DynamicDetails.downloadlinks)[i].Item2,

            });
        }
        this.SizeChanged += (s, e) =>
        {
            var bounds = App.MainWindow.Bounds;
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
            if (bounds.Width > bounds.Height) ((FrameworkElement)content.Children[0]).Width = bar.Width / 7;
            else ((FrameworkElement)content.Children[0]).Width = bar.Width / 2.8;
            ((FrameworkElement)content.Children[0]).Height = ((FrameworkElement)content.Children[0]).Width;
            ((FrameworkElement)content.Children[1]).Margin = new Thickness(0, (H.Height - bar.Height) / 64, 0, 0);
            ((TextBlock)content.Children[1]).Width = bar.Width - bar.Width / 14 - bar.Width / 34;
            if (bounds.Width > bounds.Height) ((TextBlock)content.Children[1]).FontSize = content.Width / 65;
            else ((TextBlock)content.Children[1]).FontSize = ((TextBlock)content.Children[1]).Width / 20;
            ((TextBlock)content.Children[2]).Width = bar.Width - bar.Width / 14 - bar.Width / 34;
            if (bounds.Width > bounds.Height) ((TextBlock)content.Children[2]).FontSize = content.Width / 72;
            else ((TextBlock)content.Children[2]).FontSize = ((TextBlock)content.Children[2]).Width / 23;
            for (int i = 3; i < content.Children.Count; i++)
            {
                ((FrameworkElement)content.Children[i]).Margin = new Thickness(0, (H.Height - bar.Height) / 32, 0, 0);
                ((HyperlinkButton)content.Children[i]).Width = ((FrameworkElement)content.Children[0]).Width;
                ((FrameworkElement)content.Children[i]).Height = ((FrameworkElement)content.Children[0]).Width;
                VerticalAlignment = VerticalAlignment.Top;
                HorizontalAlignment = HorizontalAlignment.Left;
                if (bounds.Width > bounds.Height)
                    ((HyperlinkButton)content.Children[i]).FontSize = ((FrameworkElement)content.Children[0]).Width;
                else
                    ((HyperlinkButton)content.Children[i]).FontSize = ((FrameworkElement)content.Children[0]).Width;
            }
        };
        this.Loaded += (s, e) =>
        {
            var bounds = App.MainWindow.Bounds;
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
            if (bounds.Width > bounds.Height) ((FrameworkElement)content.Children[0]).Width = bar.Width / 7;
            else ((FrameworkElement)content.Children[0]).Width = bar.Width / 2.8;
            ((FrameworkElement)content.Children[0]).Height = ((FrameworkElement)content.Children[0]).Width;
            ((FrameworkElement)content.Children[1]).Margin = new Thickness(0,(H.Height - bar.Height) / 64,0,0);
            ((TextBlock)content.Children[1]).Width = bar.Width - bar.Width / 14 - bar.Width / 34;
            if (bounds.Width > bounds.Height) ((TextBlock)content.Children[1]).FontSize = content.Width / 65;
            else ((TextBlock)content.Children[1]).FontSize = ((TextBlock)content.Children[1]).Width / 20;
            ((TextBlock)content.Children[2]).Width = bar.Width - bar.Width / 14 - bar.Width / 34;
            if (bounds.Width > bounds.Height) ((TextBlock)content.Children[2]).FontSize = content.Width / 72;
            else ((TextBlock)content.Children[2]).FontSize = ((TextBlock)content.Children[2]).Width / 23;
            for (int i = 3; i < content.Children.Count; i++)
            {
                ((FrameworkElement)content.Children[i]).Margin = new Thickness(0, (H.Height - bar.Height) / 32, 0, 0);
                ((HyperlinkButton)content.Children[i]).Width = ((FrameworkElement)content.Children[0]).Width;
                ((FrameworkElement)content.Children[i]).Height = ((FrameworkElement)content.Children[0]).Width;
                VerticalAlignment = VerticalAlignment.Top;
                HorizontalAlignment = HorizontalAlignment.Left;
                if (bounds.Width > bounds.Height)
                    ((HyperlinkButton)content.Children[i]).FontSize = ((TextBlock)content.Children[0]).FontSize;
                else
                    ((HyperlinkButton)content.Children[i]).FontSize = ((TextBlock)content.Children[0]).FontSize;
            }
        };
        Helpers.Add(H, bar, 0, 0);
        Helpers.Add(H, content, 1, 0);
    }

}
