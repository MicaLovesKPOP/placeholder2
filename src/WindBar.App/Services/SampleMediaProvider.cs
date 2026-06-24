using System;
using WindBar.Core;

namespace WindBar.App.Services
{
    public sealed class SampleMediaProvider : IMediaProvider
    {
        private MediaSessionState _current = new MediaSessionState
        {
            SourceName = "Universal media",
            Title = "Nothing playing",
            Artist = "WindBar",
            PlaybackState = MediaPlaybackState.Paused,
            CanPlayPause = true,
            CanGoPrevious = true,
            CanGoNext = true
        };

        public string Id => "media.sample";
        public string DisplayName => "Sample media provider";
        public MediaSessionState Current => _current;
        public event EventHandler? Changed;

        public void PlayPause()
        {
            _current.PlaybackState = _current.PlaybackState == MediaPlaybackState.Playing
                ? MediaPlaybackState.Paused
                : MediaPlaybackState.Playing;
            Changed?.Invoke(this, EventArgs.Empty);
        }

        public void Previous()
        {
            _current = new MediaSessionState
            {
                SourceName = "Universal media",
                Title = "Previous track",
                Artist = "Sample source",
                PlaybackState = MediaPlaybackState.Playing,
                CanPlayPause = true,
                CanGoPrevious = true,
                CanGoNext = true
            };
            Changed?.Invoke(this, EventArgs.Empty);
        }

        public void Next()
        {
            _current = new MediaSessionState
            {
                SourceName = "Universal media",
                Title = "Next track",
                Artist = "Sample source",
                PlaybackState = MediaPlaybackState.Playing,
                CanPlayPause = true,
                CanGoPrevious = true,
                CanGoNext = true
            };
            Changed?.Invoke(this, EventArgs.Empty);
        }
    }
}
