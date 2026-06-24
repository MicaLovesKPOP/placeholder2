namespace WindBar.Core
{
    /// <summary>
    /// Provides a Start menu implementation.
    /// </summary>
    public interface IStartMenuProvider
    {
        /// <summary>
        /// A user friendly display name.
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// Creates the view object for the Start menu. The type is intentionally unspecified to avoid framework dependency.
        /// </summary>
        object CreateView();
    }
}
