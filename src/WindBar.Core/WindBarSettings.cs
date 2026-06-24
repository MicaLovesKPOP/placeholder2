using System.Collections.Generic;
using System.Linq;

namespace WindBar.Core
{
    public enum BarEdge
    {
        Bottom,
        Top,
        Left,
        Right
    }

    public enum BarTheme
    {
        System,
        Light,
        Dark,
        Oled,
        Transparent
    }

    public enum ModuleZone
    {
        Left,
        Center,
        Right
    }

    public enum MediaNoSessionBehavior
    {
        ShowMutedLastSource,
        HideModule,
        CollapseModule
    }

    public sealed class TaskbarModulePlacement
    {
        public string Id { get; set; } = string.Empty;
        public ModuleZone Zone { get; set; }
        public int Order { get; set; }
    }

    public sealed class WindBarSettings
    {
        public BarEdge Edge { get; set; } = BarEdge.Bottom;
        public BarTheme Theme { get; set; } = BarTheme.Dark;
        public bool AutoHide { get; set; }
        public int BarThickness { get; set; } = 48;
        public string StartProviderId { get; set; } = "start.win11";
        public bool ShowStartButton { get; set; } = true;
        public bool ShowSearchButton { get; set; } = true;
        public bool ShowStartSwitcher { get; set; } = true;
        public bool ShowPinnedApps { get; set; } = true;
        public bool ShowOpenApps { get; set; } = true;
        public bool ShowMediaMiniPlayer { get; set; } = true;
        public string PreferredMediaSourceContains { get; set; } = string.Empty;
        public MediaNoSessionBehavior MediaNoSessionBehavior { get; set; } = MediaNoSessionBehavior.ShowMutedLastSource;
        public bool ShowThemeButton { get; set; } = true;
        public bool ShowPlacementButton { get; set; } = true;
        public bool ShowAutoHideButton { get; set; } = true;
        public bool ShowClock { get; set; } = true;
        public bool ShowSettingsButton { get; set; } = true;
        public List<TaskbarModulePlacement> ModuleLayout { get; set; } = CreateDefaultModuleLayout();

        public void EnsureModuleLayoutDefaults()
        {
            ModuleLayout ??= new List<TaskbarModulePlacement>();
            foreach (var placement in CreateDefaultModuleLayout())
            {
                if (ModuleLayout.All(existing => existing.Id != placement.Id))
                    ModuleLayout.Add(placement);
            }
        }

        public IEnumerable<TaskbarModulePlacement> GetOrderedModuleLayout()
        {
            EnsureModuleLayoutDefaults();
            return ModuleLayout.OrderBy(module => module.Zone).ThenBy(module => module.Order).ThenBy(module => module.Id);
        }

        private static List<TaskbarModulePlacement> CreateDefaultModuleLayout()
        {
            return new List<TaskbarModulePlacement>
            {
                new TaskbarModulePlacement { Id = "start", Zone = ModuleZone.Left, Order = 10 },
                new TaskbarModulePlacement { Id = "search", Zone = ModuleZone.Left, Order = 20 },
                new TaskbarModulePlacement { Id = "start.switcher", Zone = ModuleZone.Left, Order = 30 },
                new TaskbarModulePlacement { Id = "taskbar.apps", Zone = ModuleZone.Center, Order = 10 },
                new TaskbarModulePlacement { Id = "media", Zone = ModuleZone.Right, Order = 10 },
                new TaskbarModulePlacement { Id = "settings", Zone = ModuleZone.Right, Order = 20 },
                new TaskbarModulePlacement { Id = "theme", Zone = ModuleZone.Right, Order = 30 },
                new TaskbarModulePlacement { Id = "placement", Zone = ModuleZone.Right, Order = 40 },
                new TaskbarModulePlacement { Id = "autohide", Zone = ModuleZone.Right, Order = 50 },
                new TaskbarModulePlacement { Id = "clock", Zone = ModuleZone.Right, Order = 60 }
            };
        }
    }
}