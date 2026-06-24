using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using WindBar.Core;

namespace WindBar.App.Services
{
    public sealed class PinnedAppStore
    {
        private readonly string _path;

        public PinnedAppStore()
        {
            var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WindBar");
            Directory.CreateDirectory(folder);
            _path = Path.Combine(folder, "pinned-apps.json");
        }

        public List<PinnedApp> Load()
        {
            try
            {
                if (!File.Exists(_path)) return new List<PinnedApp>();
                var json = File.ReadAllText(_path);
                return JsonSerializer.Deserialize<List<PinnedApp>>(json) ?? new List<PinnedApp>();
            }
            catch
            {
                return new List<PinnedApp>();
            }
        }

        public void Save(IEnumerable<PinnedApp> apps)
        {
            var json = JsonSerializer.Serialize(apps, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_path, json);
        }
    }
}
