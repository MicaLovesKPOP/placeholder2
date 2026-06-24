using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WindBar.App.Services
{
    public sealed class AppIconService
    {
        private readonly Dictionary<string, ImageSource?> _cache = new Dictionary<string, ImageSource?>(StringComparer.OrdinalIgnoreCase);

        public ImageSource? GetIcon(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return null;

            var key = path.Trim();
            if (_cache.TryGetValue(key, out var cached))
                return cached;

            var icon = LoadIcon(key);
            _cache[key] = icon;
            return icon;
        }

        private static ImageSource? LoadIcon(string path)
        {
            try
            {
                if (!File.Exists(path))
                    return null;

                using var icon = Icon.ExtractAssociatedIcon(path);
                if (icon == null)
                    return null;

                var source = Imaging.CreateBitmapSourceFromHIcon(
                    icon.Handle,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromWidthAndHeight(16, 16));
                source.Freeze();
                return source;
            }
            catch
            {
                return null;
            }
        }
    }
}
