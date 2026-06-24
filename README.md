# WindBar

WindBar is an Explorer-safe Windows 11 taskbar replacement prototype written in C# and WPF. It keeps Explorer alive, draws its own topmost taskbar, and provides the groundwork for a modular taskbar with Start menu providers, widgets, themes, top and bottom placement, auto-hide, and future per-monitor layouts.

## Current prototype

The current build is a code-only WPF app. It avoids XAML build issues by disabling default XAML compilation and creating the UI from C#.

Implemented now:

- Top or bottom taskbar placement on the primary monitor.
- Auto-hide prototype.
- Light, dark, OLED and transparent theme modes.
- Left, center and right taskbar zones.
- Start provider switching buttons.
- Windows 11 style Start provider placeholder.
- Windows 10 style Start provider placeholder.
- Windows 8.1 full-screen Start screen provider placeholder.
- Classic Start provider placeholder.
- Clock module.
- Pinned app placeholder buttons.
- Core settings model.
- Widget contract and widget manager.
- App scanner stub for installed and portable app discovery.

## Product direction

WindBar should eventually feel indistinguishable from the Windows 11 taskbar by default while giving power users much deeper control.

The final product should support:

- A native-feeling Windows 11 taskbar design.
- Optional modules for Start, search, pinned apps, running apps, tray, clock, action center, widgets and media.
- User-controlled left, center and right placement of modules.
- Fully functional Windows 11, Windows 10 and Windows 8.1 Start experiences using Windows 11 visual language.
- Smart app discovery and grouping for installed apps and portable apps.
- Top and bottom placement first, then left, right and per-monitor placement later.
- Light, dark, OLED and transparent themes.
- Appbar registration for proper work-area reservation.
- Safe fallback to the native Windows taskbar.

## Build

Open windbar.sln in Visual Studio 2022 or newer and build WindBar.App.

The next milestone is to replace placeholders with real module services and a real appbar host.
