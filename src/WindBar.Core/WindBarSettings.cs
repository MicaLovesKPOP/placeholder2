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

    public sealed class WindBarSettings
    {
        public BarEdge Edge { get; set; } = BarEdge.Bottom;
        public BarTheme Theme { get; set; } = BarTheme.Dark;
        public bool AutoHide { get; set; }
        public int BarThickness { get; set; } = 48;
        public string StartProviderId { get; set; } = "start.win11";
    }
}
