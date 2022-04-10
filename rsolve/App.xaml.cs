using System.Windows;
using Rsolve.Static.Theme;

namespace rsolve
{
    /// <summary>
    /// Main Application related concerns (services/stores/startup_setups).
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AppTheme.Set(Theme.Dark);
            base.OnStartup(e);
        }
    }
}
