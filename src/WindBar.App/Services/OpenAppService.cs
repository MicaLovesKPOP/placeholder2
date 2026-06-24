using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace WindBar.App.Services
{
    public sealed class OpenAppService
    {
        private const int SW_MINIMIZE = 6;
        private const int SW_RESTORE = 9;

        public sealed class OpenApp
        {
            public string Title { get; set; } = string.Empty;
            public string ProcessName { get; set; } = string.Empty;
            public string ExecutablePath { get; set; } = string.Empty;
            public string AppKey { get; set; } = string.Empty;
            public IntPtr WindowHandle { get; set; }
            public bool IsActive { get; set; }
        }

        public sealed class OpenAppGroup
        {
            public string DisplayName { get; set; } = string.Empty;
            public string AppKey { get; set; } = string.Empty;
            public string ExecutablePath { get; set; } = string.Empty;
            public bool IsActive { get; set; }
            public int WindowCount { get; set; }
            public OpenApp PrimaryWindow { get; set; } = new OpenApp();
        }

        public IEnumerable<OpenApp> GetOpenApps()
        {
            var currentProcessId = Environment.ProcessId;
            var foreground = GetForegroundWindow();
            var apps = new List<OpenApp>();

            foreach (var process in Process.GetProcesses())
            {
                try
                {
                    if (process.Id == currentProcessId)
                        continue;

                    var handle = process.MainWindowHandle;
                    if (handle == IntPtr.Zero)
                        continue;

                    var title = process.MainWindowTitle;
                    if (string.IsNullOrWhiteSpace(title))
                        continue;

                    var executablePath = GetExecutablePath(process);
                    var processName = process.ProcessName;
                    apps.Add(new OpenApp
                    {
                        Title = title,
                        ProcessName = processName,
                        ExecutablePath = executablePath,
                        AppKey = CreateAppKey(processName, executablePath),
                        WindowHandle = handle,
                        IsActive = handle == foreground
                    });
                }
                catch
                {
                }
            }

            return apps
                .OrderByDescending(app => app.IsActive)
                .ThenBy(app => app.ProcessName)
                .ThenBy(app => app.Title)
                .ToList();
        }

        public IEnumerable<OpenAppGroup> GetOpenAppGroups()
        {
            return GetOpenApps()
                .GroupBy(app => app.AppKey)
                .Select(group =>
                {
                    var primary = group.OrderByDescending(app => app.IsActive).ThenBy(app => app.Title).First();
                    return new OpenAppGroup
                    {
                        DisplayName = primary.ProcessName,
                        AppKey = group.Key,
                        ExecutablePath = primary.ExecutablePath,
                        IsActive = group.Any(app => app.IsActive),
                        WindowCount = group.Count(),
                        PrimaryWindow = primary
                    };
                })
                .OrderByDescending(group => group.IsActive)
                .ThenBy(group => group.DisplayName)
                .ToList();
        }

        public void ActivateOrToggle(OpenApp app)
        {
            if (app.WindowHandle == IntPtr.Zero) return;
            if (GetForegroundWindow() == app.WindowHandle)
            {
                ShowWindow(app.WindowHandle, SW_MINIMIZE);
                return;
            }

            ShowWindow(app.WindowHandle, SW_RESTORE);
            SetForegroundWindow(app.WindowHandle);
        }

        public static string CreateAppKey(string processName, string executablePath)
        {
            if (!string.IsNullOrWhiteSpace(executablePath))
                return Path.GetFullPath(executablePath).Trim().ToUpperInvariant();

            return (processName ?? string.Empty).Trim().ToUpperInvariant();
        }

        private static string GetExecutablePath(Process process)
        {
            try
            {
                return process.MainModule?.FileName ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}
