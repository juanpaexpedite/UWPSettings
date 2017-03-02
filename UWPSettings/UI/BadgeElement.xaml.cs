using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPSettings.Common;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class BadgeElement : UserControl
    {
        #region Badge Source
        public Badge BadgeSource
        {
            get { return (Badge)GetValue(BadgeSourceProperty); }
            set { SetValue(BadgeSourceProperty, value); }
        }

        public static readonly DependencyProperty BadgeSourceProperty =
            DependencyProperty.Register(nameof(BadgeSource), typeof(Badge), typeof(BadgeElement), new PropertyMetadata(new Badge("","",Badge.StarNumbers.None, false, DateTime.Now,"#FFFFFF","")));
        #endregion

        #region Conversions
        public SolidColorBrush ToBrush(string color)
        {
            return new SolidColorBrush(ThemeColors.HexToColor(color).Value);
        }

        public FontFamily ToFontFamily(string name)
        {
            return new FontFamily(name);
        }

        public string ToStars(Badge.StarNumbers amount)
        {
            string template = "\uE00A";
            switch (amount)
            {
                case Badge.StarNumbers.None:
                    return String.Empty;
                case Badge.StarNumbers.One:
                    return template;
                case Badge.StarNumbers.Two:
                    return $"{template} {template}";
                case Badge.StarNumbers.Three:
                    return $"{template} {template} {template}";
                default:
                    return String.Empty;
            }
        }
        #endregion

        #region Opacity
        public double ToOpacity(bool earned)
        {
            return earned ? 1 : 0.333;
        }
        #endregion

        public BadgeElement()
        {
            this.InitializeComponent();
        }
    }
}
