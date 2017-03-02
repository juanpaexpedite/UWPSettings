using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPSettings.Common;
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

namespace UWPSettings.UI
{
    public sealed partial class BadgeInformation : UserControl
    {
        #region Badge Source
        public Badge BadgeSource
        {
            get { return (Badge)GetValue(BadgeSourceProperty); }
            set { SetValue(BadgeSourceProperty, value); }
        }

        public static readonly DependencyProperty BadgeSourceProperty =
            DependencyProperty.Register(nameof(BadgeSource), typeof(Badge), typeof(BadgeInformation), new PropertyMetadata(new Badge("", "", Badge.StarNumbers.None, false, DateTime.Now, "#FFFFFF", "")));
        #endregion

        #region Converters
        public string ToEarned(DateTime datetime)
        {
            return $"Earned on {datetime.ToString(System.Globalization.DateTimeFormatInfo.CurrentInfo.ShortDatePattern)}";
        }
        #endregion

        public BadgeInformation()
        {
            this.InitializeComponent();
        }
    }
}
