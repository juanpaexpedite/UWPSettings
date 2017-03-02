using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPSettings.UI
{
    public sealed partial class Crostini : UserControl
    {
        #region Default Width
        public double DefaultWidth
        {
            get { return (double)GetValue(DefaultWidthProperty); }
            set { SetValue(DefaultWidthProperty, value); }
        }

        public static readonly DependencyProperty DefaultWidthProperty =
            DependencyProperty.Register(nameof(DefaultWidth), typeof(double), typeof(Crostini), new PropertyMetadata(360.0));
        #endregion

        #region Icon
        public String Icon
        {
            get { return (String)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(String), typeof(Crostini), new PropertyMetadata("\uEA1F"));
        #endregion

        #region Title
        public String Title
        {
            get { return (String)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(String), typeof(Crostini), new PropertyMetadata("Information"));
        #endregion

        #region Text
        public String Text
        {
            get { return (String)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(String), typeof(Crostini), new PropertyMetadata(String.Empty));
        #endregion

        #region IsIndeterminate
        public bool IsIndeterminate
        {
            get { return (bool)GetValue(IsIndeterminateProperty); }
            set { SetValue(IsIndeterminateProperty, value); }
        }

        public static readonly DependencyProperty IsIndeterminateProperty =
            DependencyProperty.Register(nameof(IsIndeterminate), typeof(bool), typeof(Crostini), new PropertyMetadata(false));

        public Visibility Invert(bool isindeterminate)
        {
            return isindeterminate ? Visibility.Collapsed : Visibility.Visible;
        }
        #endregion

        #region ContentElement
        public UIElement ContentElement
        {
            get { return (UIElement)GetValue(ContentElementProperty); }
            set { SetValue(ContentElementProperty, value); }
        }
        public static readonly DependencyProperty ContentElementProperty =
            DependencyProperty.Register(nameof(ContentElement), typeof(UIElement), typeof(Crostini), new PropertyMetadata(null));

        public Visibility IsNull(UIElement element)
        {
            return element == null ? Visibility.Collapsed : Visibility.Visible;
        }
        #endregion

        public Crostini()
        {
            this.InitializeComponent();
        }

        private static Popup currentToast;

        private static Popup CreateNotification(string title, string text,string icon, bool isindeterminate, UIElement content, double defaultwidth = 360)
        {
            var offsetY = Window.Current.CoreWindow.Bounds.Width - defaultwidth;
            var toast = new Popup() { Margin = new Thickness(offsetY, 32, 0, 0), VerticalAlignment = VerticalAlignment.Top, HorizontalAlignment = HorizontalAlignment.Right };
            toast.Child = new Crostini()
            {
                Icon = icon,
                Title = title,
                Text = text,
                IsIndeterminate = isindeterminate,
                ContentElement = content,
                DefaultWidth = defaultwidth
            };
            var transition = new TransitionCollection();
            transition.Add(new PopupThemeTransition() { FromHorizontalOffset = defaultwidth, FromVerticalOffset = 0 });
            toast.ChildTransitions = transition;
            return toast;
        }

        public static void OpenNotification(string text, string title = "Information", bool isindeterminate = false, string icon = "\uEA1F", UIElement content = null, double defaultwidth = 360)
        {
            if (currentToast != null)
                return;

            currentToast = CreateNotification(title, text, icon, isindeterminate, content, defaultwidth);
            currentToast.IsOpen = true;

        }

        public static void CloseNotification()
        {
            if (currentToast == null)
                return;

            currentToast.IsOpen = false;
            currentToast = null;
        }

        public async static Task ShowNotification(string text, string title = "Information", bool isindeterminate = false, string icon = "\uEA1F", double seconds = 3, UIElement content = null, double defaultwidth = 360)
        {
            var toast = CreateNotification(title, text, icon, isindeterminate, content, defaultwidth);
            toast.IsOpen = true;
            await Task.Delay(TimeSpan.FromSeconds(seconds));
            toast.IsOpen = false;
            toast = null;
        }
    }
}
