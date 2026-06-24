# WindBar implementation plan

## Goal

WindBar should become a polished Windows 11 taskbar replacement that keeps Explorer running while replacing the visible taskbar experience with a modular, themeable, user-controlled bar.

## Product pillars

1. Native by default. The default layout should feel like the Windows 11 taskbar.
2. Modular by design. Start, search, apps, tray, clock, action center and widgets should all be removable or movable.
3. Multiple Start experiences. WindBar should ship with Windows 11, Windows 10, Windows 8.1 full-screen and classic Start styles, all using Windows 11 design language.
4. Smart first run. The app should discover installed apps and likely portable apps, then propose a clean first layout.
5. Safe shell integration. Explorer must keep running. WindBar should be easy to disable and should never leave users without recovery.

## Milestone 1: Buildable prototype

- Code-only WPF startup.
- Primary monitor bar.
- Top and bottom placement.
- Auto-hide prototype.
- Theme cycling.
- Start provider switching.
- Placeholder Start providers.
- Placeholder app buttons.
- Clock.

## Milestone 2: Proper taskbar host

- Register as a Windows appbar.
- Reserve work area for maximized windows.
- Add safe native taskbar restore mode.
- Add settings persistence.
- Add DPI-aware sizing.

## Milestone 3: Real modules

- Start button module.
- Search module.
- Pinned apps module.
- Running windows module.
- Clock module.
- Tray module.
- Action center module.
- Widget strip module.
- Media module.

## Milestone 4: Start menus

- Windows 11 style Start with pinned grid, all apps and search.
- Windows 10 style Start with app list and modern tile/widget area.
- Windows 8.1 style full-screen Start with groups and large tiles.
- Classic Start with two-column layout and modern styling.

## Milestone 5: Smart app discovery

- Start menu shortcut scan.
- Registry uninstall scan.
- Microsoft Store app scan.
- User-selected portable folders.
- Confidence scoring for executable candidates.
- Auto grouping by app category, path, metadata and user rules.

## Milestone 6: Themes and polish

- Light theme.
- Dark theme.
- OLED theme.
- Transparent theme.
- Fluent hover and press states.
- Rounded flyouts.
- Keyboard navigation.
- Accessible names.

## Milestone 7: Future expansion

- Multi-monitor bars.
- Left and right edge bars.
- Per-monitor module layout.
- External widget package format.
- Start menu package format.
- Import/export profiles.
