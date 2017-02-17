using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UWPSettings.Common;
using UWPSettings.Managers;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPSettings
{
    public sealed partial class SettingsPanel : UserControl
    {
        #region IsDialog
        public bool IsDialog
        {
            get { return (bool)GetValue(IsDialogProperty); }
            set { SetValue(IsDialogProperty, value); }
        }

        public static readonly DependencyProperty IsDialogProperty =
            DependencyProperty.Register(nameof(IsDialog), typeof(bool), typeof(SettingsPanel), new PropertyMetadata(true));
        #endregion

        #region Title
        public String Title
        {
            get { return (String)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(String), typeof(SettingsPanel), new PropertyMetadata("Settings"));
        #endregion

        #region ItemsSource
        //I would like to set is to a tuple but at the moment is not possible
        public List<Setting> ItemsSource
        {
            get { return (List<Setting>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(ItemsSource), typeof(List<Setting>), typeof(SettingsPanel), new PropertyMetadata(new List<Setting>()));
        #endregion

        #region Go to Details
        private void SettingsGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is Setting setting)
            {
                CurrentItem = setting;
                Show(setting);
            }

        }

        private void Show(Setting setting)
        {
            if (setting.Details != null)
            {
                ShowDetails(setting);
            }
            else if (setting.Uri != null)
            {
                ShowUri(setting);
            }
            else
            {
                setting.Service(setting);
            }
        }

        private async void ShowDetails(Setting setting)
        {
            var details = InteropManager.LaunchDetails(setting.Details);
            await ShowDetails(details);
        }

        private async Task ShowDetails(UIElement details)
        {
            DetailsView.Children.Clear();
            DetailsPanel.Children.Clear();
            await Task.Delay(60); //To finish the tap animation
            IsDetails = true;

            DetailsView.Children.Add(DetailsHeaderPanel);
            DetailsView.Children.Add(DetailsPanel);

            if (details != null)
            {
                DetailsPanel.Children.Add(details);
            }
        }

        private async void ShowUri(Setting setting)
        {
            var uri = setting.Uri;

            if (uri.Scheme == "ms-appx" && uri.AbsoluteUri.LastIndexOf(".md") > 0)
            {
                var content = await InteropManager.Read(uri);
                var child = new MarkdownTextBlock { Text = content };
                var scroller = new ScrollViewer { Content = child };
                await ShowDetails(scroller);
            }
            else
            {
                await InteropManager.LaunchUri(setting.Uri);
            }
        }
        #endregion

        #region Current Item
        public Setting CurrentItem
        {
            get { return (Setting)GetValue(CurrentItemProperty); }
            set { SetValue(CurrentItemProperty, value); }
        }

        public static readonly DependencyProperty CurrentItemProperty =
            DependencyProperty.Register(nameof(CurrentItem), typeof(Setting), typeof(SettingsPanel), new PropertyMetadata(null));
        #endregion

        #region Master Details
        public bool IsDetails
        {
            get { return (bool)GetValue(IsDetailsProperty); }
            set { SetValue(IsDetailsProperty, value); }
        }

        public static readonly DependencyProperty IsDetailsProperty =
            DependencyProperty.Register(nameof(IsDetails), typeof(bool), typeof(SettingsPanel), new PropertyMetadata(false));
        #endregion

        #region Dialog TitleBar
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            var popup = VisualTreeHelper.GetOpenPopups(Window.Current).FirstOrDefault(p => p.Child is ContentDialog);

            if (popup?.Child is ContentDialog dialog)
            {
                dialog.Hide();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            IsDetails = false;
            DetailsPanel.Children.Clear();
        }
        #endregion

        #region Constructor, Initialization
        public SettingsPanel()
        {
            this.InitializeComponent();

            this.Loaded += SettingsPane_Loaded;

            this.Unloaded += SettingsPanel_Unloaded;

            
        }
        #endregion

        #region Back
        private void SettingsPanel_Unloaded(object sender, RoutedEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().BackRequested -= SettingsPanel_BackRequested;

            if (ApiInformation.IsApiContractPresent("Windows.Phone.PhoneContract", 1, 0))
            {
                Windows.Phone.UI.Input.HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
            }
        }

        private void CheckBack()
        {
            SystemNavigationManager.GetForCurrentView().BackRequested += SettingsPanel_BackRequested;

            if (ApiInformation.IsApiContractPresent("Windows.Phone.PhoneContract", 1, 0))
            {
                Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            }
        }

        private void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            if (IsDetails)
            {
                e.Handled = true;
            }
            return;
        }

        private void SettingsPanel_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (IsDetails)
            {
                e.Handled = true;
            }
            return;
        }
        #endregion

        private void SettingsPane_Loaded(object sender, RoutedEventArgs e)
        {
            CheckBack();

            if (DeviceManager.CurrentIs(Devices.Phone))
            {
                
            }
            else
            {
                if (IsDialog)
                {
                    CompositionManager.InitializeDropShadow(ShadowHost);
                }
            }
        }
    }
}
