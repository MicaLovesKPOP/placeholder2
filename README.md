# WindBar

WindBar is a custom Windows 11 taskbar replacement written in C#/.NET. It aims to look and feel like the native Windows 11 taskbar while providing advanced features such as multiple start menu experiences (Windows 11, Windows 10 re‑imagined, and Windows 7 re‑imagined), a flexible widget system, and support for top/bottom alignment with future expansion to left/right edges.

## Features

- Looks and behaves like the built‑in Windows 11 taskbar by default.
- Multiple start menu providers: Windows 11 style, Windows 10 style re‑imagined with modern Mica/Fluent visual language, Windows 7 style re‑imagined.
- Widget framework with a plug‑in architecture; widgets declare whether they support horizontal/vertical bars and fallback modes.
- Automatic app scanning for pinned apps and start menu population, including detection of portable apps in user‑selected folders.
- Top/bottom alignment support with the infrastructure for left/right edges in the future.
- Designed for multi‑monitor scenarios; the architecture supports per‑monitor bar instances.

## Architecture

`WindBar.Core` contains the core abstractions (`IStartProvider`, `IWidget`), a simple `WidgetManager` to register and manage widgets, and an `AppScanner` stub to discover installed and portable applications.

`WindBar.App` is a WPF application that hosts the custom bar. `MainWindow` creates a `TaskbarControl` that renders the bar at the top or bottom of the primary monitor. The bar can switch start menu providers dynamically and can be extended via widgets.

Most of the functionality is currently scaffolding; the TODO comments mark places where contributions are needed to implement the full behaviour.
