using System;
using System.IO;
using System.Text.Json;
using WindBar.Core;

namespace WindBar.App.Services
{
    public sealed class SettingsStore
    {
        private readonly string _path;

        public SettingsStore()
        {
            var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WindBar");
            Directory.CreateDirectory(folder);
            _path = Path.Combine(folder, "settings.json");
        }

        public WindBarSettings Load()
        {
            try
            {
                if (!File.Exists(_path)) return CreateDefaultSettings();
                var json = File.ReadAllText(_path);
                var settings = JsonSerializer.Deserialize<WindBarSettings>(json) ?? new WindBarSettings();
                settings.EnsureModuleLayoutDefaults();
                return settings;
            }
            catch
            {
                return CreateDefaultSettings();
            }
        }

        public void Save(WindBarSettings settings)
        {
            settings.EnsureModuleLayoutDefaults();
            var json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_path, json);
        }

        private static WindBarSettings CreateDefaultSettings()
        {
            var settings = new WindBarSettings();
            settings.EnsureModuleLayoutDefaults();
            return settings;
        }
    }
}