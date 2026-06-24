# WindBar modules

WindBar treats taskbar sections as optional modules. This keeps the default experience close to Windows 11 while allowing power users to remove or rearrange parts they do not want.

## Current built-in module flags

The current settings model supports these visibility flags:

- ShowStartButton
- ShowSearchButton
- ShowStartSwitcher
- ShowPinnedApps
- ShowThemeButton
- ShowPlacementButton
- ShowAutoHideButton
- ShowClock

These are intentionally simple booleans for now. They allow the prototype to prove that the taskbar is modular before adding a full visual layout editor.

## Zones

WindBar has three horizontal zones:

- Left
- Center
- Right

The current default layout is:

- Left: Start, Search, Start provider switcher
- Center: Pinned apps
- Right: Theme, placement, auto-hide, clock

## Future layout model

The next layout model should store a list of module placements instead of hard-coded booleans. A placement should contain:

- Module id
- Enabled state
- Zone
- Order
- Alignment preference
- Minimum width
- Orientation support
- Fallback display mode

## Orientation support

Every future module should declare whether it supports horizontal, vertical, compact and flyout modes. This is required before WindBar adds left and right taskbar edges.

A rich horizontal widget can collapse to a compact icon in vertical mode. A vertical-only module can appear as a flyout button on horizontal bars.

## Safety rule

No optional module should be required for recovery. Even if Start, search, clock or widgets are disabled, WindBar must keep a safe settings path and a way to exit or restore the native taskbar.
