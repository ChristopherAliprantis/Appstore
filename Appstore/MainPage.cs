using Windows.Storage.Pickers;

namespace Appstore;

public sealed partial class MainPage : Page
{
    public static Windows.Foundation.Rect bounds;
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
        var ccontent = new StackPanel
        {
            Children =
            {
                new DDsendBut
                {
                    imp = "ms-appx:///Assets/todologo.png",
                    des = "ToDo, your ultimate time management app",
                    nm = "ToDo",
                    Content = "ToDo",
                    dl = new List<(string, string)>
                    {
                        ("ToDo-winx64","ms-appx:///Assets/apps/ToDo-winx64.zip"),
                        ("ToDo-android","ms-appx:///Assets/apps/ToDo-android.zip")
                    },
                },
                new DDsendBut
                {
                    imp = "ms-appx:///Assets/matrixlogo.png",
                    des = "Simple Matix library for dotnet ecosystem",
                    nm = "Matrix",
                    Content = "Matrix",
                    dl = new List<(string, string)>
                    {
                        ("Matrix-dll","ms-appx:///Assets/apps/Matrix-dll.zip"),
                    },
                }

            }


        };
        var content = new ScrollViewer
        {
            Content = ccontent
        };
        
        this.SizeChanged += (s, e) =>
        {
            bounds = App.MainWindow.Bounds;
            H.Width = this.ActualWidth;
            H.Height = this.ActualHeight;
            bar.Height = this.ActualHeight / 17;
            bar.Width = this.ActualWidth;
            ((Rectangle)bar.Children[1]).Height = bar.Height / 25;
            ((StackPanel)bar.Children[0]).Height = bar.Height - (bar.Height / 5);
            ((Rectangle)bar.Children[1]).Width = bar.Width;
            ((StackPanel)bar.Children[0]).Width = bar.Width;
            double pad = bar.Height / 12;
            ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[0]).Margin = new Thickness(bar.Width / 20.833, 0, 0, pad/4);
            ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[1]).Margin = new Thickness(bar.Width / 31.25, 0, 0, pad/4);
            ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[1]).Height = bar.Height - (pad / 2);
            ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[1]).Width = ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[0]).Height * 3;
            ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[0]).Height = bar.Height - (pad / 2);
            ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[0]).Width = ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[0]).Height * 3;
            ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[1]).FontSize = ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[1]).Height / 1.6;
            ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[0]).FontSize = ((TextButton)((StackPanel)((StackPanel)bar).Children[0]).Children[0]).Height / 1.6;
            content.Margin = new Thickness(bar.Width / 14, bar.Height / 9, 0, 0);
            content.Width = bar.Width - bar.Width / 14 - bar.Width / 34;
            content.Height = (H.Height - bar.Height);
            ccontent.Height = content.Height; 
            ccontent.Width = content.Width;
            ccontent.Spacing = content.Height / 63;
            for (int i = 0; i < ccontent.Children.Count; i++)
            {
                //if (i > 0) ((FrameworkElement)ccontent.Children[i]).Margin = new Thickness(0, (H.Height - bar.Height) / 1, 0, 0);
                if (bounds.Width > bounds.Height) ((FrameworkElement)ccontent.Children[i]).Width = bar.Width / 7;
                else ((FrameworkElement)ccontent.Children[i]).Width = bar.Width / 3.8;
                ((FrameworkElement)ccontent.Children[i]).Height = ((FrameworkElement)ccontent.Children[i]).Width;
                ((Button)ccontent.Children[i]).FontSize = ((FrameworkElement)ccontent.Children[i]).Height / 3.6;
            }
        };
        this.Loaded += (s, e) =>
        {
            bounds = App.MainWindow.Bounds;
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
            content.Height = (H.Height - bar.Height);
            ccontent.Height = content.Height;
            ccontent.Width = content.Width;
            ccontent.Spacing = content.Height / 63;
            for (int i = 0; i < ccontent.Children.Count; i++)
            {
                //if (i > 0) ((FrameworkElement)ccontent.Children[i]).Margin = new Thickness(0, (H.Height - bar.Height) / 1, 0, 0);
                if (bounds.Width > bounds.Height) ((FrameworkElement)ccontent.Children[i]).Width = bar.Width / 7;
                else ((FrameworkElement)ccontent.Children[i]).Width = bar.Width / 3.8;
                ((FrameworkElement)ccontent.Children[i]).Height = ((FrameworkElement)ccontent.Children[i]).Width;
                ((Button)ccontent.Children[i]).FontSize = ((FrameworkElement)ccontent.Children[i]).Height / 3.6;
            }
        };
        Helpers.Add(H, bar, 0, 0);
        Helpers.Add(H, content, 1, 0);
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

public class TextButton : TextBlock
{
    public TextButton() 
    {
        this.PointerEntered += (s, e) =>
        {
            this.ProtectedCursor = Microsoft.UI.Input.InputSystemCursor.Create(Microsoft.UI.Input.InputSystemCursorShape.Hand);
            this.Foreground = new SolidColorBrush(Colors.Blue);
        };
        this.PointerExited += (s, e) =>
        {
            this.ProtectedCursor = Microsoft.UI.Input.InputSystemCursor.Create(Microsoft.UI.Input.InputSystemCursorShape.Arrow); 
            this.Foreground = new SolidColorBrush(Colors.Black);
        };
    }

}

public class DynamicDetails
{
    public static List<(string, string)>? downloadlinks; // <(link name, link path)
    public static string? impath;
    public static string? AppName;
    public static string? AppDescription;
}

public class DDsendBut : Button
{
    public string? des;
    public string? imp;
    public List<(string, string)>? dl; // <name, path>
    public string? nm;
    public DDsendBut()
    {
        this.Click += (s, e) =>
        {
            DynamicDetails.AppDescription = des;
            DynamicDetails.downloadlinks = dl;
            DynamicDetails.impath = imp;
            DynamicDetails.AppName = nm;
            App.rootFrame.Navigate(typeof(DynamicPage));
        };
    }
}

public class HL : HyperlinkButton
{ 
    public string? path;
    public HL()
    {
        this.Foreground = new SolidColorBrush(Colors.Blue);
        this.Click += async (s, e) =>
        {
            if (string.IsNullOrEmpty(path)) return;

            try
            {
                var savePicker = new FileSavePicker();
                savePicker.SuggestedStartLocation = PickerLocationId.Downloads;
                string ext = System.IO.Path.GetExtension(path) ?? ".bin";
                if (string.IsNullOrEmpty(ext)) ext = ".bin";

                savePicker.FileTypeChoices.Add("File", new List<string>() { ext });
                savePicker.SuggestedFileName = System.IO.Path.GetFileNameWithoutExtension(path) ?? "download";
                StorageFile file = await savePicker.PickSaveFileAsync();

                if (file != null)
                {
                    CachedFileManager.DeferUpdates(file);
                    using (var client = new HttpClient())
                    {
                        var bytes = await client.GetByteArrayAsync(path);
                        await FileIO.WriteBytesAsync(file, bytes);
                    }
                    await CachedFileManager.CompleteUpdatesAsync(file);
                }
            }
            catch
            {
                return;
            }
        };
        this.PointerEntered += (s, e) =>
        {
            this.Foreground = new SolidColorBrush(Colors.Blue);
        };
    }
}

