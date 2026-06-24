using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WindBar.Core;

namespace WindBar.App.Views
{
    public sealed class StartSurface : UserControl
    {
        private readonly List<AppScanner.AppInfo> _apps;
        private readonly ListBox _list = new ListBox
        {
            Background = Brushes.Transparent,
            BorderThickness = new Thickness(0),
            Foreground = Brushes.White
        };

        public StartSurface(string title, IEnumerable<AppScanner.AppInfo> apps)
        {
            _apps = apps
                .OrderBy(x => x.Group)
                .ThenBy(x => x.Name)
                .Take(250)
                .ToList();

            var root = new StackPanel { Margin = new Thickness(24) };
            root.Children.Add(new TextBlock
            {
                Text = title,
                FontSize = 24,
                FontWeight = FontWeights.SemiBold,
                Foreground = Brushes.White,
                Margin = new Thickness(0, 0, 0, 18)
            });

            var search = new TextBox
            {
                Margin = new Thickness(0, 0, 0, 14),
                Padding = new Thickness(10, 7, 10, 7),
                MinWidth = 320,
                ToolTip = "Type to filter apps"
            };
            search.TextChanged += (_, __) => PopulateList(search.Text);
            search.KeyDown += (_, e) =>
            {
                if (e.Key == Key.Down && _list.Items.Count > 0)
                {
                    _list.SelectedIndex = Math.Max(0, _list.SelectedIndex);
                    _list.Focus();
                    e.Handled = true;
                }
            };
            root.Children.Add(search);

            _list.MouseDoubleClick += (_, __) => LaunchSelected();
            _list.KeyDown += (_, e) =>
            {
                if (e.Key == Key.Enter)
                {
                    LaunchSelected();
                    e.Handled = true;
                }
            };

            PopulateList(string.Empty);
            root.Children.Add(_list);
            Content = root;
        }

        private void PopulateList(string query)
        {
            _list.Items.Clear();
            var normalized = (query ?? string.Empty).Trim();
            var matches = string.IsNullOrWhiteSpace(normalized)
                ? _apps
                : _apps.Where(app => Matches(app, normalized));

            foreach (var app in matches.Take(100))
            {
                _list.Items.Add(new ListBoxItem
                {
                    Content = $"{app.Group}  •  {app.Name}",
                    Tag = app.Path,
                    ToolTip = app.Path
                });
            }

            if (_list.Items.Count > 0)
                _list.SelectedIndex = 0;
        }

        private static bool Matches(AppScanner.AppInfo app, string query)
        {
            return app.Name.Contains(query, StringComparison.OrdinalIgnoreCase)
                || app.Group.Contains(query, StringComparison.OrdinalIgnoreCase)
                || app.Path.Contains(query, StringComparison.OrdinalIgnoreCase);
        }

        private void LaunchSelected()
        {
            if (_list.SelectedItem is not ListBoxItem item || item.Tag is not string path)
                return;

            try
            {
                Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
            }
            catch
            {
            }
        }
    }
}
