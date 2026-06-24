# WindBar media miniplayer plugin

## Goal

The first custom plugin target for WindBar is a compact taskbar media miniplayer. The idea is a Winamp-inspired mini control surface that integrates cleanly with Windows 11 instead of looking like a retro skin pasted onto the taskbar.

The reference use case is a compact universal media item for YouTube Music, Spotify, browsers and local players.

## Product feel

The plugin should feel:

- Compact enough to live inside the taskbar full time.
- Native to Windows 11, with rounded hover states, soft borders and matching theme surfaces.
- Slightly Winamp-like in spirit: always-available media identity, simple controls, optional progress/time and compact track text.
- Calm and readable, not flashy.

## Default horizontal layout

Recommended default layout:

1. Source icon or album art thumbnail.
2. Track title, clipped with ellipsis.
3. Artist or source name, optional in compact mode.
4. Previous, play/pause and next controls in compact mode when space allows.
5. Optional progress information in the expanded slideout.

Very compact mode can use:

- Icon/artwork
- Play/pause
- Track title only

Expanded mode can use:

- Larger artwork
- Title
- Artist
- Source app
- Previous/play-next controls
- Progress/time
- Volume shortcut

## Cassette/CD slideout interaction

The preferred expanded interaction is a slideout panel rather than a plain popup. The mental model is a cassette or CD tray sliding out of the compact player.

Behavior:

- The compact taskbar miniplayer remains small and always available.
- Clicking the body of the miniplayer opens a richer panel anchored to the module.
- On a bottom taskbar, the panel slides upward out of the player.
- On a top taskbar, the panel slides downward out of the player.
- The slideout should use a short, soft ease-out animation.
- Transport buttons inside the compact module should keep working without accidentally toggling the slideout.

This gives the module a distinctive identity while still feeling polished and Windows-native.

## Vertical layout behavior

A vertical taskbar cannot hold wide text. In vertical mode the miniplayer should collapse to:

- Album art/source icon as the main button.
- Small play/pause overlay.
- Tooltip or flyout for title and controls.

The full controls should appear in a flyout anchored to the module.

## Theme behavior

Light mode:

- Use a lightly tinted surface with subtle border.
- Text should prioritize contrast over translucency.

Dark mode:

- Use Windows 11-style dark surface.
- Hover should brighten softly.

OLED mode:

- Main surface should be true black where possible.
- Borders and hover states should be subtle to avoid glowing blocks.

Transparent mode:

- Use stronger text shadows or higher-contrast text backgrounds only inside the module.
- Never make track text unreadable for the sake of transparency.

## Data source strategy

The correct long-term data source is Windows media session integration. The plugin should read from the active media session rather than scraping app windows.

The media service should expose:

- Source app id/name
- Title
- Artist
- Album
- Artwork when available
- Playback state
- Timeline/progress when available
- Supported controls

The first prototype can fall back to sample data when media session data is unavailable.

## Plugin requirements created by this design

The miniplayer forces the plugin system to support:

- Live state updates.
- Compact, normal and expanded display modes.
- Horizontal and vertical orientation declarations.
- Flyout views.
- Theme-aware rendering.
- Optional permissions for media-session access.
- Graceful fallback when no media is playing.

## No-media state

When nothing is playing, the module should not become visual noise. Options:

- Hide automatically.
- Collapse to a small media icon.
- Show the last source in a muted state.

This should be user-configurable.

## First implementation milestone

1. Add media state models and a media widget contract.
2. Add a placeholder miniplayer module using fake sample data.
3. Wire it as an optional module in the right or center zone.
4. Replace fake data with Windows media session data.
5. Add a cassette/CD-style slideout panel with expanded controls.
