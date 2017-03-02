using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPSettings.Common;
using UWPSettings.Panels;
using UWPSettings.Panes;
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
        public static async Task ShowSettingsDialog(string title, List<Setting> settings, int index = -1)
        {
            var instance = new SettingsPane { ItemsSource = settings };

            Action goback = () =>
            {
                instance.IsDetails = false;
            };

            await ShowWindowDialog(instance, title, detailsback:goback);
        }

        ///// <summary>
        ///// This shows the settings pane in a new Window
        ///// </summary>
        ///// <param name="title"></param>
        ///// <param name="settings"></param>
        ///// <returns></returns>
        //public static async Task ShowWindow(string title, List<Setting> settings)
        //{
        //    var result = await CreateShowStandaloneWindow(title, settings);
        //}
        #endregion

        //public static async Task<bool> CreateShowStandaloneWindow(string title, List<Setting> settings)
        //{
        //    CoreApplicationView newView = CoreApplication.CreateNewView();
        //    int newViewId = 0;

        //    await newView.RunNormal(() =>
        //    {
        //        //The instance of the control must be created in the Thread of the new window
        //        var instance = CreateSettings(settings);
        //        Window.Current.Content = instance;
        //        Window.Current.Activate();
        //        ApplicationView.GetForCurrentView().Title = title;
        //        newViewId = ApplicationView.GetForCurrentView().Id;
        //    });

        //    return await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId, ViewSizePreference.UseMore);
        //}

        private static IAsyncAction RunNormal(this CoreApplicationView appview, Action action)
        {
            return appview.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => action());
        }

        #region Generic Window
        public static async Task ShowWindowDialog(UIElement instance, string header = null, string headericon = null, Action detailsback = null)
        {
            var window = new WindowDialog() { WindowContent = instance, Header = header, HeaderIcon = headericon };
            window.DetailsBack = detailsback;
            var isphone = DeviceManager.CurrentIs(Devices.Phone);
            if (isphone)
            {
                window.IsDialog = false;
            }
            var stylename = isphone ? "SettingsDialogBoxMobileStyle" : "SettingsDialogBoxStyle";
            var dialog = new ContentDialog { Content = window, Style = window.Resources[stylename] as Style };

            dialog.Closing += (s, e) =>
            {
                if (window.IsDetails && isphone)
                {
                    e.Cancel = true;
                    window.IsDetails = false;
                }

            };

            await dialog.ShowAsync();
        }
        #endregion
    }
}
