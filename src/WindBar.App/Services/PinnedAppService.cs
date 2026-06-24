using System.Collections.Generic;
using System.Linq;
using WindBar.Core;

namespace WindBar.App.Services
{
    public sealed class PinnedAppService
    {
        private readonly PinnedAppStore _store = new PinnedAppStore();
        private readonly AppScanner _scanner = new AppScanner();

        public List<PinnedApp> LoadOrCreateDefaults()
        {
            var existing = _store.Load();
            if (existing.Count > 0) return existing;

            var defaults = _scanner.ScanSmartDefaults()
                .Take(6)
                .Select((app, index) => new PinnedApp
                {
                    Name = app.Name,
                    Path = app.Path,
                    Group = app.Group,
                    Order = index
                })
                .ToList();

            _store.Save(defaults);
            return defaults;
        }

        public void Save(IEnumerable<PinnedApp> apps)
        {
            _store.Save(apps.OrderBy(app => app.Order));
        }
    }
}
