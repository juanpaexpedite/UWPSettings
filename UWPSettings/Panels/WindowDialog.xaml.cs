using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPSettings.Managers;
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

namespace UWPSettings.Panels
{
    public sealed partial class WindowDialog : UserControl
    {
        #region IsDialog
        /// <summary>
        /// Dialog Popup or Standalone Window
        /// </summary>
        public bool IsDialog
        {
            get { return (bool)GetValue(IsDialogProperty); }
            set { SetValue(IsDialogProperty, value); }
        }

        /// <summary>
        /// Dialog Popup or Standalone Window
        /// </summary>
        public static readonly DependencyProperty IsDialogProperty =
            DependencyProperty.Register(nameof(IsDialog), typeof(bool), typeof(WindowDialog), new PropertyMetadata(true));
        #endregion

        #region Header
        public String Header
        {
            get { return (String)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register(nameof(Header), typeof(String), typeof(WindowDialog), new PropertyMetadata(String.Empty));
        #endregion

        #region HeaderIcon
        public String HeaderIcon
        {
            get { return (String)GetValue(HeaderIconProperty); }
            set { SetValue(HeaderIconProperty, value); }
        }

        public static readonly DependencyProperty HeaderIconProperty =
            DependencyProperty.Register(nameof(HeaderIcon), typeof(String), typeof(WindowDialog), new PropertyMetadata(String.Empty));
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
           
        }
        #endregion

        #region Content
        public UIElement WindowContent
        {
            get { return (UIElement)GetValue(WindowContentProperty); }
            set { SetValue(WindowContentProperty, value); }
        }

        public static readonly DependencyProperty WindowContentProperty =
            DependencyProperty.Register(nameof(WindowContent), typeof(UIElement), typeof(WindowDialog), new PropertyMetadata(null));
        #endregion

        #region IsDetails
        public bool IsDetails
        {
            get { return (bool)GetValue(IsDetailsProperty); }
            set { SetValue(IsDetailsProperty, value); }
        }

        public static readonly DependencyProperty IsDetailsProperty =
            DependencyProperty.Register(nameof(IsDetails), typeof(bool), typeof(WindowDialog), new PropertyMetadata(false, OnIsDetailsChanged));

        private static void OnIsDetailsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is WindowDialog window)
            {
                if (e.NewValue is bool details && details == false)
                {
                    window.DetailsBack?.Invoke();
                }
            }
        }

        public Visibility IsMaster(bool isdetails)
        {
            return isdetails ? Visibility.Collapsed : Visibility.Visible;
        }
        #endregion

        public static WindowDialog Instance { get; set; }
        public Action DetailsBack { get; set; }

        public WindowDialog()
        {
            Instance = this;

            this.InitializeComponent();

            this.Loaded += WindowPanel_Loaded;
        }

        private void WindowPanel_Loaded(object sender, RoutedEventArgs e)
        {
            //CheckBack();

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
