using System;

namespace WindBar.Core
{
    public interface IMediaProvider
    {
        string Id { get; }
        string DisplayName { get; }
        MediaSessionState Current { get; }
        event EventHandler? Changed;
        void PlayPause();
        void Previous();
        void Next();
    }
}
