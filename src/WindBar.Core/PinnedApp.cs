namespace WindBar.Core
{
    public sealed class PinnedApp
    {
        public string Name { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public string Group { get; set; } = "Apps";
        public int Order { get; set; }
    }
}
