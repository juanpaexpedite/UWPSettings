using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPSettings.Common;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPSettings.Managers
{
    public static class WindowManager
    {
        #region Interop
        /// <summary>
        /// This shows the settings pane in a modal dialog
        /// </summary>
        /// <param name="title"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static async Task ShowDialog(string title, List<Setting> settings)
        {
            var instance = CreateSettings(title, settings);
            await ShowDialog(instance);
        }

        /// <summary>
        /// This shows the settings pane in a new Window
        /// </summary>
        /// <param name="title"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static async Task ShowWindow(string title, List<Setting> settings)
        {
            var result = await CreateShowStandaloneWindow(title, settings);
        }

        #endregion

        public static async Task<bool> CreateShowStandaloneWindow(string title, List<Setting> settings)
        {
            CoreApplicationView newView = CoreApplication.CreateNewView();
            int newViewId = 0;

            await newView.RunNormal(() =>
            {
                //The instance of the control must be created in the Thread of the new window
                var instance = CreateSettings(title, settings, false);
                Window.Current.Content = instance;
                Window.Current.Activate();
                ApplicationView.GetForCurrentView().Title = title;
                newViewId = ApplicationView.GetForCurrentView().Id;
            });

            return await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId, ViewSizePreference.UseMore);
        }

        private static IAsyncAction RunNormal(this CoreApplicationView appview, Action action)
        {
            return appview.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => action());
        }

        private static async Task ShowDialog(SettingsPanel instance)
        {
            var isphone = DeviceManager.CurrentIs(Devices.Phone);
            if (isphone)
            {
                instance.IsDialog = false;
            }
            var stylename = isphone ? "SettingsDialogBoxMobileStyle" : "SettingsDialogBoxStyle";
            var dialog = new ContentDialog { Content = instance, Style = instance.Resources[stylename] as Style };
            //Workaround to track the physical mobile back button (because it is not fired from a ContentDialog)
            dialog.Closing += (s, e) =>
            {
                if (instance.IsDetails)
                {
                    e.Cancel = true;
                    instance.IsDetails = false;
                }
            };
            await dialog.ShowAsync();
        }

        private static SettingsPanel CreateSettings(string title, List<Setting> Settings, bool isdialog = true)
        {
            return new SettingsPanel
            {
                Title = title,
                ItemsSource = Settings,
                IsDialog = isdialog
            };
        }
    }
}
