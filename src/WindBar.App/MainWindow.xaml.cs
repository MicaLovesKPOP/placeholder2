using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WindBar.App
{
    public partial class MainWindow : Window
    {
        private readonly Grid _root = new Grid();
        private readonly StackPanel _left = new StackPanel { Orientation = Orientation.Horizontal };
        private readonly StackPanel _center = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Center };
        private readonly StackPanel _right = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Right };

        public MainWindow()
        {
            Width = SystemParameters.PrimaryScreenWidth;
            Height = 48;
            Left = 0;
            Top = SystemParameters.PrimaryScreenHeight - Height;
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;
            Topmost = true;
            ShowInTaskbar = false;
            Background = new SolidColorBrush(Color.FromArgb(235, 32, 32, 32));
            Content = _root;
            BuildUi();
        }

        private void BuildUi()
        {
            _root.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            _root.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            _root.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            Grid.SetColumn(_left, 0);
            Grid.SetColumn(_center, 1);
            Grid.SetColumn(_right, 2);
            _root.Children.Add(_left);
            _root.Children.Add(_center);
            _root.Children.Add(_right);

            _left.Children.Add(MakeButton("⊞", ShowStart));
            _left.Children.Add(MakeButton("Search", null));
            _center.Children.Add(MakeButton("Edge", null));
            _center.Children.Add(MakeButton("Files", null));
            _center.Children.Add(MakeButton("Code", null));
            _right.Children.Add(MakeButton(DateTime.Now.ToString("HH:mm"), null));
        }

        private Button MakeButton(string text, RoutedEventHandler? action)
        {
            var button = new Button
            {
                Content = text,
                Margin = new Thickness(4, 6, 4, 6),
                Padding = new Thickness(12, 0, 12, 0),
                MinWidth = 40,
                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0)),
                Foreground = Brushes.White,
                BorderBrush = new SolidColorBrush(Color.FromArgb(35, 255, 255, 255))
            };
            if (action != null) button.Click += action;
            return button;
        }

        private void ShowStart(object sender, RoutedEventArgs e)
        {
            var start = new Window
            {
                Width = 650,
                Height = 650,
                Left = 16,
                Top = Top - 660,
                WindowStyle = WindowStyle.None,
                ResizeMode = ResizeMode.NoResize,
                Topmost = true,
                ShowInTaskbar = false,
                Background = new SolidColorBrush(Color.FromArgb(245, 32, 32, 32)),
                Content = new TextBlock
                {
                    Text = "WindBar Start\n\nWindows 11, Windows 10 and Windows 8.1 style Start experiences will be loaded here.",
                    Foreground = Brushes.White,
                    FontSize = 20,
                    Margin = new Thickness(32)
                }
            };
            start.Deactivated += (_, __) => start.Close();
            start.Show();
        }
    }
}
