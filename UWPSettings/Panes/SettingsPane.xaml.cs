using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UWPSettings.Common;
using UWPSettings.Managers;
using UWPSettings.Panels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPSettings.Panes
{
    public sealed partial class SettingsPane : UserControl
    {
        #region ItemsSource
        //I would like to set is to a tuple but at the moment is not possible
        public List<Setting> ItemsSource
        {
            get { return (List<Setting>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(ItemsSource), typeof(List<Setting>), typeof(SettingsPane), new PropertyMetadata(new List<Setting>()));
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
            if (WindowDialog.Instance != null)
            {
                //To Hide header
                WindowDialog.Instance.IsDetails = true;
            }

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
            DependencyProperty.Register(nameof(CurrentItem), typeof(Setting), typeof(SettingsPane), new PropertyMetadata(null));
        #endregion

        #region Master Details
        public bool IsDetails
        {
            get { return (bool)GetValue(IsDetailsProperty); }
            set { SetValue(IsDetailsProperty, value); }
        }

        public static readonly DependencyProperty IsDetailsProperty =
            DependencyProperty.Register(nameof(IsDetails), typeof(bool), typeof(SettingsPane), new PropertyMetadata(false));
        #endregion

        public SettingsPane()
        {
            this.InitializeComponent();
        }
    }
}
