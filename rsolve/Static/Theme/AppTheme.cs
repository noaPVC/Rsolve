using System;
using System.Windows;

namespace Rsolve.Static.Theme
{
    public static class AppTheme
    {
        /// <summary>
        /// Property for retrieving the property of the current theme.
        /// </summary>
        public static Theme CurrentTheme { get; set; }

        /// <summary>
        /// Essential property for setting and getting the current Theme as a dictionary.
        /// </summary>
        public static ResourceDictionary ThemeDictionary 
        {
            get => Application.Current.Resources.MergedDictionaries[0];
            set => Application.Current.Resources.MergedDictionaries[0] = value; 
        }

        /// <summary>
        /// Helper function for setting the theme.
        /// </summary>
        /// <param name="uri">
        /// Takes in the a uri specified by Set(Theme theme).
        /// </param>
        private static void ChangeTheme(Uri uri) => ThemeDictionary = new ResourceDictionary() { Source = uri };
        
        /// <summary>
        /// Sets the specified theme of the application during runtime.
        /// </summary>
        /// <param name="theme">
        /// Takes in a theme from the enum Theme.
        /// </param>
        public static void Set(Theme theme)
        {
            // TODO: implement default theme
            string themeName = "Default";
            CurrentTheme = theme;
            switch (theme)
            {
                case Theme.Light: themeName = "Light"; break;
                case Theme.Dark: themeName = "Dark"; break;
            }

            try
            {
                if (!string.IsNullOrEmpty(themeName))
                    ChangeTheme(new Uri($"Themes/{themeName}.xaml", UriKind.Relative));
            } catch {}
        }
    }
}
